using System;

namespace news_server.Features.News.Models
{
    public class GetNewsBaseModel
    {
        public int NewsId { get; set; }

        public string Title { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
