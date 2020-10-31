using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        

        [HttpGet(nameof(GetModerators))]
        public async Task<ActionResult> GetModerators(int page = 1) 
        {
            var result = await adminService.GetModerators(page);
            return Ok(result);
        }

        [HttpGet(nameof(GetUsers))]
        public async Task<ActionResult> GetUsers(int page = 1)
        {
            var result = await adminService.GetUsers(page);
            return Ok(result);
        }


        [HttpPost(nameof(SetModerator))]
        public async Task<ActionResult> SetModerator([FromBody]string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                var result = await adminService.SetModerator(username);

                if (result)
                {
                    return Ok();
                }

                ModelState.AddModelError("notfound", "Пользователь не найден");
            }            
            return BadRequest(ModelState);
        }


        [HttpPost(nameof(DemoteModerator))]
        public async Task<ActionResult> DemoteModerator([FromBody]string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                var result = await adminService.DemoteModerator(username);

                if (result)
                {
                    return Ok();
                }
            }           
            return NotFound();
        }
    }
}
