using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using wiKorki.Data.Base;

namespace MaturaToBzdura.Models
{
    public class HSClass : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Chapter> Chapter { get; set; }

    }
}
