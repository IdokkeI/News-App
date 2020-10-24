using System;

namespace news_server.Data.dbModels
{
    public class Notification
    {
        public int Id { get; set; }

        #region who invoke notification(ProfileId)
        #endregion
        public int ProfileIdFrom { get; set; }

        public string NotificationText { get; set; }

        public string Url { get; set; }

        public string Alt { get; set; }

        #region who will get notification 
        #endregion
        public Profile Profile { get; set; }

        public int ProfileId { get; set; }        

        public int? CommentId { get; set; }

        public DateTime NotificationDate { get; set; }

        public bool isViewed { get; set; }
    }
}
