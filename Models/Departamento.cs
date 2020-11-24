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
        public string id_departamento { get; set; }
        public string nom_departamento { get; set; }
    }
}
