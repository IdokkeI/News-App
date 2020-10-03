using System;

namespace news_server.Data.dbModels
{
    public class Comment
    {
        public int Id { get; set; }

        public Profile Owner { get; set; }

        public string Text { get; set; }   

        public DateTime DateComment { get; set; }

        public string UserNameTo { get; set; }

        public bool isEdit { get; set; }

        public News News { get; set; }
    }
}
