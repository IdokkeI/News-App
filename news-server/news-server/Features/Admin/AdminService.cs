using Microsoft.AspNetCore.Identity;
using news_server.Data.dbModels;
using news_server.Features.Admin.Model;
using news_server.Features.Notify;
using news_server.Features.Profile;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace news_server.Features.Admin
{
    public class AdminService : IAdminService
    {
        private readonly UserManager<User> userManager;
        private readonly INotificationService notificationService;
        private readonly IProfileService profileService;

        public AdminService(
            UserManager<User> userManager, 
            INotificationService notificationService,
            IProfileService profileService)
        {
            this.userManager = userManager;
            this.notificationService = notificationService;
            this.profileService = profileService;
        }


        public async Task<bool> DemoteModerator(string username)
        {
            var user = await userManager.FindByNameAsync(username);
            var isInRole = await userManager.IsInRoleAsync(user, "moderator");
            if (user != null && isInRole)
            {
                var resultDel = await userManager.RemoveFromRoleAsync(user, "moderator");
                var resultAdd = await userManager.AddToRoleAsync(user, "user");
                if (resultAdd.Succeeded && resultDel.Succeeded)
                {
                    var profileToId = (await profileService.GetProfileByUserName(user.UserName)).ProfileId;
                    var profileTo = await profileService.GetSimpleProfileById(profileToId);
                    var profileFrom = -1;
                    var text = "У вас забрали права модератора";
                    await notificationService.AddNotification(profileTo, profileFrom, text, null, null);

                    return true;
                }                
            }
            return false;
        }


        public async Task<List<GetUser>> GetModerators(int page)
        {
            var moderators = await userManager.GetUsersInRoleAsync("moderator");

            var result = await Task.Run( () => moderators
                .Select(m => new GetUser { UserName = m.UserName })
                .OrderBy(u => u.UserName)
                .Skip(page * 20 - 20)
                .Take(20)
                .ToList());

            return result;
        }


        public async Task<bool> SetModerator(string username)
        {
            var user = await userManager.FindByNameAsync(username);

            if (user != null)
            {
                var resultAdd = await userManager.AddToRoleAsync(user, "moderator");
                var resultDel = await userManager.RemoveFromRoleAsync(user, "user");

                if (resultAdd.Succeeded && resultDel.Succeeded)
                {
                    var profileToId = (await profileService.GetProfileByUserName(user.UserName)).ProfileId;
                    var profileTo = await profileService.GetSimpleProfileById(profileToId);
                    var profileFrom = -1;
                    var text = "Вам дали права модератора";
                    await notificationService.AddNotification(profileTo, profileFrom, text, null, null);

                    return true;
                }
            }
            return false;
        }
    }
}
