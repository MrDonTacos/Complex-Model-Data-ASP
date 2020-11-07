using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace schoolpractice.Models
{
    public class Sexo
    {
        [Key]
        public string id_sexo { get; set; }
        public string sexo { get; set; }
    }
}
