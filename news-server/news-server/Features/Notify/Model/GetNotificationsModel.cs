using System;

namespace news_server.Features.Notify.Model
{
    public class GetNotificationsModel
    {
        public int Id { get; set; }

        public string UserNameFrom { get; set; }

        public string NotificationText { get; set; }       

        public DateTime NotificationDate { get; set; }
    }
}
