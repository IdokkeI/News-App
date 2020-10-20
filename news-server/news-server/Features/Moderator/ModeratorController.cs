﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using news_server.Features.Profile;
using news_server.Infrastructure.Extensions;
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


        [HttpPost(nameof(ApproveNews))]
        public async Task<ActionResult> ApproveNews(int newsId)
        {
            string link = Url
                   .Action(
                       "GetNewsById",
                       "News",
                       new { newsId = newsId },
                    protocol: HttpContext.Request.Scheme);

            var result = await moderatorService.ApprooveNews(newsId, link);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }


        [HttpPost(nameof(BanUser))]
        public async Task<ActionResult> BanUser(int profileId, int dayCount)
        {
            var result = await moderatorService.BanUser(profileId, dayCount);
            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }
        

        [HttpGet(nameof(GetUsers))]
        public async Task<ActionResult> GetUsers(int page = 1)
        {
            var username = User.GetUserName();
            var result = await profileService.GetProfilesExceptName(username, page);
            return Ok(result);
        }


        [HttpGet(nameof(GetBanUsers))]
        public async Task<ActionResult> GetBanUsers(int page = 1)
        {
            var result = await moderatorService.GetBanUsers(page);
            return Ok(result);
        }
    }
}
