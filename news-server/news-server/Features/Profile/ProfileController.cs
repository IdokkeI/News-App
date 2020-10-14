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

        [HttpGet(nameof(GetUserByName))]
        public async Task<ActionResult> GetUserByName(string username)
        {
            var result = await profileService.GetUserByName(username);
            return Ok(result);
        }


  
}
