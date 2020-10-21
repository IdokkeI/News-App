using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using news_server.Data;
using news_server.Data.dbModels;
using news_server.Data.Seeder;
using System.Threading.Tasks;

namespace news_server
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using ( var scoped = host.Services.CreateScope() )
            {
                var db = scoped
                    .ServiceProvider
                    .GetRequiredService<NewsDbContext>();

                var env = scoped
                    .ServiceProvider
                    .GetRequiredService<IWebHostEnvironment>();

                await db.Database.MigrateAsync();
                
                var userManager = scoped
                    .ServiceProvider
                    .GetRequiredService<UserManager<User>>();

                var roleManager = scoped
                    .ServiceProvider
                    .GetRequiredService<RoleManager<IdentityRole>>();

                await Seeder.Seed(userManager, roleManager, env);
            }
            host.Run();
        }   

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
