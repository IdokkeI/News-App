using Microsoft.EntityFrameworkCore;
using news_server.Data;
using System.Threading.Tasks;
using news_server.Data.dbModels;
using news_server.Features.Notify;
using CProfile = news_server.Data.dbModels.Profile;
namespace news_server.Features.Subscriber
{
    public class SubService: ISubService
    {
        private readonly NewsDbContext context;
        private readonly INotificationService notificationService;

        public SubService(NewsDbContext context, INotificationService notificationService)
        {
            this.context = context;
            this.notificationService = notificationService;
        }

        public async Task<bool> SubState(int SubTo, string username, string state, string link)
        {
            if (!string.IsNullOrEmpty(state) && state == "sub")
            {
                var user = await context
                    .Users
                    .FirstOrDefaultAsync(user => user.UserName == username);

                var ownerProfile = await context
                    .Profiles
                    .Include(p => p.User)
                    .FirstOrDefaultAsync(p => p.UserId == user.Id);

                var subProfile = await context
                    .Profiles
                    .FirstOrDefaultAsync(p => p.Id == SubTo);


                var isExist = await context
                    .Subscriptions
                    .FirstOrDefaultAsync(s => s.ProfileIdSub == SubTo);

                if (ownerProfile == subProfile)
                {
                    return true;
                }

                if (subProfile != null && isExist == null)
                {
                    await context
                        .Subscriptions
                        .AddAsync(new Subscriptions
                        {
                            Profile = ownerProfile,
                            ProfileIdSub = subProfile.Id
                        });

                    var profileFrom = ownerProfile.Id;
                    await SetNotification(subProfile, profileFrom, link);

                    await context.SaveChangesAsync();

                    return true;
                }
            }
            else if (!string.IsNullOrEmpty(state) && state == "unsub")
            {
                var user = await context
                    .Users
                    .FirstOrDefaultAsync(user => user.UserName == username);

                var ownerProfile = await context
                    .Profiles
                    .FirstOrDefaultAsync(p => p.UserId == user.Id);

                var subProfile = await context
                    .Profiles
                    .FirstOrDefaultAsync(p => p.Id == SubTo);

                var sub = await context
                    .Subscriptions
                    .FirstOrDefaultAsync(s => s.Profile == ownerProfile && s.ProfileIdSub == subProfile.Id);

                if (ownerProfile == subProfile)
                {
                    return true;
                }

                if (sub == null)
                {
                    return false;
                }

                context.Subscriptions.Remove(sub);

                await context.SaveChangesAsync();

                return true;                
            }
            
            return false;          
            
        }

        private async Task SetNotification(CProfile profileTo, int profileFrom, string link)
        {
            var userNameFrom = profileTo.User.UserName;
            var text = $"Пользователь {userNameFrom} <alt> на вас";
            var alt = "подписался";

            await notificationService.AddNotification(profileTo, profileFrom, text, link, alt);
        }
    }
}
