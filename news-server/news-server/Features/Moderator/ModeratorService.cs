using Microsoft.EntityFrameworkCore;
using news_server.Data;
using news_server.Data.dbModels;
using news_server.Features.News.Models;
using news_server.Features.Notify;
using news_server.Features.Profile;
using news_server.Features.Subscriber;
using news_server.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CNews = news_server.Data.dbModels.News;
using CProfile = news_server.Data.dbModels.Profile;

namespace news_server.Features.Moderator
{
    public class ModeratorService : IModeratorService
    {
        private readonly NewsDbContext context;
        private readonly INotificationService notificationService;
        private readonly ISubService subService;
        private readonly IProfileService profileService;

        public ModeratorService(
            NewsDbContext context,
            INotificationService notificationService,
            ISubService subService,
            IProfileService profileService)
        {
            this.context = context;
            this.notificationService = notificationService;
            this.subService = subService;
            this.profileService = profileService;
        }

        public async Task<bool> ApprooveNews(int newsId, string link)
        {
            var news = await context.News
                .Include(n => n.Owner)
                .Include(n => n.Owner.User)
                .FirstOrDefaultAsync(n => n.Id == newsId);
            if (!news.isAproove)
            {
                news.isAproove = true;
                news.PublishOn = DateTime.Now;
                var isModifyed = news.isModifyed;
                news.isModifyed = false;
                context.News.Update(news);
                                
                await SetNotificationAsync(news, link, isModifyed);

                await context.SaveChangesAsync();

                return true;
            }
            return false;
        }

        private async Task SetNotificationAsync(CNews news, string link, bool isModifyed = false)
        {
            string text;
            if (isModifyed)
            {
                text = $"Ваша <alt> обновлена";
            }
            else
            {
                text = $"Ваша <alt> опубликована";
            }

            var profileTo = news.Owner;
            var profileFrom = -1;            
            string alt = "статья";            

            await notificationService.AddNotification(profileTo, profileFrom, text, link, alt);

            await NoticeSubs(profileTo, link, isModifyed);
            
        }

        private async Task NoticeSubs(CProfile profileFrom, string link, bool isModifyed = false)
        {
            string text;
            if (isModifyed)
            {
                text = $"Пользователь {profileFrom.User.UserName} обновил <alt>";
            }
            else
            {
                text = $"Пользователь {profileFrom.User.UserName} опубликовал <alt>";
            }

            var subs = await subService.GetSubscribers(profileFrom.Id);            
            var alt = "статью";

            List<Notification> notifications = new List<Notification>();

            subs
                .ForEach(sub => 
                {
                    var profileTo = profileService.GetSimpleProfileById(sub.ProfileID);
                    
                    var notification = new Notification
                    {
                        NotificationDate = DateTime.Now,
                        ProfileIdFrom = profileFrom.Id,
                        Profile = profileTo.Result,
                        NotificationText = text,
                        Url = link,
                        Alt = alt,
                        CommentId = null
                    };
                    notifications.Add(notification);
                });

            await context.Notifications.AddRangeAsync(notifications);
            await context.SaveChangesAsync();
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

        public async Task<List<GetNewsBaseModel>> NotApproovedNews(int page)
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
                .Skip(page * 20 - 20)
                .Take(20)
                .ToListAsync();
            return notApproved;
        }

        public async Task<List<GetUserPmodel>> GetBanUsers(int page)
        {
            var banUsers = await context
                .Profiles
                .Include(p => p.User)
                .Where(p => p.isBaned)
                .Select(p => new GetUserPmodel
                {
                    ProfileID = p.Id,
                    UserName = p.User.UserName
                })
                .OrderBy(p => p.UserName)
                .Skip(page * 20 - 20)
                .Take(20)
                .ToListAsync();

            return banUsers;
        }
    }
}
