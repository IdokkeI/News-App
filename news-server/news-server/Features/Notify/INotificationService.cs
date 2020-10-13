using news_server.Data.dbModels;
using news_server.Features.Notify.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace news_server.Features.Notify
{
    public interface INotificationService
    {
        public Task<List<GetNotificationsModel>> GetNotifications(string username);
        Task AddNotification(Profile profileTo, int profileFrom, string text, string link, string alt, int? commentId = null);
    }
}
