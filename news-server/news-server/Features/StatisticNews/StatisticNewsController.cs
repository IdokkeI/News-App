using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using news_server.Features.SharedStatistic.Models;
using news_server.Features.StatisticNews.Models;
using news_server.Infrastructure.Extensions;
using news_server.Infrastructure.Filter;
using System.Threading.Tasks;

namespace news_server.Features.StatisticNews
{
    [Authorize]
    public class StatisticNewsController: ApiController
    {
        private readonly IStatisticService StatisticNewsService;

        public StatisticNewsController(StatisticNewsService StatisticNewsService)
        {
            this.StatisticNewsService = StatisticNewsService;
        }

        [HttpPost(nameof(SetState))]
        [ServiceFilter(typeof(BanFilter))]
        public async Task<ActionResult> SetState(StatisticModel model)
        {
            var username = User.GetUserName();
            var result = await StatisticNewsService.SetState(model.ObjectId, username, model.State);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        
    }
}
