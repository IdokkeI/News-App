using Microsoft.EntityFrameworkCore;
using news_server.Data;
using System.Threading.Tasks;
using CStatisticNews = news_server.Data.dbModels.StatisticNews;
using CProfile = news_server.Data.dbModels.Profile;
using CNews = news_server.Data.dbModels.News;
using news_server.Features.SharedStatistic.Models;
using System.Linq;
using news_server.Features.News.SharedStatistic.Models;

namespace news_server.Features.StatisticNews
{
    public class StatisticNewsService : IStatisticService
    {
        private readonly NewsDbContext context;

        public StatisticNewsService(NewsDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> SetState(int newsId, string username, string state)
        {
            var news = await context.News.FirstOrDefaultAsync(n => n.Id == newsId);
            if (news != null )
            {
                var user = await context.Profiles.FirstOrDefaultAsync(p => p.User.UserName == username);
                               
                await SetState(user, news, state);
               
                return true;
            }

            return false;
        }

        public Params GetStatisticById(int newsId)
        {
            var countViews = context.StatisticNews.Where(sn => sn.NewsId == newsId).ToList().Count;
            var listviews = context.StatisticNews.Where(sn => sn.NewsId == newsId).ToList();
            var countLike = listviews.Where(sn => sn.LikeId != null).ToList().Count;
            var countDislike = listviews.Where(sn => sn.DislikeId != null).ToList().Count;
            return new Params 
                { 
                    Dislikes = countDislike, 
                    Likes = countLike, 
                    Views = countViews 
                };
        }

        private async Task SetState(CProfile user, CNews news, string state)
        {
            var isLike = await context.StatisticNews.FirstOrDefaultAsync(sn => sn.Like == user && sn.News == news);
            var isDislike = await context.StatisticNews.FirstOrDefaultAsync(sn => sn.Dislike == user && sn.News == news);
            var isViews = await context.StatisticNews.FirstOrDefaultAsync(sn => sn.ViewBy == user && sn.News == news);

            if (state == "like")
            {                
                if (isLike == null)
                {
                    if (isDislike == null)
                    {
                        if (isViews == null)
                        {
                            await context.StatisticNews.AddAsync(new CStatisticNews
                            {
                                News = news,
                                Like = user,
                                ViewBy = user
                            });
                        }
                        else
                        {                            
                            isViews.Like = user;
                            context.StatisticNews.Update(isViews);
                        }
                        
                    }
                    else
                    {
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
                            await context.StatisticNews.AddAsync(new CStatisticNews
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

            await context.SaveChangesAsync();
        }
    }
}
