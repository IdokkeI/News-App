using news_server.Data.dbModels.Shared;

namespace news_server.Data.dbModels
{
    public class StatisticNews: StatisticBase
    {
        public int Id { get; set; }

        public News News { get; set; }   

        public int NewsId { get; set; }

        public Profile ViewBy { get; set; }

        public int? ViewById { get; set; }

        public bool IsNotifyed { get; set; }
    }
}
