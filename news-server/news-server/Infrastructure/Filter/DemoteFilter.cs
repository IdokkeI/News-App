using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using news_server.Data.dbModels;
using news_server.Infrastructure.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace news_server.Infrastructure.Filter
{
    public class DemoteFilter : Attribute, IAsyncActionFilter
    {
        private readonly UserManager<User> userManager;

        public DemoteFilter(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                string username = context.HttpContext.User.GetUserName();
                var user = await userManager.FindByNameAsync(username);
                var role = (await userManager.GetRolesAsync(user)).FirstOrDefault();

                var isInRole = context.HttpContext.User.IsInRole(role);
                if (!isInRole)
                {
                    context.Result = new StatusCodeResult(401);
                }                
            }
            await next();
        }
    }
}
