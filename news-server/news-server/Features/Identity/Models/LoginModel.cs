using System.ComponentModel.DataAnnotations;

namespace news_server.Features.Identity.Models
{
    public class LoginModel
    {               
        [Required(ErrorMessage = "Имя пользователя не может быть пустым")]
        [RegularExpression("^[а-яa-z0-9_]{3,16}$")]
        [MinLength(3, ErrorMessage = "Минимальная длина имени пользователя 3 символа")]
        [MaxLength(6, ErrorMessage = "Максимальная длина имени пользователя не должна превышать 16 символов")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Пароль не может быть пустым")] 
        [RegularExpression("(?=.*[0-9])(?=.*[a-z])[0-9a-z]{6,}", ErrorMessage = "Пароль должен состоять из цифр и букв латинского алфавита и иметь хотя бы 1 букву и цифру")]
        [MinLength(6, ErrorMessage = "Минимальная длина пароля 6 символов")]
        public string Password { get; set; }

    }
}
