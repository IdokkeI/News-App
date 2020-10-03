using news_server.Data.dbModels.Shared;

namespace news_server.Data.dbModels
{
    public class StatisticNews: StatisticBase
    {
        public int Id { get; set; }

       public News News { get; set; }

        public Profile Views { get; set; }
    }
}
