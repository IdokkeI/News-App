using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using news_server.Data.dbModels;
using news_server.Features.Identity;
using news_server.Features.Notify;
using news_server.Features.Profile.Models;
using news_server.Infrastructure.Extensions;
using System.Threading.Tasks;

namespace news_server.Features.Profile
{    
    public class ProfileController : ApiController
    {
        private readonly IProfileService profileService;
        private readonly IIdentityService identityService;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IHubContext<NotifyHub> hubContext;

        public ProfileController(
            IProfileService profileService,
            IIdentityService identityService,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            IHubContext<NotifyHub> hubContext)
        {
            this.profileService = profileService;
            this.identityService = identityService;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.hubContext = hubContext;
        }

        [Authorize(Roles = "moderator, user")]
        [HttpPost(nameof(GetProfilesExceptName))]
        public async Task<ActionResult> GetProfilesExceptName(GetProfileUserNameModel model)
        {
            var result = await profileService.GetProfilesExceptName(model.UserName, model.Page);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost(nameof(GetProfileById))]
        public async Task<ActionResult> GetProfileById(GetProfileIdModel model)
        {
            var result = await profileService.GetProfileById(model.ProfileId, model.Page);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost(nameof(GetProfileByUserName))]
        public async Task<ActionResult> GetProfileByUserName(GetProfileUserNameModel model)
        {
            var result = await profileService.GetProfileByUserName(model.UserName, model.Page);
            return Ok(result);
        }

        [Authorize(Roles = "moderator, user")]
        [HttpPost(nameof(UploadProfileImage))]
        public async Task<ActionResult> UploadProfileImage(IFormFile image)
        {
            var username = User.GetUserName();
            var result = await profileService.UploadProfileImage(username, image);
            return Ok(result);
        }

        [Authorize]
        [HttpPost(nameof(ChangePassword))]
        public async Task<ActionResult> ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var userName = User.GetUserName();
                var user = await userManager.FindByNameAsync(userName);
                var checkPass = await userManager.CheckPasswordAsync(user, model.OldPassword);

                if (user.Email != model.Email || !checkPass)
                {
                    return BadRequest();
                }

                await hubContext.Clients.User(userName).SendAsync("SignalLogOut");
                var code = await userManager.GenerateNewTwoFactorRecoveryCodesAsync(user, 1);
                var link = Url
                       .Action(
                           "SetNewPassword",
                           "Profile",
                           new
                           {
                               username = userName,
                               oldPassword = model.OldPassword,
                               password = model.Password,
                               token = code
                           },
                           HttpContext.Request.Scheme);

                await profileService.SendEmail(model.Email, link);                
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [AllowAnonymous]
        [HttpGet(nameof(SetNewPassword))]
        public async Task<ActionResult> SetNewPassword(string username, string OldPassword, string password, string token)
        {
            var user = await userManager.FindByNameAsync(username);
            var resultToken = await userManager.RedeemTwoFactorRecoveryCodeAsync(user, token);
            if (resultToken.Succeeded)
            {
               var resultChangePass = await userManager.ChangePasswordAsync(user, OldPassword, password);
                if (resultChangePass.Succeeded)
                {                    
                    return Ok();
                }
            }
            return BadRequest();
        }
    }
}
