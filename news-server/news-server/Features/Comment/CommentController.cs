using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using news_server.Features.Comment.Models;
using news_server.Infrastructure.Extensions;
using System.Threading.Tasks;

namespace news_server.Features.Comment
{
    [Authorize]
    public class CommentController: ApiController
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateComment(CommentCreateModel model)
        {
            var username = User.GetUserName();
            var result = await commentService.CreateComment(model, username);
            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
