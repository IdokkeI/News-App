using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using news_server.Features.Profile.Models;
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
        public async Task<ActionResult> GetProfilesExceptName(GetProfileUserNameModel model)
        {
            var result = await profileService.GetProfilesExceptName(model.UserName, model.Page);
            return Ok(result);
        }


        [HttpGet(nameof(GetProfileById))]
        public async Task<ActionResult> GetProfileById(GetProfileIdModel model)
        {
            var result = await profileService.GetProfileById(model.ProfileId, model.Page);
            return Ok(result);
        }


        [HttpGet(nameof(GetProfileByUserName))]
        public async Task<ActionResult> GetProfileByUserName(GetProfileUserNameModel model)
        {
            var result = await profileService.GetProfileByUserName(model.UserName, model.Page);
            return Ok(result);
        }
    }
}
