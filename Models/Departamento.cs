using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace schoolpractice.Models
{
    public class Departamento
    {
        [Key]
        public string id_depto { get; set; }
        public string nom_depto { get; set; }
    }
}
