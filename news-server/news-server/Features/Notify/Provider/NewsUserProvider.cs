using Microsoft.AspNetCore.SignalR;

namespace news_server.Features.Notify.Provider
{
    public class NewsUserProvider : IUserIdProvider
    {
        public string GetUserId(HubConnectionContext connection)
        {
            return connection.User.Identity.Name;
        }
    }
}
