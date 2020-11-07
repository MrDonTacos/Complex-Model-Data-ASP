using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace schoolpractice.Models
{
    public class Horario
    {
        [Key]
        public string id_horario { get; set; }
        public string horario { get; set; }
    }
}
