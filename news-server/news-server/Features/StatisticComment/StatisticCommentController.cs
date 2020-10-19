using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using news_server.Features.SharedStatistic.Models;
using news_server.Features.StatisticNews.Models;
using news_server.Infrastructure.Extensions;
using news_server.Infrastructure.Filter;
using System.Threading.Tasks;

namespace news_server.Features.StatisticComment
{
    [Authorize]
    public class StatisticCommentController: ApiController
    {
        private readonly IStatisticService commentService;

        public StatisticCommentController(StatisticCommentService commentService)
        {
            this.commentService = commentService;
        }


        [HttpPost(nameof(SetState))]
        [ServiceFilter(typeof(BanFilter))]
        public async Task<ActionResult> SetState(StatisticModel model)
        {
            var username = User.GetUserName();

            var result = await commentService.SetState(model.ObjectId, username, model.State, string.Empty);

            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

    }
}
