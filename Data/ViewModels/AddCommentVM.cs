using System.ComponentModel.DataAnnotations;

namespace wiKorki.Data.ViewModels
{
    public class AddCommentVM
    {
        public int ExerciseId { get; set; }

        [Required(ErrorMessage = "Treść jest wymagana!")]
        public string Text { get; set; }
    }
}
