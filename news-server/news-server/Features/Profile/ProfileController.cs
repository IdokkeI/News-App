using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace news_server.Features.Profile
{

    [Authorize]
    public class ProfileController : ApiController
    {
        private readonly IProfileService profileService;

        public ProfileController(IProfileService profileService)
        {
            this.profileService = profileService;
        }

        [HttpGet(nameof(GetProfilesExceptName))]
        public async Task<ActionResult> GetProfilesExceptName(string username)
        {
            var result = await profileService.GetProfilesExceptName(username);
            return Ok(result);
        }

        [HttpGet(nameof(GetProfileById))]
        public async Task<ActionResult> GetProfileById(int profileId)
        {
            var result = await profileService.GetProfileById(profileId);
            return Ok(result);
        }

        [HttpGet(nameof(GetProfileByUserName))]
        public async Task<ActionResult> GetProfileByUserName(string username)
        {
            var result = await profileService.GetProfileByUserName(username);
            return Ok(result);
        }
    }
}
