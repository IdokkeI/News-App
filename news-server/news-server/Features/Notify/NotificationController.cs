using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using news_server.Infrastructure.Extensions;
using news_server.Infrastructure.Filter;
using System.Threading.Tasks;

namespace news_server.Features.Notify
{
    [Authorize]
    public class NotificationController: ApiController
    {
        private readonly INotificationService notificationService;

        public NotificationController(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        [HttpGet]
        [ServiceFilter(typeof(BanFilter))]
        public async Task<ActionResult> GetNotifications()
        {
            var username = User.GetUserName();

            var result = await notificationService
                .GetNotifications(username);

            return Ok(result);
            
        }
    }
}
