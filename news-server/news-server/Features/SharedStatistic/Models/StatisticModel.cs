using System.ComponentModel.DataAnnotations;

namespace news_server.Features.StatisticNews.Models
{
    public class StatisticModel
    {
        [Required]
        public int ObjectId { get; set; }

        [Required]
        public string State { get; set; }
    }
}
