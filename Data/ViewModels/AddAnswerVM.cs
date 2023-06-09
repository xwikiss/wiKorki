using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
