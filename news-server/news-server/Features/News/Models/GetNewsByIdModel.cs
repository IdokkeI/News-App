namespace news_server.Features.News.Models
{
    public class GetNewsByIdModel: GetNewsModel
    {
        public string Photo { get; set; }
        public string Text { get; set; }
    }
}
