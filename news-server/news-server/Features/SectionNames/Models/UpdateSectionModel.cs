using System.ComponentModel.DataAnnotations;

namespace news_server.Features.SectionNames.Models
{
    public class UpdateSectionModel : AddSectionNameModel
    {
        [Required(ErrorMessage = "Введите имя секции")]
        [RegularExpression("^(?=.*[A-Za-zа-яА-Я])[A-Za-zа-яА-Я -]*$", ErrorMessage = "Имя может содержать буквы пробелы и знак '-'")]
        public string OldName { get; set; }
    }
}
