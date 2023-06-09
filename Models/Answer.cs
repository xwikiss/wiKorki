using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MaturaToBzdura.Models;
using wiKorki.Data.Base;

namespace wiKorki.Models
{
    public class Answer :IEntityBase
    {
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
