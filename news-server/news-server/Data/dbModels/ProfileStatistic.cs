using System;

namespace news_server.Data.dbModels
{
    public class ProfileStatistic
    {
        public int Id { get; set; }

        public Profile Profile { get; set; }

        public int ProfileId { get; set; }

        public double RatingComments { get; set; }

        public double RatingNews { get; set; }

        public DateTime RegisterOn { get; set; }

        public DateTime? LastActiveOn { get; set; }
    }
}
