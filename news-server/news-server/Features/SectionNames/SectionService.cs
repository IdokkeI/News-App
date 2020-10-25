using Microsoft.EntityFrameworkCore;
using news_server.Data;
using news_server.Data.dbModels;
using news_server.Features.News;
using news_server.Features.News.Models;
using news_server.Features.SectionNames.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace news_server.Features.SectionNames
{
    public class SectionService : ISectionService
    {
        private readonly NewsDbContext context;
        private readonly INewsService newsService;

        public SectionService(
            NewsDbContext context, 
            INewsService newsService
            )
        {
            this.context = context;
            this.newsService = newsService;
        }

        public async Task<bool> AddSection(AddSectionNameModel model)
        {
            var SectionName = await context
                    .SectionsNames
                    .FirstOrDefaultAsync(sn => sn.SectionName == model.SectionName);

            if (SectionName == null)
            {
                await context
                     .SectionsNames
                     .AddAsync(new SectionsName { SectionName = model.SectionName });

                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateSection(UpdateSectionModel model)
        {
            var sectionName = await context
                .SectionsNames
                .FirstOrDefaultAsync(sn => sn.SectionName == model.OldName);
            if (sectionName == null)
            {
                return false;
            }

            sectionName.SectionName = model.SectionName;
            context.SectionsNames.Update(sectionName);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<GetNewsModelWithStates>> GetNewsBySectionName(string myUserName, string sectionName, int page)
        {
            var section =  await context
                .SectionsNames
                .FirstOrDefaultAsync(sn => sn.SectionName == sectionName);

            var news = await context
               .News
               .Where(n => n.isAproove && n.SectionsName == section)
               .Select(n => new GetNewsModelWithStates
               {
                   NewsId = n.Id,
                   Photo = n.Photo,
                   Title = n.Title,
                   PublishDate = n.PublishOn
               })
               .ToListAsync();

            var result = await newsService.SortingNewsWithStates(news, myUserName, page);
              
            return result;
        }
    }
}
