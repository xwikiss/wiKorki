using System.ComponentModel.DataAnnotations;

namespace wiKorki.Data.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Adres E-mail jest wymagany")]
        [Display(Name = "Adres e-mail")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
