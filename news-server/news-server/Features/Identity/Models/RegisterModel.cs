using System.ComponentModel.DataAnnotations;

namespace news_server.Features.Identity.Models
{
    public class RegisterModel: LoginModel
    { 

        [Required(ErrorMessage = "E-mail не может быть пустым")]
        [EmailAddress(ErrorMessage = "Введенные данные не являются E-mail")]
        public string Email { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Введенные пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}
