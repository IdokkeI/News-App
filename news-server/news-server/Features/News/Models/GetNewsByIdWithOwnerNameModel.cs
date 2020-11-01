namespace news_server.Features.News.Models
{
    public class GetNewsByIdWithOwnerNameModel: GetNewsByIdModel
    {
        public string UserName { get; set; }
        public string SectionName { get; set; }
    }
}
