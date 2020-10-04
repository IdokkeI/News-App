using news_server.Features.Comment.Models;
using System.Collections.Generic;

namespace news_server.Features.News.Models
{
    public class GetNewsByIdModel: GetNewsModel
    {
        public string Text { get; set; }
        public List<GetCommentsModel> Comments { get; set; }
    }
}
