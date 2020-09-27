using System.ComponentModel.DataAnnotations;

namespace news_server.Features.Identity.Models
{
    public class LoginModel
    {

        [Required(ErrorMessage = "E-mail не может быть пустым")]
        [EmailAddress(ErrorMessage = "Введенные данные не являются E-mail")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Пароль не может быть пустым")] 
        [RegularExpression("(?=.*[0-9])(?=.*[a-z])[0-9a-z]{6,}", ErrorMessage = "Пароль должен состоять из цифр и букв латинского алфавита и иметь хотя бы 1 букву и цифру")]
        [MinLength(6, ErrorMessage = "Минимальная длина пароля 6 символов")]
        public string Password { get; set; }

    }
}
