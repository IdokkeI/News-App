using news_server.Data.dbModels.Shared;

namespace news_server.Data.dbModels
{
    public class StatisticComment: StatisticBase
    {
        public int Id { get; set; }

        public Comment Comment { get; set; }

        public int CommentId { get; set; }

    }
}
