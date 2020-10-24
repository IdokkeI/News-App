using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using news_server.Features.SectionNames.Models;
using System.Threading.Tasks;

namespace news_server.Features.SectionNames
{
    
    public class SectionNameController: ApiController
    {
        private readonly ISectionService sectionService;

        public SectionNameController(ISectionService sectionService)
        {
            this.sectionService = sectionService;
        }

        [Authorize(Roles = "admin, moderator")]
        [HttpPost(nameof(AddSection))]
        public async Task<ActionResult> AddSection(AddSectionNameModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await sectionService.AddSection(model);

                if (result)
                {
                    return Ok();
                }
                else
                    ModelState.AddModelError("error", "Секция с таким именем уже существует");
            }           
            return BadRequest(ModelState);
        }

        [Authorize(Roles = "admin, moderator")]
        [HttpPut(nameof(UpdateSection))]
        public async Task<ActionResult> UpdateSection(UpdateSectionModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await sectionService.UpdateSection(model);
                if (result)
                {
                    return Ok();
                }
                return NotFound();
            }
            return BadRequest(ModelState);
        }


        [HttpPost(nameof(GetNewsBySectionName))]
        public async Task<ActionResult> GetNewsBySectionName(GetNewsBySectionNameModel model)
        {
            if (!string.IsNullOrEmpty(model.SectionName))
            {
                var result = await sectionService.GetNewsBySectionName(model.SectionName, model.Page);
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
