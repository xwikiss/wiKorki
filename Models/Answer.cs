using System.ComponentModel.DataAnnotations;
using MaturaToBzdura.Models;

namespace wiKorki.Models
{
    public class Answer 
    {
        [Key]
        public int Id { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public Exercise Exercise { get; set; }
        public int ExerciseId { get; set; }

        [Display(Name = "Rozwiązanie")]
        public byte[] Image { get; set; }

        public string Text { get; set; }

        [Display(Name = "Ocena")]
        public string Evaluation { get; set; }
    }
}
