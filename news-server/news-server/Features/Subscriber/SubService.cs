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
using news_server.Features.Services;

namespace news_server.Features.Subscriber
{
    public class SubService: ISubService
    {
        private readonly NewsDbContext context;
        private readonly INotificationService notificationService;
        private readonly IProfileService profileService;
        private readonly UserSerivce userSerivce;

        public SubService(
            NewsDbContext context, 
            INotificationService notificationService,
            IProfileService profileService,
            UserSerivce userSerivce)
        {
            this.context = context;
            this.notificationService = notificationService;
            this.profileService = profileService;
            this.userSerivce = userSerivce;
        }

        public async Task<List<GetUserPmodel>> GetMySubscribers(string username, int page = 1)
        {
            var profile = await context
                .Profiles
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.User.UserName == username);

            var profileId = 0;

                if (profile != null)
                {
                    profileId = profile.Id;
                }
                
            var result = await GetSubscribers(profileId, page);
            return result;
        }

        public async Task<List<GetUserPmodel>> GetSubscribers(int profileId, int page)
        {
            var subs = await context
               .Subscriptions
               .Include(s => s.Profile)
               .Include(s => s.Profile.User)
               .Where(s => s.ProfileId == profileId)
               .Select(s => new GetUserPmodel
               {
                   ProfileID = s.ProfileIdSub
               })
               .ToListAsync();

            var result = await Task.Run(() =>
            {
               subs.ForEach(s => s.UserName = profileService.GetUserNameByProfileId(s.ProfileID));

               subs
                   .OrderBy(s => s.UserName)
                   .Skip(page * 20 - 20)
                   .Take(20)
                   .ToList();
               return subs;
            });
            
            return result;
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
                    ProfileID = s.ProfileIdSub                   
                })
                .ToListAsync();

            subs
                .ForEach(s => 
                    s.UserName = userSerivce.GetUserNameByProfileId(s.ProfileID));
            
            return subs;
        }       


        public async Task<bool> SubState(int SubTo, string username, string state, string link)
        {
            var user = await context
                    .Users
                    .FirstOrDefaultAsync(user => user.UserName == username);

            var ownerProfile = await context
                .Profiles
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.UserId == user.Id);

            var subProfileTo = await context
                .Profiles
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == SubTo);

            var isExist = await context
                .Subscriptions
                .FirstOrDefaultAsync(s => s.ProfileIdSub == ownerProfile.Id && s.Profile == subProfileTo);

            if (!string.IsNullOrEmpty(state) && state == "sub")
            {                
                if (ownerProfile == subProfileTo)
                {
                    return true;
                }

                if (subProfileTo != null && isExist == null)
                {
                    await context
                        .Subscriptions
                        .AddAsync(new Subscriptions
                        {
                            Profile = subProfileTo,
                            ProfileIdSub = ownerProfile.Id
                        });
                    
                    await SetNotification(subProfileTo, ownerProfile, link);

                    await context.SaveChangesAsync();

                    return true;
                }
            }
            if (!string.IsNullOrEmpty(state) && state == "unsub")
            {
                if (ownerProfile == subProfileTo)
                {
                    return true;
                }

                if (isExist == null)
                {
                    return false;
                }

                context.Subscriptions.Remove(isExist);

                await context.SaveChangesAsync();

                return true;                
            }            
            return false;  
        }


        private async Task SetNotification(CProfile profileTo, CProfile ownerProfile, string link)
        {
            var profileFrom = ownerProfile.Id;
            var userNameFrom = ownerProfile.User.UserName;
            var text = $"На ваши новости подписался пользователь";
            var alt = userNameFrom;

            await notificationService.AddNotification(profileTo, profileFrom, text, link, alt);
        }
    }
}
