using Microsoft.EntityFrameworkCore;
using news_server.Data;
using System.Threading.Tasks;
using CStatisticNews = news_server.Data.dbModels.StatisticNews;
using CProfile = news_server.Data.dbModels.Profile;
using CNews = news_server.Data.dbModels.News;
using news_server.Features.SharedStatistic.Models;
using System.Linq;
using news_server.Features.Notify;
using news_server.Features.Profile.Models;
using System.Collections.Generic;

namespace news_server.Features.StatisticNews
{
    public class StatisticNewsService : IStatisticService
    {
        private readonly NewsDbContext context;
        private readonly INotificationService notificationService;

        public StatisticNewsService(NewsDbContext context, INotificationService notificationService)
        {
            this.context = context;
            this.notificationService = notificationService;
        }

        public LocalState LocalStateNews(int newsId, string username)
        {
            if (username == null)
            {
                return new LocalState
                {
                    IsLike = false,
                    IsDislike = false
                };
            }

            var profile = context
                .Profiles
                .Include(p => p.User)
                .FirstOrDefault(p => p.User.UserName == username);

            var Like = context
                .StatisticNews
                .Include(sc => sc.News)
                .Include(sc => sc.Like)
                .FirstOrDefault(sc => sc.News.Id == newsId && sc.Like == profile);

            var DisLike = context
                .StatisticComments
                .Include(sc => sc.Comment)
                .Include(sc => sc.Dislike)
                .FirstOrDefault(sc => sc.Comment.Id == newsId && sc.Dislike == profile);

            bool isLike = Like == null ? false : true; ;
            bool isDisLike = DisLike == null ? false : true; ;

            return new LocalState
            {
                IsLike = isLike,
                IsDislike = isDisLike
            };
        }

        public async Task<bool> SetState(
            int newsId, 
            string username, 
            string state,  
            string link)
        {
            var news = await context
                .News
                .Include(n => n.Owner)
                .FirstOrDefaultAsync(n => n.Id == newsId);

            if (news != null )
            {
                var user = await context
                    .Profiles
                    .FirstOrDefaultAsync(p => p.User.UserName == username);
                               
                await SetState(user, news, state, link);
               
                return true;
            }
            return false;
        }

        public Params GetStatisticById(int newsId)
        {
            var countViews =context
                .StatisticNews
                .Where(sn => sn.NewsId == newsId)
                .ToList()
                .Count;

            var listviews = context
                .StatisticNews
                .Where(sn => sn.NewsId == newsId)
                .ToList();

            var countLike = listviews
                    .Where(sn => sn.LikeId != null)
                    .ToList()
                    .Count;

            var countDislike = listviews
                    .Where(sn => sn.DislikeId != null)
                    .ToList()
                    .Count;

            return new Params 
            { 
                Dislikes = countDislike, 
                Likes = countLike, 
                Views = countViews 
            };
        }

        private async Task SetState(
            CProfile user, 
            CNews news, 
            string state,
            string link)
        {
            var isLike = await context
                .StatisticNews
                .FirstOrDefaultAsync(sn => sn.Like == user && sn.News == news);

            var isDislike = await context
                .StatisticNews
                .FirstOrDefaultAsync(sn => sn.Dislike == user && sn.News == news);

            var isViews = await context
                .StatisticNews
                .FirstOrDefaultAsync(sn => sn.ViewBy == user && sn.News == news);

            if (state == "like")
            {                
                if (isLike == null)
                {
                    if (isDislike == null)
                    {
                        if (isViews == null)
                        {
                            await context
                                .StatisticNews
                                .AddAsync(new CStatisticNews
                                {
                                    News = news,
                                    Like = user,
                                    ViewBy = user,
                                    IsNotifyed = true
                                });

                            if (user.Id != news.Owner.Id)
                            {
                                await SetNotificationAsync(user, news, link);
                            }                                                                                  
                        }
                        else
                        {
                            if (!isViews.IsNotifyed && user.Id != news.Owner.Id)
                            {
                                await SetNotificationAsync(user, news, link);
                                isViews.IsNotifyed = true;
                            }
                            
                            isViews.Like = user;
                            context.StatisticNews.Update(isViews);
                        }                        
                    }
                    else
                    {
                        if (!isDislike.IsNotifyed && user.Id != news.Owner.Id)
                        {
                            await SetNotificationAsync(user, news, link);
                            isDislike.IsNotifyed = true;
                        }
                        
                        isDislike.Dislike = null;
                        isDislike.Like = user;
                        context.StatisticNews.Update(isDislike);                        
                    }                    
                }
                else
                {
                    isLike.Like = null;
                    context.StatisticNews.Update(isLike);
                }
            }
            else if (state == "dislike")
            {
                if (isDislike == null)
                {
                    if (isLike == null)
                    {
                        if (isViews == null)
                        {
                            await context
                                .StatisticNews
                                .AddAsync(new CStatisticNews
                                {
                                    News = news,
                                    Dislike = user,
                                    ViewBy = user
                                });
                        }
                        else
                        {
                            isViews.Dislike = user;
                            context.StatisticNews.Update(isViews);
                        }                        
                    }
                    else
                    {
                        isLike.Like = null;
                        isLike.Dislike = user;
                        context.StatisticNews.Update(isLike);                        
                    }
                }
                else
                {
                    isDislike.Dislike = null;
                    context.StatisticNews.Update(isDislike);
                }
            }
            else if (state == "view")
            {
                if (isViews == null)
                {
                    await context
                        .StatisticNews
                        .AddAsync(new CStatisticNews
                        {
                            News = news,
                            Like = null,
                            ViewBy = user
                        });
                }
            }
            await context.SaveChangesAsync();
        }


        private async Task SetNotificationAsync(CProfile user, CNews news, string link)
        {
            var profileFromName = user.User.UserName;
            var profilFrom = user.Id;
            var profileTo = news.Owner;
            var text = $"Пользователь {profileFromName} оценил вашу";
            var alt = "статью";

            await notificationService.AddNotification(profileTo, profilFrom, text, link, alt);
        }

        public async Task<List<BestPublishersModels>> BestPublishers()
        {
            var publishers = await context
                .StatisticNews
                .Include(sn => sn.News)
                .Include(sn => sn.News.Owner)
                .Include(sn => sn.News.Owner.User)
                .Where(sn => sn.Like != null)
                .GroupBy(
                    key => key.News.Owner.User.UserName,
                    value => value.ViewBy,
                    (k, v) => new BestPublishersModels
                    {
                        UserName = k,
                        Statistic = v.Count()
                    })
                .ToListAsync();

            return publishers;
        }
    }
}
