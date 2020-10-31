using news_server.Features.Profile.Models;
using System.ComponentModel.DataAnnotations;

namespace news_server.Features.SectionNames.Models
{
    public class GetNewsBySectionNameModel : PageModel
    {
        [Required(ErrorMessage = "Имя секции должно быть заполнено")]
        public string SectionName { get; set; }

    }
}
