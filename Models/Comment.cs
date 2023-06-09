﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MaturaToBzdura.Models;

namespace MaturaToBzdura.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Treść komentarza")]
        public string Text { get; set; }
        public string UserId { get; set; }
        public Exercise Exercise{ get; set; }
        public int ExerciseId { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
