using Microsoft.EntityFrameworkCore;
using news_server.Data;
using System.Threading.Tasks;
using news_server.Data.dbModels;
using news_server.Features.Notify;
using CProfile = news_server.Data.dbModels.Profile;
using System.Collections.Generic;
using news_server.Shared.Models;
using System.Linq;
using news_server.Features.Profile;

namespace news_server.Features.Subscriber
{
    public class SubService: ISubService
    {
        private readonly NewsDbContext context;
        private readonly INotificationService notificationService;
        private readonly IProfileService profileService;

        public SubService(
            NewsDbContext context, 
            INotificationService notificationService,
            IProfileService profileService)
        {
            this.context = context;
            this.notificationService = notificationService;
            this.profileService = profileService;
        }

        public async Task<List<GetUserPmodel>> GetSubscribers(int profileId)
        {
            var subs = await context.
                Subscriptions
                .Include(s => s.Profile)
                .Include(s => s.Profile.User)
                .Where(s => s.ProfileId == profileId)
                .Select(s => new GetUserPmodel
                {
                    ProfileID = s.ProfileIdSub,
                    UserName = profileService.GetUserNameByProfileId(s.ProfileIdSub)
                })
                .ToListAsync();

            return subs;
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
                    .Include(p => p.User)
                    .FirstOrDefaultAsync(p => p.Id == SubTo);


                var isExist = await context
                    .Subscriptions
                    .FirstOrDefaultAsync(s => s.ProfileIdSub == ownerProfile.Id && s.Profile == subProfile);

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
                            Profile = subProfile,
                            ProfileIdSub = ownerProfile.Id
                        });

                    
                    await SetNotification(subProfile, ownerProfile, link);

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

        private async Task SetNotification(CProfile profileTo, CProfile ownerProfile, string link)
        {
            var profileFrom = ownerProfile.Id;
            var userNameFrom = ownerProfile.User.UserName;
            var text = $"Пользователь <alt> подписался на вас";
            var alt = userNameFrom;

            await notificationService.AddNotification(profileTo, profileFrom, text, link, alt);
        }
    }
}
