using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using news_server.Features.News.Models;
using news_server.Features.StatisticNews;
using news_server.Infrastructure.Extensions;
using news_server.Infrastructure.Filter;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace news_server.Features.News
{
    
    public class NewsController: ApiController
    {
        private readonly INewsService newsService;
        private readonly StatisticNewsService statisticNewsService;

        public NewsController(
            INewsService newsService,
            StatisticNewsService statisticNewsService)
        {
            this.newsService = newsService;
            this.statisticNewsService = statisticNewsService;
        }

        [Authorize]
        [HttpPost(nameof(CreateNews))]
        [ServiceFilter(typeof(BanFilter))]
        public async Task<ActionResult> CreateNews(CreateNewsModel model)
        {
            if (ModelState.IsValid)
            {
                var userName = User.GetUserName();
                var result = await newsService.CreateNews(model, userName);

                if (result)
                {
                    return Ok();
                }

                ModelState.AddModelError("errors", "Заголовок используется");
            }            
           
            return BadRequest(ModelState);
        }

        [Produces("application/json")]
        [HttpGet(nameof(GetNews))]
        public async Task<IEnumerable<GetNewsModel>> GetNews()
        {
            var news = await newsService.GetNews();
            return news;
        }

        [Produces("application/json")]
        [HttpGet(nameof(GetNewsById))]
        public async Task<ActionResult> GetNewsById(int newsId)
        {
            var news = await newsService.GetNewsById(newsId);

            if (news != null)
            {
                if (!string.IsNullOrEmpty(User.GetUserName()))
                {
                    var username = User.GetUserName();
                    await statisticNewsService.SetState(newsId, username, "view", string.Empty);
                }
                return Ok(news);
            }
            return NotFound();
        }

         public async Task<ActionResult> EditNews(EditNewsModel model)
        {
            var username = User.GetUserName();
            var result = await newsService.EditNews(model, username);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
