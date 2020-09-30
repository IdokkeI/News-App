using System;
using System.Collections.Generic;

namespace news_server.Data.dbModels
{
    public class News
    {
        public int Id { get; set; }

        public SectionsName sectionsName { get; set; }

        public int SectionNameId { get; set; }

        public string SectionName { get; set; }

        public string Title { get; set; }

        public string Photo { get; set; }

        public string Text { get; set; }

        public DateTime PublishOn { get; set; }

        public bool isAproove { get; set; }

        public List<Comment> Comments { get; set; }

        public User UserOwner { get; set; }

        public string UserId { get; set; }

        public bool isModifyed { get; set; }

        public DateTime? ModifyedOn { get; set; }

    }
}
