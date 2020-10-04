using news_server.Features.News.SharedStatistic.Models;
using System;

namespace news_server.Features.News.Models
{
    public class GetNewsModel
    {
        public int NewsId { get; set; }

        public string Title { get; set; }

        public string Photo { get; set; }

        public DateTime PublishDate { get; set; }

        public Params Params { get; set; }
    }
}
