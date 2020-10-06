using Microsoft.AspNetCore.Identity;
using news_server.Data;
using news_server.Data.dbModels;
using news_server.Features.Admin.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace news_server.Features.Admin
{
    public class AdminService : IAdminService
    {
        private readonly UserManager<User> userManager;

        public AdminService(UserManager<User> userManager)
        {
            this.userManager = userManager;
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
                    return true;
                }                
            }

            return false;
        }

        public async Task<List<GetUser>> GetModerators()
        {
            var moderators = await userManager.GetUsersInRoleAsync("moderator");
            var result = moderators.Select(m => new GetUser { UserName = m.UserName }).ToList();
            return result;
        }

        public async Task<List<GetUser>> GetUsers()
        {
            var users = await userManager.GetUsersInRoleAsync("user");
            var result = await Task.Run( () => users.Select(u => new GetUser { UserName = u.UserName }).ToList() );
           
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
                    return true;
                }
            }
            return false;
        }
    }
}
