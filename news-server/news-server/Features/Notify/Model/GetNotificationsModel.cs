using System;

namespace news_server.Features.Notify.Model
{
    public class GetNotificationsModel
    {
        public int Id { get; set; }

        public string NotificationText { get; set; }

        public string Url { get; set; }

        public string Alt { get; set; }

        public int? CommentId { get; set; }

        public DateTime NotificationDate { get; set; }

        public bool isViewed { get; set; }
    }
}
