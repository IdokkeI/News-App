using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using news_server.Data;
using news_server.Data.dbModels;
using news_server.Features.Identity.Models;
using System.Linq;
using System.Threading.Tasks;

namespace news_server.Features.Identity
{
    
    public class IdentityController: ApiController
    {
        private readonly UserManager<User> userManager;
        IIdentityService identityService;
        
        public IdentityController(UserManager<User> userManager, IIdentityService identityService)
        {
            this.userManager = userManager;
            this.identityService = identityService;
        }
        
        
        [HttpPost(nameof(Login))]
        [Produces("application/json")]
        public async Task<ActionResult> Login(LoginModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var role = await userManager.GetRolesAsync(user);
                var roleName = role.FirstOrDefault();
                var token = identityService.Authenticate(user, roleName);
                int access = 0;
                if (roleName == "admin")
                {
                    access = (int)RoleEnum.admin;
                }
                else if (roleName == "moderator")
                {
                    access = (int)RoleEnum.moderator;
                }
                else if (roleName == "user")
                {
                    access = (int)RoleEnum.user;
                }

                var result = new
                {
                    token,
                    access
                };

                return Ok(result);
            }

            return Unauthorized();
        }
        
        
        [HttpPost(nameof(Register))]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            var user = await userManager.FindByNameAsync(model.UserName);            
            if (user == null)
            {
                var mail = await userManager.FindByEmailAsync(model.Email);
                if (mail == null)
                {
                    var createUser = new User
                        {
                            UserName = model.UserName,
                            Email = model.Email
                        };

                    await userManager.CreateAsync(createUser, model.Password);
                    await userManager.AddToRoleAsync(createUser, "user");
                    return Ok();
                }
                else
                {
                    ModelState.AddModelError("mail", "Пользователь с таким E-mail уже существует");                    
                }
            }
            else
            {
                ModelState.AddModelError("username", "Пользователь с таким именем уже существует");
            }
            return BadRequest(ModelState);
        }

        
    }
}
