using System;

namespace news_server.Data.dbModels
{
    public class Notification
    {
        public int Id { get; set; }

        public string UserNameTo { get; set; }

        public string NotificationText { get; set; }

        public Profile Owner { get; set; }

        public DateTime NotificationDate { get; set; }
    }
}
