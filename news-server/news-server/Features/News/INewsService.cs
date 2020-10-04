using news_server.Features.News.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace news_server.Features.News
{
    public interface INewsService
    {
        Task<bool> CreateNews(CreateNewsModel model, string userName);
        Task<IEnumerable<GetNewsModel>> GetNews();
    }
}
