using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using news_server.Data;
using news_server.Data.dbModels;
using news_server.Features.SectionNames.Models;
using System.Linq;
using System.Threading.Tasks;

namespace news_server.Features.SectionNames
{
    public class SectionNameController: ApiController
    {
        NewsDbContext context;
        public SectionNameController(NewsDbContext context)
        {
            this.context = context;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
            Roles = "admin, moderator")]
        [HttpPost]
        [Consumes("application/json")]
        public async Task<ActionResult> AddSection([FromBody] AddSectionNameModel model)
        {
            if (ModelState.IsValid)
            {
                var SectionName = context.SectionsNames.FirstOrDefault(sn => sn.SectionName == model.SectionName);
                if (SectionName == null)
                {
                    await context
                         .SectionsNames
                         .AddAsync(new SectionsName { SectionName = model.SectionName });
                    await context.SaveChangesAsync();
                    return Ok();
                }
                else
                    ModelState.AddModelError("duplicate", "Секция с таким именем уже существует");
            }
            return BadRequest(ModelState);
        }
    }
}
