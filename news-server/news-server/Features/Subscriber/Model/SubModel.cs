using System.ComponentModel.DataAnnotations;

namespace news_server.Features.Subscriber.Model
{
    public class SubModel
    {
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Id должен быть больше 0")]
        public int SubTo { get; set; }

        [Required(ErrorMessage = "Состояние должно быть заполнено")]
        public string State { get; set; }
    }
}
