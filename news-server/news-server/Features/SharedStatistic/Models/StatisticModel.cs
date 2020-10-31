using System.ComponentModel.DataAnnotations;

namespace news_server.Features.StatisticNews.Models
{
    public class StatisticModel
    {
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Id должен быть больше 0")]
        public int ObjectId { get; set; }

        [Required(ErrorMessage = "Состояние должно быть заполнено")]
        public string State { get; set; }
    }
}
