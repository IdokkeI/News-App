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


        [HttpGet(nameof(GetNotifications))]
        [ServiceFilter(typeof(BanFilter))]
        public async Task<ActionResult> GetNotifications(int page)
        {
            var username = User.GetUserName();

            var result = await notificationService
                .GetNotifications(username, page);

            return Ok(result);
            
        }
        
        [HttpGet(nameof(Viewed))]
        [ServiceFilter(typeof(BanFilter))]
        public async Task<ActionResult> Viewed(int notificationId)
        {
            var username = User.GetUserName();

            await notificationService.Viewed(username, notificationId);

            return Ok();
            
        }
    }
}
