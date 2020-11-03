using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using news_server.Features.Moderator.Models;
using news_server.Features.Profile;
using System.Threading.Tasks;

namespace news_server.Features.Moderator
{
    [Authorize(Roles = "admin, moderator")]
    public class ModeratorController: ApiController
    {
        private readonly IModeratorService moderatorService;
        private readonly IProfileService profileService;

        public ModeratorController(IModeratorService moderatorService, IProfileService profileService)
        {
            this.moderatorService = moderatorService;
            this.profileService = profileService;
        }


        [HttpGet(nameof(GetNotApprovedNews))]
        public async Task<ActionResult> GetNotApprovedNews(int page = 1)
        {
            var result = await moderatorService.NotApproovedNews(page);
            return Ok(result);
        }


        [HttpGet(nameof(GetNotAprooveNewById))]
        public async Task<ActionResult> GetNotAprooveNewById(int newsId)
        {
            var result = await moderatorService.GetNotAprooveNewById(newsId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpPost(nameof(ApproveNews))]
        public async Task<ActionResult> ApproveNews([FromBody]int newsId)
        {
            string link = newsId.ToString();
            
            var result = await moderatorService.ApprooveNews(newsId, link);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }


        [HttpPost(nameof(BanUser))]
        public async Task<ActionResult> BanUser(BanUserModel model)
        {
            var result = await moderatorService.BanUser(model.UserName, model.DayCount);
            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }
        

        //[HttpGet(nameof(GetUsers))]
        //public async Task<ActionResult> GetUsers(int page = 1)
        //{
        //    var username = User.GetUserName();
        //    var result = await profileService.GetProfilesExceptName(username, page);
        //    return Ok(result);
        //}


        [HttpGet(nameof(GetBanUsers))]
        public async Task<ActionResult> GetBanUsers(int page = 1)
        {
            var result = await moderatorService.GetBanUsers(page);
            return Ok(result);
        }
    }
}
