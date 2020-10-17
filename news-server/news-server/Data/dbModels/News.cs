using System;
using System.Collections.Generic;

namespace news_server.Data.dbModels
{
    public class News
    {
        public int Id { get; set; }

        public SectionsName SectionsName { get; set; }

        public string Title { get; set; }

        public string Photo { get; set; }

        public string Text { get; set; }

        public DateTime PublishOn { get; set; }

        public bool isAproove { get; set; }

        public List<Comment> Comments { get; set; }

        public Profile Owner { get; set; }

        public bool isModifyed { get; set; }        

    }
}
