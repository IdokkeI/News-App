using Microsoft.EntityFrameworkCore;
using news_server.Data;
using news_server.Data.dbModels;
using news_server.Features.News.Models;
using news_server.Features.SectionNames.Models;
using news_server.Features.StatisticNews;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace news_server.Features.SectionNames
{
    public class SectionService : ISectionService
    {
        private readonly NewsDbContext context;
        private readonly StatisticNewsService statisticNewsService;

        public SectionService(
            NewsDbContext context, 
            StatisticNewsService statisticNewsService
            )
        {
            this.context = context;
            this.statisticNewsService = statisticNewsService;
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

        public async Task<List<GetNewsModel>> GetNewsBySectionName(string sectionName, int page)
        {
            var section =  await context
                .SectionsNames
                .FirstOrDefaultAsync(sn => sn.SectionName == sectionName);

            var news = await Task.Run( async () => (await context
               .News
               .Where(n => n.isAproove && n.SectionsName == section)
               .Select(n => new GetNewsModel
               {
                   NewsId = n.Id,
                   Photo = n.Photo,
                   Title = n.Title,
                   PublishDate = n.PublishOn,
                   Params = statisticNewsService.GetStatisticById(n.Id)
               })
               .ToListAsync())
               .OrderBy(s => s.PublishDate)
               .ThenByDescending(s => s.Params.Views)
               .ThenByDescending(s => s.Params.Likes)
               .Skip(page * 20 - 20)
               .Take(20)
               .ToList());

            return news;
        }
    }
}
