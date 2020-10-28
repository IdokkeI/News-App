using System;
using System.Collections.Generic;

namespace news_server.Data.dbModels
{
    public class Profile
    {        
        public int Id { get; set; }

        public User User { get; set; }

        public string UserId { get; set; }

        public DateTime RegisterOn { get; set; }

        public DateTime? LastActiveOn { get; set; }

        public bool isBaned { get; set; }

        public List<News> News { get; set; }

        public List<Notification> Notifications { get; set; } = new List<Notification>();

    }
}
