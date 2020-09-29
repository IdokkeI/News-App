using news_server.Features.News.Models;
using System.Threading.Tasks;

namespace news_server.Features.News
{
    public interface INewsService
    {
        Task<bool> CreateNews(CreateNewsModel model, string userName);
    }
}
