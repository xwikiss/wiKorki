using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wiKorki.Data.ViewModels
{
    public class AddCommentVM
    {
        public int ExerciseId { get; set; }

        [Required(ErrorMessage = "Treść jest wymagana!")]
        public string Text { get; set; }
    }

}
