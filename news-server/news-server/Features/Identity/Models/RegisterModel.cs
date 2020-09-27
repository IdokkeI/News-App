using System.ComponentModel.DataAnnotations;

namespace news_server.Features.Identity.Models
{
    public class RegisterModel: LoginModel
    {

        [Required(ErrorMessage = "Имя пользователя не может быть пустым")]
        [RegularExpression("^[а-яa-z0-9_]{3,16}$")]
        [MinLength(3, ErrorMessage = "Минимальная длина имени пользователя 3 символа")]
        [MaxLength(6, ErrorMessage = "Максимальная длина имени пользователя не должна превышать 16 символов")]
        public string UserName { get; set; }        

        [Required(ErrorMessage = "Подвердите пароль")]
        [Compare("Password", ErrorMessage = "Введенные пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}
