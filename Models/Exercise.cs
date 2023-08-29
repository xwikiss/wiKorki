using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MaturaToBzdura.Models
{
    public class Exercise
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Nazwa zadania")]
        public string Name { get; set; }
        public string Content { get; set; }
        public int ChapterId { get; set; }
        public Chapter Chapter { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
