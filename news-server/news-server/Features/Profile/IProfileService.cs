using news_server.Features.Profile.Models;
using news_server.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using CProfile = news_server.Data.dbModels.Profile;

namespace news_server.Features.Profile
{
    public interface IProfileService
    {
        Task<List<GetUserPmodel>> GetProfilesExceptName(string username, int page);        
        Task<GetProfileById> GetProfileById(int profileId, int page);
        Task<CProfile> GetSimpleProfileById(int profileId);
        Task<GetProfileById> GetProfileByUserName(string username, int page);
        Task<GetProfileById> GetProfileByUserName(string username);
        string GetUserNameByProfileId(int profileIdSub);
    }
}
