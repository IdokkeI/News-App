using news_server.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace news_server.Features.Subscriber
{
    public interface ISubService
    {
        Task<bool> SubState(int SubTo, string username, string state, string link = null);
        Task<List<GetUserPmodel>> GetSubscribers(int profileId);
        
    }
}
