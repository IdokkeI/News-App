using news_server.Features.Comment.Models;
using System.Threading.Tasks;

namespace news_server.Features.Comment
{
    public interface ICommentService
    {
        Task<bool> CreateComment(CommentCreateModel model, string userName);
    }
}
