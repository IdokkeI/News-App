using System.Collections.Generic;

namespace news_server.Data.dbModels
{
    public class Section
    {
        public int Id { get; set; }

        public SectionsName SectionName { get; set; }

        public int SectionNameId { get; set; }

        public List<News> News { get; set; } = new List<News>();

    }
}
