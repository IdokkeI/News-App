using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using news_server.Data;
using news_server.Infrastructure.Extensions;
using System;
using System.Threading.Tasks;

namespace news_server.Infrastructure.Filter
{
    public class BanFilter : Attribute, IAsyncActionFilter
    {
        private readonly NewsDbContext context;

        public BanFilter(NewsDbContext context)
        {
            this.context = context;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var username = context.HttpContext.User.GetUserName();
            var user = await this.context.Users.FirstOrDefaultAsync(u => u.UserName == username);
            var profile = await this.context.Profiles.FirstOrDefaultAsync(p => p.UserId == user.Id && p.isBaned);
            if (profile != null)
            {
                var date = user.LockoutEnd;
                context.Result = new ContentResult { Content = $"Забанен до { date?.LocalDateTime }", StatusCode = 403 };
            }
            else
            {
                await next();
            }
        }
    }
}
