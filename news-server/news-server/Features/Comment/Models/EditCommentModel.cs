using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace news_server.Features.Comment.Models
{
    public class EditCommentModel
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
    }
}
