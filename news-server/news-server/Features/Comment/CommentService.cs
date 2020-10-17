using Microsoft.EntityFrameworkCore;
using news_server.Data;
using news_server.Data.dbModels;
using news_server.Features.Comment.Models;
using news_server.Features.Notify;
using news_server.Features.StatisticComment;
using news_server.Features.StatisticNews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CProfile = news_server.Data.dbModels.Profile;

namespace news_server.Features.Comment
{
    public class CommentService: ICommentService
    {
        private readonly NewsDbContext context;
        private readonly StatisticCommentService statisticCommentService;
        private readonly StatisticNewsService statisticNewsService;
        private readonly INotificationService notificationService;

        public CommentService(
            NewsDbContext context, 
            StatisticCommentService statisticCommentService,
            StatisticNewsService statisticNewsService,
            INotificationService notificationService)
        {
            this.context = context;
            this.statisticCommentService = statisticCommentService;
            this.statisticNewsService = statisticNewsService;
            this.notificationService = notificationService;
        }

        public async Task<bool> CreateComment(CommentCreateModel model, string userName, string link, int? commentId)
        {
            var userProfile = await context
                .Profiles
                .Include(u => u.User)
                .FirstOrDefaultAsync(p => p.User.UserName == userName);

            var news = await context
                .News
                .FirstOrDefaultAsync(n => n.Id == model.NewsId);

            if (news != null)
            {
                await statisticNewsService.SetState(model.NewsId, userName, "view", string.Empty);

                var now = DateTime.Now;
                await context.Comments.AddAsync(new Data.dbModels.Comment
                {
                    News = news,
                    DateComment = now,
                    Text = model.TextComment,
                    Owner = userProfile,
                    UserNameTo = model.UsernameAddresTo,
                    CommentIdTo = model.CommentIdTo
                });

                if (!string.IsNullOrEmpty(model.UsernameAddresTo))
                {
                    var profileFrom = userProfile.Id;
                    var userFromName = userProfile.User.UserName;

                    var userToId = (await context
                            .Users
                            .FirstOrDefaultAsync(u => u.UserName == model.UsernameAddresTo))
                            ?.Id;

                    var profileTo = await context.Profiles.FirstOrDefaultAsync(p => p.UserId == userToId);

                    if (profileTo != null)
                    {
                        await SetNotificationAsync(profileTo, profileFrom, link, userFromName, commentId);
                    }     
                }                

                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        private async Task SetNotificationAsync(CProfile profileTo, int profileFrom, string link, string userFromName, int? commentId)
        {
            var text = $"Пользователь {userFromName} ответил на ваш";
            var alt = "комментарий";

            await notificationService.AddNotification(profileTo, profileFrom, text, link, alt, commentId);   
        }

        public async Task<List<GetCommentsModel>> GetCommentsByNewsId(int Id)
        {
            var comments = await context
                .Comments
                .Where(c => c.NewsId == Id).Select(c =>            
                    new GetCommentsModel
                    {
                        CommentId = c.Id,
                        UserName = c.Owner.User.UserName,
                        Text = c.Text,
                        DateComment = c.DateComment,
                        isEdit = c.isEdit,
                        UserNameTo = c.UserNameTo,
                        Params = statisticCommentService.GetStatisticById(c.Id)
                    })
                .ToListAsync();
            
            return comments;
        }
    }
}
