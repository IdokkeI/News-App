using news_server.Features.News.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using news_server.Shared.Models;

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
