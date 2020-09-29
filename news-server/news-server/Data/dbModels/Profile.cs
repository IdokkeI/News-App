using System.Collections.Generic;

namespace news_server.Data.dbModels
{
    public class Profile
    {
        public int Id { get; set; }

        public List<User> ListSubscribers { get; set; }

        public StatisticComment StatisticComment { get; set; }

        public int StatisticCommentId { get; set; }

        public StatisticNews StatisticNews { get; set; }

        public int StatisticNewsId { get; set; }

        public bool isBanned { get; set; }

    }
}
