using news_server.Features.News.Models;
using news_server.Features.SectionNames.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace news_server.Features.SectionNames
{
    public interface ISectionService
    {
        Task<bool> AddSection(AddSectionNameModel model);
        Task<bool> UpdateSection(UpdateSectionModel model);
        Task<List<GetNewsModel>> GetNewsBySectionName(string sectionName, int page);
    }
}
