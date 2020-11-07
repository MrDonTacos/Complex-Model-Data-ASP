using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace schoolpractice.Models
{
    public class Escolaridad
    {
        [Key]
        public string id_escolaridad { get; set; }
        public string escolaridad { get; set; }
    }
}
