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
    [Authorize]
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
            }    
            return BadRequest();
        }


        [AllowAnonymous]
        [HttpGet(nameof(GetNews))]
        public async Task<IEnumerable<GetNewsModel>> GetNews(int page = 1)
        {
            var username = User.GetUserName();

            var news = await newsService.GetNews(username, page);
            return news;
        }

        [Authorize(Roles = "moderator, user")]
        [HttpGet(nameof(GetMyNews))]
        public async Task<IEnumerable<GetNewsModel>> GetMyNews(int page = 1)
        {
            var username = User.GetUserName();
            var news = await newsService.GetMyNews(username, page);
            return news;
        }


        [AllowAnonymous]
        [HttpPost(nameof(FindNews))]
        public async Task<ActionResult> FindNews(FindNewsModel model)
        {
            if (ModelState.IsValid)
            {
                var username = User.GetUserName();
                var news = await newsService.FindNews(username, model.Text, model.Page);
                return Ok(news);
            }
            return BadRequest(ModelState);
        }


        [AllowAnonymous]
        [HttpGet(nameof(GetNewsById))]
        public async Task<ActionResult> GetNewsById(int newsId)
        {
            var news = await newsService.GetNewsById(newsId);

            if (news != null)
            {                
                var username = User.GetUserName();
                if (username != null)
                {
                    await statisticNewsService.SetState(newsId, username, "view", string.Empty);
                }
                
                return Ok(news);
            }
            return NotFound();
        }


        [HttpGet(nameof(GetInterestingNews))]
        public async Task<ActionResult> GetInterestingNews(int page = 1)
        {
            var username = User.GetUserName();
            var result = await newsService.GetInterestingNews(username, page);
            return Ok(result);
        }


        [HttpPut(nameof(EditNews))]
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
