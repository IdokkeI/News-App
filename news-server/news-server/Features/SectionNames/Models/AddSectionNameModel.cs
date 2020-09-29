using System.ComponentModel.DataAnnotations;

namespace news_server.Features.SectionNames.Models
{
    public class AddSectionNameModel
    {

        [Required(ErrorMessage = "Введите имя секции")]
        [RegularExpression("^(?=.*[A-Za-zа-яА-Я])[A-Za-zа-яА-Я -]*$")]
        public string SectionName { get; set; }
    }
}
