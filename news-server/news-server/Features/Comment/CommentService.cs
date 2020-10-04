using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using news_server.Data;
using news_server.Data.dbModels;
using news_server.Features.Comment.Models;
using news_server.Features.StatisticComment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace news_server.Features.Comment
{
    public class CommentService: ICommentService
    {
        private readonly NewsDbContext context;
        private readonly StatisticCommentService statisticCommentService;

        public CommentService(NewsDbContext context, StatisticCommentService statisticCommentService)
        {
            this.context = context;
            this.statisticCommentService = statisticCommentService;
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

        //public string GetUserName(int ownerId)
        //{
        //    var profile = context.Profiles.FirstOrDefault(p => p.Id == ownerId);
        //    var username = context.Users.FirstOrDefault(u => u.Id == profile.UserId).UserName;
        //    return username;
        //}

        public async Task<List<GetCommentsModel>> GetCommentsByNewsId(int Id)
        {
            var comments = await context.Comments.Where(c => c.NewsId == Id).Select(c =>
            
                new GetCommentsModel
                {
                    CommentId = c.Id,
                    UserName = c.Owner.User.UserName,
                    //UserName = GetUserName(c.OwnerId),
                    Text = c.Text,
                    DateComment = c.DateComment,
                    isEdit = c.isEdit,
                    UserNameTo = c.UserNameTo,
                    Params = statisticCommentService.GetStatisticById(c.Id)
                }).ToListAsync();
            
            return comments;
        }
    }
}
