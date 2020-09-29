using Microsoft.EntityFrameworkCore;
using news_server.Data;
using news_server.Features.News.Models;
using System.Threading.Tasks;
using CNews = news_server.Data.dbModels.News;

namespace news_server.Features.News
{
    public class NewsService : INewsService
    {
        private readonly NewsDbContext context;

        public NewsService(NewsDbContext context)
        {
            this.context = context;
        }
        public async Task<bool> CreateNews(CreateNewsModel model, string userName)
        {
            var titleExist = await context.News.FirstOrDefaultAsync(n => n.Title == model.Title);
            if (titleExist == null)
            {
                var user = await context.Users.FirstOrDefaultAsync(u => u.UserName == userName);

                await context.News.AddAsync(
                    new CNews
                    {
                        SectionName = model.SectionName,
                        Title = model.Title,
                        Photo = model.Photo,
                        Text = model.Text,
                        UserOwner = user,
                        isAproove = false
                    });
                await context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
