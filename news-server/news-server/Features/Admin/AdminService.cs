using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using news_server.Data;
using news_server.Data.dbModels;
using news_server.Features.Admin.Model;
using news_server.Features.Notify;
using news_server.Features.Profile;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace news_server.Features.Admin
{
    public class AdminService : IAdminService
    {
        private readonly UserManager<User> userManager;
        private readonly INotificationService notificationService;
        private readonly IProfileService profileService;
        private readonly NewsDbContext context;

        public AdminService(
            UserManager<User> userManager, 
            INotificationService notificationService,
            IProfileService profileService,
            NewsDbContext context)
        {
            this.userManager = userManager;
            this.notificationService = notificationService;
            this.profileService = profileService;
            this.context = context;
        }


        public async Task<bool> DemoteModerator(string username)
        {
            var user = await userManager.FindByNameAsync(username);
            if (user != null)
            {
                var isInRole = await userManager.IsInRoleAsync(user, "moderator");
                if (user != null && isInRole)
                {
                    var resultDel = await userManager.RemoveFromRoleAsync(user, "moderator");
                    var resultAdd = await userManager.AddToRoleAsync(user, "user");
                    if (resultAdd.Succeeded && resultDel.Succeeded)
                    {
                        var profileToId = (await context
                            .Profiles
                            .Include(p => p.User)
                            .FirstOrDefaultAsync(p => p.User.UserName == username))
                            .Id;

                        var profileTo = await profileService.GetSimpleProfileById(profileToId);
                        var profileFrom = -1;
                        var text = "У вас забрали права модератора";
                        await notificationService.AddNotification(profileTo, profileFrom, text, null, null);

                        return true;
                    }
                }
            }
           
            return false;
        }


        public async Task<List<GetUser>> GetModerators(int page)
        {
            var role = "moderator";
            var result = await GetUsersInRole(role, page);
            return result;
        }

        public async Task<List<GetUser>> GetUsers(int page)
        {
            var role = "user";
            var result = await GetUsersInRole(role, page);
            return result;
        }


        private async Task<List<GetUser>> GetUsersInRole(string role, int page)
        {
            var moderators = await userManager.GetUsersInRoleAsync(role);

            var result = await Task.Run(() => moderators
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
                    var profileToId = (await context
                        .Profiles
                        .Include(p => p.User)
                        .FirstOrDefaultAsync(p => p.User.UserName == username))
                        .Id;

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
