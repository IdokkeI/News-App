using news_server.Features.News.Models;
using news_server.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace news_server.Features.Moderator
{
    public interface IModeratorService
    {
        Task<List<GetNewsBaseModel>> NotApproovedNews();
        Task<bool> ApprooveNews(int newsId, string link);
        Task<List<GetUserPmodel>> GetBanUsers();
        Task<bool> BanUser(int profileId, int dayCount);       

    }
}
