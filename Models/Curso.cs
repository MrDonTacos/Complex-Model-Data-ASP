using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace schoolpractice.Models
{
    public class Curso
    {
        [Key]
        public string id_curso { get; set; }
        public string nom_curso { get; set; }
    }
}
