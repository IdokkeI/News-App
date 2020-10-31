using news_server.Features.Profile.Models;
using System.ComponentModel.DataAnnotations;

namespace news_server.Features.News.Models
{
    public class FindNewsModel : PageModel
    {
        [Required(ErrorMessage = "Поле поиска пдолжно быть заполнено")]
        [MinLength(3, ErrorMessage = "Минимальная длина строки 3 символа")]
        [MaxLength(250, ErrorMessage = "Максимальная длина строки 250 символов")]
        public string Text { get; set; }

    }
}
