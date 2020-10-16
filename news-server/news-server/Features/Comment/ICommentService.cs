using news_server.Features.Comment.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace news_server.Features.Comment
{
    public interface ICommentService
    {
        Task<bool> CreateComment(CommentCreateModel model, string userName, string link, int? commentId = -1);

        Task<List<GetCommentsModel>> GetCommentsByNewsId(int Id);
    }
}
