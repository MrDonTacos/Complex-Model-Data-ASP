using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace schoolpractice.Models
{
    public class Puesto
    {
        [Key]
        public string id_puesto { get; set; }
        public string nom_puesto { get; set; }
    }
}
