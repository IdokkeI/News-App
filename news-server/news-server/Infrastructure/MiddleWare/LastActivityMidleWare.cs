using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using news_server.Data;
using news_server.Infrastructure.Extensions;
using System;
using System.Threading.Tasks;

namespace news_server.Infrastructure.MiddleWare
{
    public class LastActivityMiddleWare
    {
        private readonly RequestDelegate next;

        public LastActivityMiddleWare(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpcontext, NewsDbContext context)
        {
            var authHeader = httpcontext.Request.Headers.ContainsKey("Authorization");
            if (authHeader)
            {
                var username = httpcontext.User.GetUserName();
                var user = await context.Users.FirstOrDefaultAsync(u => u.UserName == username);
                var profile = await context.Profiles.FirstOrDefaultAsync(p => p.UserId == user.Id && !p.isBaned);

                profile.LastActiveOn = DateTime.Now;
                context.Profiles.Update(profile);
                await context.SaveChangesAsync();
            }

            await next.Invoke(httpcontext);
        }
    }

    public static class LastActivityExtension
    {
        public static IApplicationBuilder UseLastActivity(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LastActivityMiddleWare>();
        }
    }

}
