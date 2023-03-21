using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wiKorki.Data.ViewModels
{
 
        public class ChangePasswordVM
        {
            [Required(ErrorMessage = "Aktualne hasło jest wymagane!")]
            [DataType(DataType.Password)]
            [Display(Name = "Aktualne hasło")]
            public string CurrentPassword { get; set; }

            [Required(ErrorMessage = "Nowe hasło jest wymagane!")]
            [StringLength(100, MinimumLength = 6, ErrorMessage = "Hasło musi mieć conajmniej 6 znaków.")]
            [DataType(DataType.Password)]
            [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$", ErrorMessage = "Hasło musi mieć co najmniej 6 znaków i zawierać co najmniej jeden znak specjalny, jedną cyfrę i jedną wielką literę.")]
            [Display(Name = "Nowe hasło")]
            public string NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Required(ErrorMessage = "Potwierdzenie hasła jest wymagane!")]
            [Display(Name = "Potwierdź nowe hasło")]
            [Compare("NewPassword", ErrorMessage = "Hasła są różne")]
            public string ConfirmPassword { get; set; }
        

        }

}
