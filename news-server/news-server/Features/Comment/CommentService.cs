using Microsoft.EntityFrameworkCore;
using news_server.Data;
using news_server.Features.Comment.Models;
using System;
using System.Threading.Tasks;
using CComment = news_server.Data.dbModels.Comment;

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
            var user = await context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
            var news = await context.News.FirstOrDefaultAsync(nameof => nameof.Id == model.NewsId);

            if (news != null)
            {
                var now = DateTime.Now;
                await context.Comments.AddAsync(new CComment
                {
                    News = news,
                    DateComment = now,
                    Text = model.TextComment,
                    UserOwner = user,
                    UserNameTo = model.UsernameAddresTo                    
                });
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
