using Microsoft.EntityFrameworkCore;
using news_server.Data;
using news_server.Features.Comment;
using news_server.Features.News.Models;
using news_server.Features.StatisticComment;
using news_server.Features.StatisticNews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CNews = news_server.Data.dbModels.News;

namespace news_server.Features.News
{
    public class NewsService : INewsService
    {
        private readonly NewsDbContext context;
        private readonly StatisticNewsService statisticNewsService;
        private readonly ICommentService commentService;

        public NewsService(
            NewsDbContext context, 
            StatisticNewsService statisticNewsService, 
            ICommentService commentService)
        {
            this.context = context;
            this.statisticNewsService = statisticNewsService;
            this.commentService = commentService;
        }
        public async Task<bool> CreateNews(CreateNewsModel model, string userName)
        {
            var titleExist = await context.News.FirstOrDefaultAsync(n => n.Title == model.Title);
            
            if (titleExist == null)
            {
                var profile = await context.Profiles.FirstOrDefaultAsync(p => p.User.UserName == userName);
                var section = await context.SectionsNames.FirstOrDefaultAsync(s => s.SectionName == model.SectionName);
                var now = DateTime.Now;
                if (section != null)
                {
                    await context.News.AddAsync(
                    new CNews
                    {
                        SectionsName = section,
                        Title = model.Title,
                        Photo = model.Photo,
                        Text = model.Text,
                        Owner = profile,                       
                        PublishOn = now
                    });
                    await context.SaveChangesAsync();
                    return true;
                }                
            }
            return false;
        }

        public async Task<IEnumerable<GetNewsModel>> GetNews()
        {
            var news = await Task.Run(() =>
            {
                var count = context.StatisticNews.Where(sn => sn.News.Id == sn.News.Id).Count();

                var news = context.News.Select(n => new GetNewsModel
                {
                    NewsId = n.Id,
                    Photo = n.Photo,
                    Title = n.Title,
                    PublishDate = n.PublishOn,
                    Params = statisticNewsService.GetStatisticById(n.Id) 
                });
                return news;
            });

            return news.ToList();
        }

        public async Task<GetNewsByIdModel> GetNewsById(int newsId)
        {
            var comments = await commentService.GetCommentsByNewsId(newsId);
            var news = await context.News.Where(n => n.Id == newsId).Select(n =>  new GetNewsByIdModel
            { 
                NewsId = n.Id,
                Params = statisticNewsService.GetStatisticById(n.Id),
                PublishDate = n.PublishOn,
                Photo = n.Photo,
                Title = n.Title,
                Text = n.Text,
                Comments = comments            
            }).FirstOrDefaultAsync();
            return news;
        }
    }
}
