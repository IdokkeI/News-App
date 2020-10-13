using System.ComponentModel.DataAnnotations;

namespace news_server.Features.Comment.Models
{
    public class CommentCreateModel
    {
        [Required]
        public int NewsId { get; set; }

        [Required]
        public string TextComment { get; set; }

        public string UsernameAddresTo { get; set; }

        public int? CommentId { get; set; }
    }
}
