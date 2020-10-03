using Microsoft.EntityFrameworkCore;
using news_server.Data;
using news_server.Features.Comment.Models;
using System;
using System.Threading.Tasks;

namespace news_server.Features.Comment
{
    public class CommentService: ICommentService
    {
        private readonly NewsDbContext context;

        public CommentService(NewsDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> CreateComment(CommentCreateModel model, string userName)
        {
            var userProfile = await context.Profiles.FirstOrDefaultAsync(p => p.User.UserName == userName);
            var news = await context.News.FirstOrDefaultAsync(nameof => nameof.Id == model.NewsId);

            if (news != null)
            {
                var now = DateTime.Now;
                await context.Comments.AddAsync(new Data.dbModels.Comment
                {
                    News = news,
                    DateComment = now,
                    Text = model.TextComment,
                    Owner = userProfile,
                    UserNameTo = model.UsernameAddresTo                    
                });
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
