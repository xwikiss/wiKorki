using System.ComponentModel.DataAnnotations;

namespace wiKorki.Data.ViewModels
{
    public class ChangeCredentialsVM
    {
        [Required(ErrorMessage = "Imię i Nazwisko jest wymagane!")]
        [Display(Name = "Imię i Nazwisko")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "E-mail jest wymagany!")]
        [Display(Name = "Adres e-mail")]
        [RegularExpression(@"^\S+@\S+\.\S+$", ErrorMessage = "Nieprawidłowy adres e-mail")]
        public string EmailAddress { get; set; }

        [Display(Name = "Nazwa użytkownika")]
        public string UserName { get; set; }
    }
}





