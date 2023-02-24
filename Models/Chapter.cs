using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MaturaToBzdura.Models
{
    public class Chapter
    { 
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public HSClass HSClass { get; set; }
        public List<Exercise> Exercises { get; set; }
    }
}
