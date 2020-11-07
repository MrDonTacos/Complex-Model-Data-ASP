using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace schoolpractice.Models
{
    public class EmpleadoCurso
    {
        [Key]
        public string id_empleado_curso { get; set; }
        public string nom_empleado_curso { get; set; }
    }
}
