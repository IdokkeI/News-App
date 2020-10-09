using news_server.Features.SharedStatistic.Models;
using System;

namespace news_server.Features.News.Models
{
    public class GetNewsModel: GetNewsBaseModel
    {
        public Params Params { get; set; }
    }
}
