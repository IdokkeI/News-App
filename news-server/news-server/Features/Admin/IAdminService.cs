using news_server.Features.Admin.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace news_server.Features.Admin
{
    public interface IAdminService
    {
        Task<bool> SetModerator(string username);
        Task<List<GetUser>> GetModerators(int page);
        Task<List<GetUser>> GetUsers(int page);
        Task<bool> DemoteModerator(string username);
    }
}
