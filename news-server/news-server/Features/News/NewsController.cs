using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using news_server.Features.News.Models;
using news_server.Infrastructure.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace news_server.Features.News
{
    
    public class NewsController: ApiController
    {
        private readonly INewsService newsService;

        public NewsController(INewsService newsService)
        {
            this.newsService = newsService;
        }

        [Authorize]
        [HttpPost(nameof(CreateNews))]
        public async Task<ActionResult> CreateNews(CreateNewsModel model)
        {
            var userName = User.GetUserName();
            var result = await newsService.CreateNews(model, userName);
            if (result)
            {
                return Ok();
            }
            if (ModelState.Count == 0)
            {
                ModelState.AddModelError("duplicate", "Заголовок используется");
                return BadRequest(ModelState);
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
    }
}
