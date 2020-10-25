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
        Task<List<GetNewsModelWithStates>> GetNewsBySectionName(string myUserName, string sectionName, int page);
    }
}
