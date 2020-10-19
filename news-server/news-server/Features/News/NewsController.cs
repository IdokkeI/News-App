using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using news_server.Features.Comment.Models;
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


        [HttpGet(nameof(GetNews))]
        public async Task<IEnumerable<GetNewsModel>> GetNews(int page = 1)
        {
            var news = await newsService.GetNews(page);
            return news;
        }

        [HttpGet(nameof(GetMyNews))]
        public async Task<IEnumerable<GetNewsModel>> GetMyNews(int page = 1)
        {
            var username = User.GetUserName();
            var news = await newsService.GetMyNews(username, page);
            return news;
        }


        [HttpPost(nameof(GetNewsById))]
        public async Task<ActionResult> GetNewsById(GetCommentsByNewsIdReqModel model)
        {
            var news = await newsService.GetNewsById(model.NewsId, model.Page);

            if (news != null)
            {
                if (!string.IsNullOrEmpty(User.GetUserName()))
                {
                    var username = User.GetUserName();
                    await statisticNewsService.SetState(model.NewsId, username, "view", string.Empty);
                }
                return Ok(news);
            }
            return NotFound();
        }

        [Authorize]
        [HttpGet(nameof(GetInterestingNews))]
        public async Task<ActionResult> GetInterestingNews(int page)
        {
            var username = User.GetUserName();
            var result = await newsService.GetInterestingNews(username, page);
            return Ok(result);
        }


        [Authorize]
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
