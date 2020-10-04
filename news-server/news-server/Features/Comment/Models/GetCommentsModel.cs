using news_server.Features.News.SharedStatistic.Models;
using System;

namespace news_server.Features.Comment.Models
{
    public class GetCommentsModel
    {
        public int CommentId { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
        public DateTime DateComment { get; set; }
        public string UserNameTo { get; set; }
        public bool isEdit { get; set; }
        public Params Params { get; set; }
    }
}
