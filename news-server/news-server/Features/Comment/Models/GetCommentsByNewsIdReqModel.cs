namespace news_server.Features.Comment.Models
{
    public class GetCommentsByNewsIdReqModel
    {
        public int NewsId { get; set; }
        public int Page { get; set; } = 1;
    }
}
