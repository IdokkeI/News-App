using news_server.Features.News.SharedStatistic.Models;
using System.Threading.Tasks;

namespace news_server.Features.SharedStatistic.Models
{
    public interface IStatisticService
    {
        Task<bool> SetState(int objId, string username, string state);
        Params GetStatisticById(int objId);
    }
}
