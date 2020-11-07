using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace schoolpractice.Models
{
    public class Persona
    {
        [Key]
        public String curp {get;set;}
        public String nombre {get;set;}
        public String apellido_materno {get;set;}
        public String apellid_paterno {get;set;}
        public int? id_fk_sexo {get;set;}
        public DateTime? fecha_nacimiento {get;set;}
        public String direccion {get;set;}
        public String telefono {get;set;}
        public int? id_fk_nacionalidad {get;set;}
    }
}
