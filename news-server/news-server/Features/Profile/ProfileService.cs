using Microsoft.EntityFrameworkCore;
using news_server.Data;
using CProfile = news_server.Data.dbModels.Profile;
using news_server.Features.News;
using news_server.Features.Profile.Models;
using news_server.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace news_server.Features.Profile
{
    public class ProfileService : IProfileService
    {
        private readonly NewsDbContext context;
        private readonly INewsService newsService;

        public ProfileService(NewsDbContext context, INewsService newsService)
        {
            this.context = context;
            this.newsService = newsService;
        }


        public async Task<List<GetUserPmodel>> GetProfilesExceptName(string username, int page)
        {
            var result = await context
                .Profiles
                .Include(p => p.User)
                .Where(p => !p.isBaned && p.User.UserName != username)
                .Select(p => new GetUserPmodel
                {
                    ProfileID = p.Id,
                    UserName = p.User.UserName
                })
                .OrderBy(p => p.UserName)
                .Skip(page * 20 - 20)
                .Take(20)
                .ToListAsync();

            return result;
        }


        public async Task<CProfile> GetSimpleProfileById(int profileId)
        {
            var result = await context
                .Profiles
                .FirstOrDefaultAsync(p => p.Id == profileId);

            return result;
        }


        public string GetUserNameByProfileId(int profileIdSub)
        {
            var username = context
                .Profiles
                .Include(p => p.User)
                .FirstOrDefault(p => p.Id == profileIdSub)?.User.UserName;

            return username;
        }


        public async Task<GetProfileById> GetProfileByUserName(string username, int page)
        {
            var result = await context
              .Subscriptions
              .Include(s => s.Profile)
              .Include(s => s.Profile.User)
              .Where(s => s.Profile.User.UserName == username)
              .Select(s => new GetProfileById
              {
                  ProfileId = s.ProfileId,
                  UserName = s.Profile.User.UserName,
                  UserNews = newsService.GetProfileNews(s.ProfileId, page)
              })              
              .FirstOrDefaultAsync();

            return result;
        }

        
        public async Task<GetProfileById> GetProfileByUserName(string username)
        {
            var result = await context
              .Subscriptions
              .Include(s => s.Profile)
              .Include(s => s.Profile.User)
              .Where(s => s.Profile.User.UserName == username)
              .Select(s => new GetProfileById
              {
                  ProfileId = s.ProfileId,
                  UserName = s.Profile.User.UserName,
                  UserNews = newsService.GetProfileNews(s.ProfileId)
              })
              .FirstOrDefaultAsync();

            return result;
        }


        public async Task<GetProfileById> GetProfileById(int profileId, int page)
        {
            var result = await context
                .Subscriptions
                .Include(s => s.Profile)
                .Include(s => s.Profile.User)
                .Where(s => s.ProfileId == profileId)
                .Select(s => new GetProfileById 
                { 
                    ProfileId = s.ProfileId,
                    UserName = s.Profile.User.UserName,
                    UserNews = newsService.GetProfileNews(s.ProfileId, page)
                })
                .FirstOrDefaultAsync();

            return result;
        }
    }
}
