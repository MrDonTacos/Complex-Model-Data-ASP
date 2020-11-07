
using System;

namespace schoolpractice.Models
{	
	public class MantenimientoBolsa
	{	
		public String id_persona {get;set;}
		public String id_perfil {get;set;}
		public String id_experiencia {get;set;}
		public String id_escolaridad {get;set;}
		public String id_estatus {get;set;}
		public int? id_documentos {get;set;}
		
		String  observaciones {get;set;}
		public String  fecha_ingreso {get;set;}
	}
}