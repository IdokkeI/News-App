using System.Collections.Generic;

namespace news_server.Data.dbModels.Shared
{
    public class StatisticBase
    {
        public List<User> Likes { get; set; }
        public List<User> Dislike { get; set; }
    }
}
