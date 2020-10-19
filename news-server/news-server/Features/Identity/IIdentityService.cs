using news_server.Data.dbModels;
using System.Threading.Tasks;

namespace news_server.Features.Identity
{
    public interface IIdentityService
    {
        Task<string> Authenticate(User user, string roleName);
    }
}
