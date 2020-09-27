namespace news_server.Data.dbModels
{
    public class HashTag
    {
        public int Id { get; set; }

        public string TagName { get; set; }

        public SectionsName SectionsName { get; set; }

        public int sectionsNameId { get; set; }
    }
}