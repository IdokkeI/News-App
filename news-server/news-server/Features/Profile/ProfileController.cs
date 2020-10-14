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

        [HttpGet(nameof(GetProfileByName))]
        public async Task<ActionResult> GetProfileByName(string username)
        {
            var result = await profileService.GetProfileByName(username);
            return Ok(result);
        }
        
        [HttpGet(nameof(GetProfileById))]
        public async Task<ActionResult> GetProfileById(int profileId)
        {
            var result = await profileService.GetProfileById(profileId);
            return Ok(result);
        }


  
}
