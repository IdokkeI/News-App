using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using news_server.Features.Admin.Model;
using System.Threading.Tasks;

namespace news_server.Features.Admin
{
    [Authorize(Roles = "admin")]
    public class AdminController: ApiController
    {
        private readonly IAdminService adminService;

        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        [HttpGet(nameof(GetUsers))]
        [Produces("application/json")]
        public async Task<ActionResult> GetUsers() 
        {
            var result = await adminService.GetUsers();
            return Ok(result);
        }

        [HttpGet(nameof(GetModerators))]
        [Produces("application/json")]
        public async Task<ActionResult> GetModerators() 
        {
            var result = await adminService.GetModerators();
            return Ok(result);
        }

        [HttpPost(nameof(SetModerator))]
        public async Task<ActionResult> SetModerator(GetUser model)
        {
            if (!string.IsNullOrEmpty(model.UserName))
            {
                var result = await adminService.SetModerator(model.UserName);
                if (result)
                {
                    return Ok();
                }
                ModelState.AddModelError("notfound", "Пользователь не найден");
            }
            
            return BadRequest(ModelState);
        }

        [HttpPost(nameof(DemoteModerator))]
        public async Task<ActionResult> DemoteModerator(GetUser model)
        {
            if (!string.IsNullOrEmpty(model.UserName))
            {
                var result = await adminService.DemoteModerator(model.UserName);
                if (result)
                {
                    return Ok();
                }
                ModelState.AddModelError("notfound", "Пользователь не найден");
            }
           
            return BadRequest(ModelState);
        }
    }
}
