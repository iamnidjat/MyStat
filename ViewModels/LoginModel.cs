using System.ComponentModel.DataAnnotations;

namespace MyStat.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указан UserName")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
