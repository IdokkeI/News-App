using System;

namespace news_server.Data.dbModels
{
    public class Comment
    {
        public int Id { get; set; }

        public User UserOwner { get; set; }

        public int UserId { get; set; }

        public string Text { get; set; }   

        public DateTime DateComment { get; set; }

        public string UserNameTo { get; set; }

        public bool isEdit { get; set; }

        public News News { get; set; }

        public int NewsId { get; set; }
    }
}
