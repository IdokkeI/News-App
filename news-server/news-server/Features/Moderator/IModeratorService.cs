using news_server.Features.News.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace news_server.Features.Moderator
{
    public interface IModeratorService
    {
        Task<List<GetNewsBaseModel>> NotApproovedNews();
        Task<bool> ApprooveNews(int newsId);
        Task<bool> BanUser(int profileId, int dayCount);
    }
}
