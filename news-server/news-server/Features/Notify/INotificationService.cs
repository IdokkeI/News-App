using news_server.Features.Notify.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using CProfile = news_server.Data.dbModels.Profile;

namespace news_server.Features.Notify
{
    public interface INotificationService
    {
        public Task<List<GetNotificationsModel>> GetNotifications(string username, int page);
        Task AddNotification(CProfile profileTo, int profileFrom, string text, string link, string alt, int? commentId = null);
    }
}
