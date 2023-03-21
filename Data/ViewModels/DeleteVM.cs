using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wiKorki.Data.ViewModels
{
    public class DeleteVM
    {
        [Required(ErrorMessage = "Hasło jest wymagane!")]
        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Potwierdzenie hasła jest wymagane!")]
        [Display(Name = "Potwierdź hasło")]
        [Compare("Password", ErrorMessage = "Hasła są różne")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }

}
