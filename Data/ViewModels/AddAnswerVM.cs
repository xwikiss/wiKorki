using System.ComponentModel.DataAnnotations;

namespace wiKorki.Data.ViewModels
{
    public class AddAnswerVM
    {
        public int ExerciseId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        public byte[] Image { get; set; }
    }
}
