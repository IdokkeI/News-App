using news_server.Features.News.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace news_server.Features.News
{
    public interface INewsService
    {
        Task<List<GetNewsModelWithStates>> GetMyNews(string username, int page);
        Task<List<GetNewsModelWithStates>> GetProfileNews(string username, int profileId, int page);
        Task<List<GetNewsModelWithStates>> GetProfileNews(string username, int profileId);
        Task<bool> CreateNews(CreateNewsModel model, string userName);
        Task<IEnumerable<GetNewsModel>> GetNews(string username, int page);
        Task<GetNewsByIdWithOwnerNameModel> GetNewsById(int newsId);
        Task<bool> EditNews(EditNewsModel model, string userName);        
        Task<IEnumerable<GetNewsModel>> GetInterestingNews(string username, int page);
        Task<List<GetNewsModelWithStates>> FindNews(string username, string text, int page);
        Task<List<GetNewsModelWithStates>> SortingNewsWithStates(List<GetNewsModelWithStates> news, string username, int page);
    }
}
