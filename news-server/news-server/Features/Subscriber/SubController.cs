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
            if (model.State == "sub" || model.State == "unsub")
            {
                var username = User.GetUserName();

                string link = username;
                    //Url
                    //    .Action(
                    //        "GetProfileNewsByUserName",
                    //        "Profile",
                    //        new { username = username },
                    //     protocol: HttpContext.Request.Scheme);

                var result = await subService.SubState(model.SubTo, username, model.State, link);

                if (result)
                {
                    return Ok();
                }
            }
            
            return BadRequest();
        }
        
        
        [HttpGet(nameof(GetMySubscribers))]
        public async Task<ActionResult> GetMySubscribers(int page = 1)
        {
            var username = User.GetUserName();
            var result = await subService.GetMySubscribers(username, page);
            return Ok(result);
        }

        [HttpPost(nameof(GetSubscribersById))]
        public async Task<ActionResult> GetSubscribersById(GetSubscribersByIdModel model)
        {
            var result = await subService.GetSubscribers(model.ProfileId, model.Page);
            return Ok(result);
        }
    }
}
