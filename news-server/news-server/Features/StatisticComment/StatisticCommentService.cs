using Microsoft.EntityFrameworkCore;
using news_server.Data;
using news_server.Features.SharedStatistic.Models;
using CProfile = news_server.Data.dbModels.Profile;
using CComment = news_server.Data.dbModels.Comment;
using CStatisticComment = news_server.Data.dbModels.StatisticComment;
using System.Threading.Tasks;
using news_server.Features.News.SharedStatistic.Models;
using System.Linq;

namespace news_server.Features.StatisticComment
{
    public class StatisticCommentService : IStatisticService
    {
        private readonly NewsDbContext context;

        public StatisticCommentService(NewsDbContext context)
        {
            this.context = context;
        }

        public async Task<Params> GetStatisticById(int commentId)
        {            
            var listComments = await context
                .StatisticComments
                .Where(sc => sc.Id == commentId)
                .ToListAsync();

            var countLike = await Task.Run ( () =>
                listComments
                    .Where(sc => sc.LikeId != null)
                    .ToList()
                    .Count);

            var countDislike = await Task.Run ( () => 
                listComments
                .Where(sc => sc.DislikeId != null)
                .ToList()
                .Count);

            return new Params
            {
                Dislikes = countDislike,
                Likes = countLike
            };
        }

        public async Task<bool> SetState(int commentId, string username, string state, string link)
        {
            var comment = await context
                .Comments
                .FirstOrDefaultAsync(c => c.Id == commentId);

            if (comment != null)
            {
                var user = await context
                    .Profiles
                    .FirstOrDefaultAsync(p => p.User.UserName == username);

                await SetState(user, comment, state);

                return true;
            }

            return false;
        }

        private async Task SetState(CProfile user, CComment comment, string state)
        {
            var isLike = await context
                .StatisticComments
                .FirstOrDefaultAsync(sc => sc.Like == user && sc.Comment == comment);

            var isDislike = await context
                .StatisticComments
                .FirstOrDefaultAsync(sc => sc.Dislike == user && sc.Comment == comment);

            if (state == "like")
            {
                if (isLike == null)
                {
                    if (isDislike == null)
                    {
                        await context
                            .StatisticComments
                            .AddAsync( new CStatisticComment
                            {
                                Comment = comment,
                                Like = user
                            });
                    }
                    else
                    {
                        isDislike.Dislike = null;
                        isDislike.Like = user;
                        context.StatisticComments.Update(isDislike);                        
                    }
                }
                else
                {
                    context.StatisticComments.Remove(isLike);
                }
            }
            else if (state == "dislike")
            {
                if (isDislike == null)
                {
                    if (isLike == null)
                    {
                        await context.StatisticComments.AddAsync(new CStatisticComment
                        {
                            Comment = comment,
                            Dislike = user
                        });
                    }
                    else
                    {
                        isLike.Like = null;
                        isLike.Dislike = user;
                        context.StatisticComments.Update(isLike);                        
                    }
                }
                else
                {
                    context.StatisticComments.Remove(isDislike);
                }
            }

            await context.SaveChangesAsync();
        }
    }
}
