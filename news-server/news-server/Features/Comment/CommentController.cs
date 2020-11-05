using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using news_server.Features.Comment.Models;
using news_server.Infrastructure.Extensions;
using news_server.Infrastructure.Filter;
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


        [HttpPost(nameof(CreateComment))]
        [ServiceFilter(typeof(BanFilter))]
        public async Task<ActionResult> CreateComment(CommentCreateModel model)
        {
            var username = User.GetUserName();
            string link = model.NewsId.ToString();
            
            var commentIdTo = model.CommentIdTo;
            var result = await commentService.CreateComment(model, username, link, commentIdTo);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }


        [HttpPut(nameof(EditComment))]
        public async Task<ActionResult> EditComment(EditCommentModel model)
        {
            var username = User.GetUserName();
            var comment = await commentService.EditComment(
                model.CommentId,
                username,
                model.Text);
            if (comment)
            {
                return Ok();
            }
            return BadRequest();
        }


        [AllowAnonymous]
        [HttpPost(nameof(GetCommentsByNewsId))]
        public async Task<ActionResult> GetCommentsByNewsId(GetCommentsByNewsIdReqModel model)
        {
            var username = User.GetUserName();
            var result = await commentService.GetCommentsByNewsId(model.NewsId, model.Page, username);
            return Ok(result);
        }
    }
}
