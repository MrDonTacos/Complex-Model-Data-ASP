
using System;

namespace schoolpractice.Models
{	
	public class MantenimientoEmpleado
	{	
		public int? id {get;set;}
        public string no_control {get;set;}
        public string ap_paterno {get;set;}
        public string ap_materno {get;set;}
        public string nombre {get;set;}
        public string sexo {get;set;}
        public string f_nacimiento {get;set;}
        public string no_seguro_social {get;set;}
        public string telefono {get;set;}
        public string fecha_ingreso {get;set;}
        public string clave_horario {get;set;}
        public string clave_puesto {get;set;}
        public string puesto {get;set;}
        public string clave_departamento {get;set;}
        public string horario_entrada {get;set;}
        public string horario_salida {get;set;}
        public string dias_semana {get;set;}
        public string clave_curso1 {get;set;}
        public string clave_curso2 {get;set;}
        public string estatus {get;set;}
        public string observaciones {get;set;}
        public string nombre_curso1 {get;set;}
        public string nombre_curso2 {get;set;}
	}
}