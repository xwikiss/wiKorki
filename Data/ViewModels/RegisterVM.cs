using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wiKorki.Data.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Imię i Nazwisko jest wymagane!")]
        [Display(Name = "Imię i Nazwisko")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "E-mail jest wymagany!")]
        [Display(Name = "Adres e-mail")]
        [RegularExpression(@"^\S+@\S+\.\S+$", ErrorMessage = "Nieprawidłowy adres e-mail")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane!")]
        [Display(Name = "Hasło")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Hasło musi mieć conajmniej 6 znaków.")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$", ErrorMessage = "Hasło musi mieć co najmniej 6 znaków i zawierać co najmniej jeden znak specjalny, jedną cyfrę i jedną wielką literę.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Potwierdź hasło")]
        [Required(ErrorMessage = "Potwierdzenie hasła jest wymagane!")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Hasła są różne")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Nazwa użytkownika")]
        public string UserName { get; set; }
    }
}
