using news_server.Features.Profile.Models;

namespace news_server.Features.Comment.Models
{
    public class GetCommentsByNewsIdReqModel : PageModel
    {
        public int NewsId { get; set; }

    }
}
