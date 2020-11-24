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
    public class EscolaridadController : ControllerBase
    {
        private readonly AppDbContext context;
        public EscolaridadController(AppDbContext context) 
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult Get() 
        {
            try
            {
                return Ok(context.escolaridad.ToList());
            }
            catch (Exception ext) 
            {
                return BadRequest(ext.Message);
            }
        }

        [HttpGet("{idEscolaridad}", Name = "GetEscolaridad")]
        public ActionResult Get(string idEscolaridad)
        {
            try
            {
                var escolaridadLocal = context.escolaridad.FirstOrDefault(m => m.id_escolaridad == idEscolaridad);
                return Ok(escolaridadLocal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Escolaridad escolaridad)
        {
            try
            {
                if (escolaridad.id_escolaridad == null || escolaridad.id_escolaridad  == "")
                throw new Exception("No puedes ingresar un ID nulo.");

                if (escolaridad.id_escolaridad .Length <= 3)
                throw new Exception("El ID no puede ser menor a 4 digitos.");

                if (escolaridad.escolaridad == null|| escolaridad.escolaridad == "")
                throw new Exception("No puedes ingresar un nombre en nulo.");

                var escolaridadLocal = context.escolaridad.FirstOrDefault(m => m.id_escolaridad == escolaridad.id_escolaridad);
                if (escolaridadLocal != null)
                throw new Exception("El ID " + escolaridadLocal.id_escolaridad + " ya fue registrado.");

                context.escolaridad.Add(escolaridad);
                context.SaveChanges();
                return Ok("Se ha guardado correctamente");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{idEscolaridad}")]
        public ActionResult Put(string idEscolaridad, [FromBody] Escolaridad escolaridad)
        {
            try
            {
                if ((idEscolaridad == "" || escolaridad.id_escolaridad == "") || (idEscolaridad == null || escolaridad.id_escolaridad == null))
                throw new Exception("No puedes enviar enviar una clave vacia");

                if (idEscolaridad.Length <= 3 && escolaridad.id_escolaridad.Length <= 3)
                throw new Exception("Has ingresado la clave mal, debe ser de 4 digitos.");

                if (idEscolaridad != escolaridad.id_escolaridad)
                throw new Exception("Las claves no corresponden.");

                context.Entry(escolaridad).State = EntityState.Modified;
                context.SaveChanges();
                return Ok("Fue modificado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{idExperiencia}")]
        public ActionResult Delete(string idExperiencia)
        {
            try
            {
                if (idExperiencia.Length <= 3)
                throw new Exception("Has ingresado una clave invalida.");

                if (idExperiencia == null || idExperiencia == "" || idExperiencia == "null")
                throw new Exception("No puedes enviar un registro vacio");

                var escolaridadLocal = context.escolaridad.FirstOrDefault(d => d.id_escolaridad == idExperiencia);
                if (escolaridadLocal == null )
                throw new Exception("No se ha encontrado el curso con clave " + idExperiencia);

                context.escolaridad.Remove(escolaridadLocal);
                context.SaveChanges();
                return Ok("Se ha eliminado correctamente");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
