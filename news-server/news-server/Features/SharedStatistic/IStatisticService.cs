using System.Threading.Tasks;

namespace news_server.Features.SharedStatistic.Models
{
    public interface IStatisticService
    {
        Task<bool> SetState(int objId, string username, string state);
    }
}
