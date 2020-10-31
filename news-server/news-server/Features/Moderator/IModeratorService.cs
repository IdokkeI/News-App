using news_server.Features.News.Models;
using news_server.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace news_server.Features.Moderator
{
    public interface IModeratorService
    {
        Task<List<GetNewsBaseModel>> NotApproovedNews(int page);
        Task<bool> ApprooveNews(int newsId, string link);
        Task<List<GetUserPmodel>> GetBanUsers(int page);
        Task<bool> BanUser(string userName, int dayCount);
        Task<GetNewsByIdWithOwnerNameModel> GetNotAprooveNewById(int newsId);
    }
}
