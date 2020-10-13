using System;

namespace news_server.Data.dbModels
{
    public class Comment
    {
        public int Id { get; set; }

        public Profile Owner { get; set; }

        public int OwnerId { get; set; }

        public string Text { get; set; }   

        public DateTime DateComment { get; set; }

        public string UserNameTo { get; set; }

        public bool isEdit { get; set; }

        public int? CommentIdTo { get; set; }

        public News News { get; set; }

        public int NewsId { get; set; }
    }
}
