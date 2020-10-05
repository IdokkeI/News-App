using System.Collections.Generic;

namespace news_server.Data.dbModels.Shared
{
    public class StatisticBase
    {
        public int? LikeId { get; set; }
        public int? DislikeId { get; set; }
        public Profile Like { get; set; }
        public Profile Dislike { get; set; }
    }
}
