using System.ComponentModel.DataAnnotations;

namespace wiKorki.Data.ViewModels
{
    public class DeleteVM
    {
        [Required(ErrorMessage = "Hasło jest wymagane!")]
        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
