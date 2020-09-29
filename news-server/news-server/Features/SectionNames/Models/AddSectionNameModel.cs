using System.ComponentModel.DataAnnotations;

namespace news_server.Features.SectionNames.Models
{
    public class AddSectionNameModel
    {

        [Required(ErrorMessage = "Введите имя секции")]
        [RegularExpression("^(?=.*[A-Za-zа-яА-Я])[A-Za-zа-яА-Я -]*$", ErrorMessage = "Имя может содержать буквы пробелы и знак '-'")]
        public string SectionName { get; set; }

    }
}

