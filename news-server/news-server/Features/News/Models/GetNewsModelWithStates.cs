using news_server.Features.SharedStatistic.Models;

namespace news_server.Features.News.Models
{
    public class GetNewsModelWithStates: GetNewsModel
    {
        public LocalState LocalState { get; set; }
    }
}
