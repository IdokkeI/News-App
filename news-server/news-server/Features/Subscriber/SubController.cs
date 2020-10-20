using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using news_server.Features.Subscriber.Model;
using news_server.Infrastructure.Extensions;
using news_server.Infrastructure.Filter;
using System.Threading.Tasks;

namespace news_server.Features.Subscriber
{
    [Authorize]
    public class SubController : ApiController
    {
        private readonly ISubService subService;

        public SubController(ISubService subService)
        {
            this.subService = subService;
        }

        
        [HttpPost(nameof(SubscribeState))]
        [ServiceFilter(typeof(BanFilter))]
        public async Task<ActionResult> SubscribeState(SubModel model)
        {
            var username = User.GetUserName();

            string link = Url
                    .Action(
                        "GetProfileByUserName",
                        "Profile",
                        new { username = username },
                     protocol: HttpContext.Request.Scheme);

            var result = await subService.SubState(model.SubTo, username, model.State, link);

            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
        
        
        [HttpPost(nameof(GetSubscribersById))]
        public async Task<ActionResult> GetSubscribersById(GetSubscribersByIdModel model)
        {
            var result = await subService.GetSubscribers(model.ProfileId, model.Page);
            return Ok(result);
        }
    }
}
