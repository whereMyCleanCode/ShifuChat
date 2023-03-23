using System;
using System.ComponentModel.DataAnnotations;

namespace ShifuChat.ViewModels
{
    public class RegisterViewModel : IValidatableObject
    {
        [Key]
        [Required(ErrorMessage = "Обязательное поле для ввода!")]
        [EmailAddress(ErrorMessage = "Неккоректный формат ввода")]
        [DataType(dataType: DataType.EmailAddress)]
        public string? Email { get; set; }

        [Key]
        [Required(ErrorMessage = "Побязательное поле для ввода!")]
        [DataType(dataType:DataType.Password)]
        [MinLength(6,ErrorMessage = "Пароль допжен иметь длину больше 6 символов")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])" +
        "(?=.*?[!@#$%^&*-]).{10,}$",
        ErrorMessage = "Пароль слишком простой")]
        public string? Password { get; set; }

       

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Password == "qwerty" )
            {
                yield return new ValidationResult("Вы ввели слабый пароль.Пароль должен содержать минимум 7 цифр" , new[] { "Password" });
            }

        }
    }
}

