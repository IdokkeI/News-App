using Microsoft.AspNetCore.Http;
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
        Task<GetProfileById> GetProfileNewsById(string myUserName, int profileId, int page);
        Task<CProfile> GetSimpleProfileById(int profileId);
        Task<GetProfileById> GetProfileNewsByUserName(string myUserName, string username, int page);
        Task<GetProfileById> GetProfileNewsByUserName(string myUserName, string username);
        string GetUserNameByProfileId(int profileIdSub);
        Task<string> UploadProfileImage(string username, IFormFile image);
        Task SendEmail(string email, string link);
    }
}
