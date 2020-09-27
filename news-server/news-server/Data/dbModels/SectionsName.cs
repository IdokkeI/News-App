using System.Collections.Generic;

namespace news_server.Data.dbModels
{
    public class SectionsName
    {
        public int Id { get; set; }

        public string SectionName { get; set; }

        public List<HashTag> HashTags { get; set; }
    }
}
