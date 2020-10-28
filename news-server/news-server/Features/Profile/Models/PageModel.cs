using System.ComponentModel.DataAnnotations;

namespace news_server.Features.Profile.Models
{
    public class PageModel
    {
        [Range(1, double.MaxValue, ErrorMessage = "Номер страницы меньше 1")]
        public int Page { get; set; } = 1;
    }
}
