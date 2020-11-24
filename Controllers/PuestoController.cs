using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using schoolpractice.Context;
using schoolpractice.Models;

namespace schoolpractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuestoController : ControllerBase
    {
        private readonly AppDbContext context;
        public PuestoController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.puesto.ToList());
            }
            catch (Exception ext)
            {
                return BadRequest(ext.Message);
            }
        }

        [HttpGet("{idPuesto}", Name = "GetPuesto")]
        public ActionResult Get(string idPuesto)
        {
            try
            {
                var puestoLocal = context.puesto.FirstOrDefault(m => m.id_puesto == idPuesto);
                return Ok(puestoLocal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Puesto puesto)
        {
            try
            {
                if (puesto.id_puesto == null || puesto.id_puesto == "")
                throw new Exception("No puedes ingresar un ID nulo.");

                if (puesto.id_puesto.Length <= 3)
                throw new Exception("El ID no puede ser menor a 4 digitos.");

                if (puesto.nom_puesto == null|| puesto.nom_puesto == "")
                throw new Exception("No puedes ingresar un nombre en nulo.");

                var puestoLocal = context.puesto.FirstOrDefault(m => m.id_puesto == puesto.id_puesto);
                if (puestoLocal != null)
                throw new Exception("El ID " + puesto.id_puesto + " ya fue registrado.");

                context.puesto.Add(puesto);
                context.SaveChanges();
                return Ok("Se ha registrado Correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{idPuesto}")]
        public ActionResult Put(string idPuesto, [FromBody] Puesto puesto)
        {
            try
            {
                if ((idPuesto == "" || puesto.id_puesto == "") || (idPuesto == null || puesto.id_puesto == null))
                throw new Exception("No puedes enviar enviar una clave vacia");

                if (idPuesto.Length <= 3 && puesto.id_puesto.Length <= 3)
                throw new Exception("Has ingresado la clave mal, debe ser de 4 digitos.");

                if (idPuesto != puesto.id_puesto)
                throw new Exception("Las claves no corresponden.");//ESTA CONDICION NO DEBERIA PASAR POR SI PASA, HAY PROBLEMA EN EL FRONDTEDN

                /*var cursoLocal = context.curso.FirstOrDefault(m => m.id_curso == idCurso);//DA ERROR YA QUE NO PUEDE HACER LA CONSULTA DE OTRA INSTANCIA
                if (cursoLocal == null)
                throw new Exception("El registro "+curso.nom_curso+" no existe.");*/

                context.Entry(puesto).State = EntityState.Modified;
                context.SaveChanges();
                return Ok("Fue modificado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{idPuesto}")]
        public ActionResult Delete(string idPuesto)
        {
            try
            {
                if (idPuesto.Length <= 3)
                throw new Exception("Has ingresado una clave invalida.");

                if (idPuesto == null || idPuesto == "" || idPuesto == "null")
                throw new Exception("No puedes enviar un registro vacio");

                var puestoLocal = context.puesto.FirstOrDefault(d => d.id_puesto == idPuesto);
                if (puestoLocal == null )
                throw new Exception("No se ha encontrado el curso con clave " + idPuesto);

                context.puesto.Remove(puestoLocal);
                context.SaveChanges();
                return Ok("Se ha eliminado correctamente el curso " + puestoLocal.nom_puesto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
