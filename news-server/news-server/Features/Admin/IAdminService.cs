using news_server.Features.Admin.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace news_server.Features.Admin
{
    public interface IAdminService
    {
        Task<bool> SetModerator(string username);
        Task<List<GetUser>> GetModerators();
        Task<bool> DemoteModerator(string username);
        Task<List<GetUser>> GetUsers();
    }
}
