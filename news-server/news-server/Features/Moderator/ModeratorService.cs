using Microsoft.EntityFrameworkCore;
using news_server.Data;
using news_server.Features.News.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace news_server.Features.Moderator
{
    public class ModeratorService : IModeratorService
    {
        private readonly NewsDbContext context;

        public ModeratorService(NewsDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> ApprooveNews(int newsId)
        {
            var news = await context.News
                .FirstOrDefaultAsync(n => n.Id == newsId);
            if (!news.isAproove)
            {
                news.isAproove = true;
                news.PublishOn = DateTime.Now;
                context.News.Update(news);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> BanUser(int profileId, int dayCount)
        {
            var profile = await context
                .Profiles
                .FirstOrDefaultAsync(p => p.Id == profileId);

            if (profile == null)
            {
                return false;
            }

            profile.isBaned = true;
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == profile.UserId);           
            var now = DateTime.Now;
            user.LockoutEnd = now.AddDays(dayCount);
            context.Profiles.Update(profile);
            context.Users.Update(user);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<GetNewsBaseModel>> NotApproovedNews()
        {
            var notApproved = await context.News
                .Where(n => !n.isAproove)
                .Select(n => new GetNewsBaseModel
                {
                    NewsId = n.Id,
                    Photo = n.Photo,
                    PublishDate = n.PublishOn,
                    Title = n.Title
                })
                .OrderBy(n => n.PublishDate)
                .ToListAsync();
            return notApproved;
        }
    }
}
