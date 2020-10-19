using Microsoft.EntityFrameworkCore;
using news_server.Data;
using news_server.Features.Comment;
using news_server.Features.News.Models;
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
                

        public List<GetNewsModel> GetProfileNews(int profileId, int page)
        {
            var result = context
                    .News
                    .Include(n => n.Owner)
                    .Where(n => n.Owner.Id == profileId)
                    .Select(n => new GetNewsModel
                    {
                        NewsId = n.Id,
                        Photo = n.Photo,
                        Title = n.Title,
                        PublishDate = n.PublishOn,
                        Params = statisticNewsService.GetStatisticById(n.Id)
                    })
                    .OrderBy(n => n.PublishDate)
                    .OrderBy(n => n.Params.Views)
                    .OrderBy(n => n.Params.Likes)
                    .Skip(page * 20 - 20)
                    .Take(20)
                    .ToList();
            return result;
        }
        

        public List<GetNewsModel> GetProfileNews(int profileId)
        {
            var result = context
                    .News
                    .Include(n => n.Owner)
                    .Where(n => n.Owner.Id == profileId)
                    .Select(n => new GetNewsModel
                    {
                        NewsId = n.Id,
                        Photo = n.Photo,
                        Title = n.Title,
                        PublishDate = n.PublishOn,
                        Params = statisticNewsService.GetStatisticById(n.Id)
                    })
                    .ToList();

            return result;
        }


        public async Task<bool> CreateNews(CreateNewsModel model, string userName)
        {
            var titleExist = await context
                .News
                .FirstOrDefaultAsync(n => n.Title == model.Title);
            
            if (titleExist == null)
            {
                var profile = await context
                    .Profiles
                    .FirstOrDefaultAsync(p => p.User.UserName == userName);

                var section = await context
                    .SectionsNames
                    .FirstOrDefaultAsync(s => s.SectionName == model.SectionName);

                var now = DateTime.Now;

                if (section != null)
                {
                    await context
                        .News
                        .AddAsync( new CNews
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


        public async Task<IEnumerable<GetNewsModel>> GetNews(int page)
        {           
            var news = await context
                .News
                .Where(n => n.isAproove)
                .Select(n => new GetNewsModel
                {
                    NewsId = n.Id,
                    Photo = n.Photo,
                    Title = n.Title,
                    PublishDate = n.PublishOn,
                    Params = statisticNewsService.GetStatisticById(n.Id) 
                })
                .OrderBy(n => n.PublishDate)
                .OrderBy(n => n.Params.Views)
                .OrderBy(n => n.Params.Likes)
                .Skip(page * 20 - 20)
                .Take(20)
                .ToListAsync();
            return news;            
        }


        public async Task<GetNewsByIdModel> GetNewsById(int newsId, int page)
        {
            var comments = await commentService.GetCommentsByNewsId(newsId, page);

            var news = await context
                .News
                .Where(n => n.Id == newsId && n.isAproove)
                .Select(n =>  new GetNewsByIdModel
                { 
                    NewsId = n.Id,
                    Params = statisticNewsService.GetStatisticById(n.Id),
                    PublishDate = n.PublishOn,
                    Photo = n.Photo,
                    Title = n.Title,
                    Text = n.Text,
                    Comments = comments            
                })                
                .FirstOrDefaultAsync();

            return news;
        }


        public async Task<bool> EditNews(EditNewsModel model, string userName)
        {
            var profile = await context
                .Profiles
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.User.UserName == userName);

            var news = await context
                .News
                .FirstOrDefaultAsync(n => n.Id == model.NewsId && n.Owner == profile);

            if (news == null)
            {
                return false;
            }

            news.isAproove = false;
            news.Title = model.Title;
            news.Photo = model.Photo;
            news.Text = model.Text;
            news.isModifyed = true;
            news.PublishOn = DateTime.Now;

            context
                .News
                .Update(news);

            await context.SaveChangesAsync();

            return true;
        }
    }
}
