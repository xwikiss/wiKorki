using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using wiKorki.Data.Base;

namespace MaturaToBzdura.Models
{
    public class Chapter : IEntityBase
    { 
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int HSClassId { get; set; }
        public HSClass HSClass { get; set; }
       
        public List<Exercise> Exercises { get; set; }
       
    }

}
