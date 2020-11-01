using Microsoft.EntityFrameworkCore;
using news_server.Data;
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

        public NewsService(
            NewsDbContext context, 
            StatisticNewsService statisticNewsService)
        {
            this.context = context;
            this.statisticNewsService = statisticNewsService;
        }

        public async Task<List<GetNewsModelWithStates>> GetMyNews(string username, int page)
        {
            var profileId = (await context
                .Profiles
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.User.UserName == username)).Id;

            var result = await GetProfileNews(username, profileId, page);

            return result;
        }


        public async Task<List<GetNewsModelWithStates>> GetProfileNews(string username, int profileId, int page)
        {
            var news = await context
                    .News
                    .Include(n => n.Owner)
                    .Where(n => n.Owner.Id == profileId)
                    .Select(n => new GetNewsModelWithStates
                    {
                        NewsId = n.Id,
                        Title = n.Title,
                        PublishDate = n.PublishOn
                    })
                    .ToListAsync();

            var result = await SortingNewsWithStates(news, username, page);
            
            return result;
        }
        

        public async Task<List<GetNewsModelWithStates>> GetProfileNews(string username, int profileId)
        {
            var news = await context
                    .News
                    .Include(n => n.Owner)
                    .Where(n => n.Owner.Id == profileId)
                    .Select(n => new GetNewsModelWithStates
                    {
                        NewsId = n.Id,
                        Title = n.Title,
                        PublishDate = n.PublishOn                        
                    })
                    .ToListAsync();

            var result = await Task.Run(() =>
           {
               news.ForEach(n => 
               {
                   n.Params = statisticNewsService.GetStatisticById(n.NewsId);
                   n.LocalState = statisticNewsService.LocalStateNews(n.NewsId, username);
               });
               return news;
           });

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
                    var createNews = await context
                        .News
                        .AddAsync(new CNews
                        {
                            SectionsName = section,
                            Title = model.Title,
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


        public async Task<IEnumerable<GetNewsModel>> GetNews(string username, int page)
        {            
            var news = await context
            .News
            .Where(n => n.isAproove)
            .Select(n => new GetNewsModelWithStates
            {
                NewsId = n.Id,
                Title = n.Title,
                PublishDate = n.PublishOn
            })
            .ToListAsync();

            var result = await SortingNewsWithStates(news, username, page);

            return result;            
        }


        public async Task<GetNewsByIdWithOwnerNameModel> GetNewsById(int newsId)
        {           
            var news = await context
            .News
            .Include(n => n.SectionsName)
            .Include(n => n.Owner)
            .Include(n => n.Owner.User)
            .Where(n => n.Id == newsId /*&& n.isAproove*/)
            .Select(n => new GetNewsByIdWithOwnerNameModel
            {
                UserName = n.Owner.User.UserName,
                SectionName = n.SectionsName.SectionName,
                NewsId = n.Id,                
                PublishDate = n.PublishOn,
                Title = n.Title,
                Text = n.Text,
            })
            .FirstOrDefaultAsync();

            if (news != null)
            {
                news.Params = statisticNewsService.GetStatisticById(newsId);
            }            

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
            news.Text = model.Text;
            news.isModifyed = true;
            news.PublishOn = DateTime.Now;

            context
                .News
                .Update(news);

            await context.SaveChangesAsync();

            return true;
        }


        public async Task<IEnumerable<GetNewsModel>> GetInterestingNews(string username, int page)
        {
            var myProfile = await context
                .Profiles
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.User.UserName == username);

            if (myProfile == null)
            {
                return null;
            }
            
            var Subs = await context
                .Subscriptions
                .Include(s => s.Profile)
                .Where(s => s.ProfileIdSub == myProfile.Id)
                .Select(s => s.ProfileId)
                .ToListAsync();

            var news = await context
               .News
               .Include(n => n.Owner)
               .Where(n => (n.Owner.Id == myProfile.Id || Subs.Contains(n.Owner.Id)) && n.isAproove)
               .Select(n => new GetNewsModelWithStates
               {
                   NewsId = n.Id,
                   Title = n.Title,
                   PublishDate = n.PublishOn
               })
               .ToListAsync();

            var result = await SortingNewsWithStates(news, username, page);
              
            return result;
        }


        public async Task<List<GetNewsModelWithStates>> FindNews(string username, string text, int page)
        {
            var news = await context
                .News
                .Where(n => (n.Text.Contains(text) || n.Title.Contains(text)) && n.isAproove)
                .ToListAsync();

            var result = await SelectNewsWithStates(news);

            var newsResult = await SortingNewsWithStates(result, username, page);

            return newsResult;
        }


        private async Task<List<GetNewsModelWithStates>> SelectNewsWithStates(List<CNews> news)
        {
            var result = await Task.Run(()
               =>
                   news
                       .Select(n => new GetNewsModelWithStates
                       {
                           NewsId = n.Id,
                           Title = n.Title,
                           PublishDate = n.PublishOn
                       })
                       .ToList());

            return result;
        }


        public async Task<List<GetNewsModelWithStates>> SortingNewsWithStates(List<GetNewsModelWithStates> news, string username, int page)
        {
            var listNews = await Task.Run(() => 
            {
                news.ForEach(n => 
                {
                    n.Params = statisticNewsService.GetStatisticById(n.NewsId);
                    n.LocalState = statisticNewsService.LocalStateNews(n.NewsId, username);
                });
                return news; 
            });

            var result = await Task.Run(() =>
            {
                var pageNews = listNews
                    .OrderByDescending(n => n.PublishDate)
                    .ThenByDescending(n => n.Params.Views)
                    .ThenByDescending(n => n.Params.Likes)
                    .Skip(page * 20 - 20)
                    .Take(20)
                    .ToList();

                return pageNews;
            });

            return result;
        }
    }
}
