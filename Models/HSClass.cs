using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MaturaToBzdura.Models
{
    public class HSClass 
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Chapter> Chapter { get; set; }
    }
}
