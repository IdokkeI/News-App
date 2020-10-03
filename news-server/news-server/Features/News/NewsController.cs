using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using news_server.Features.News.Models;
using news_server.Infrastructure.Extensions;
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
        [HttpPost]
        public async Task<ActionResult> CreateNews(CreateNewsModel model)
        {
            var userName = User.GetUserName();
            var result = await newsService.CreateNews(model, userName);
            if (result)
            {
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}
