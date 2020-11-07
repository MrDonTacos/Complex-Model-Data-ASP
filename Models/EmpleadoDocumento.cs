using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace schoolpractice.Models
{
    public class EmpleadoDocumento
    {
        [Key]
        public string id_empleado_documento { get; set; }
        public string nom_empleado_documento { get; set; }
    }
}
