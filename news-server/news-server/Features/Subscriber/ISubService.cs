using System.Globalization;
using System.Threading.Tasks;

namespace news_server.Features.Subscriber
{
    public interface ISubService
    {
        Task<bool> SubState(int SubTo, string username, string state);
    }
}
