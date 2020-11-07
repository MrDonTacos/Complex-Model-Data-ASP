using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace schoolpractice.Models
{
    public class Experiencia
    {
        [Key]
        public string id_experiencia { get; set; }
        public string experiencia { get; set; }
    }
}
