using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using news_server.Data.dbModels;
using System.IO;
using System.Threading.Tasks;

namespace news_server.Data.Seeder
{
    public class Seeder
    {

        public async static Task Seed(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IWebHostEnvironment env)
        {
            var userRoleResult = await roleManager.FindByNameAsync("user");
            var moderatorRoleResult = await roleManager.FindByNameAsync("moderator");
            var adminRoleResult = await roleManager.FindByNameAsync("admin");

            if (userRoleResult == null)
            {
                await roleManager
                    .CreateAsync(new IdentityRole { Name = "user" });
            }
            if (moderatorRoleResult == null)
            {
                await roleManager
                    .CreateAsync(new IdentityRole { Name = "moderator" });
            }
            if (adminRoleResult == null)
            {
                await roleManager
                    .CreateAsync(new IdentityRole { Name = "admin" });
            }

            var userResult = await userManager
                .FindByNameAsync("admin");

            if (userResult == null)
            {
                var admin = new User
                {
                    UserName = "admin",
                    Email = "admin@mail.ru",
                    Photo = Path.Combine(env.WebRootPath, "admin.png")
                };
                await userManager
                    .CreateAsync(admin, "1236985Admin");

                await userManager
                    .AddToRoleAsync(admin, "admin");
            }
        }
    }
}
