using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace news_server.Features.News.Models
{
    public class CreateNewsModel
    {
        [Required(ErrorMessage = "Выебрите/введите секцию")]
        public string SectionName { get; set; }
        
        [MaxLength(150)]
        [Required(ErrorMessage = "Введите заголовок")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Введите текст новости/статьи")]
        public string Text { get; set; }
    }
}
