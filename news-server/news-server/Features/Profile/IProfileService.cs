using news_server.Features.Profile.Models;
using news_server.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace news_server.Features.Profile
{
    public interface IProfileService
    {
        Task<List<GetUserPmodel>> GetProfileByName(string username);
        Task<GetProfileById> GetProfileById(int profileId);
    }
}
