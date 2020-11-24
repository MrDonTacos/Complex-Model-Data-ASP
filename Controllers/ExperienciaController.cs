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
    public class ExperienciaController : ControllerBase
    {
        private readonly AppDbContext context;
        public ExperienciaController(AppDbContext context) 
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult Get() 
        {
            try
            {
                return Ok(context.experiencia.ToList());
            }
            catch (Exception ext) 
            {
                return BadRequest(ext.Message);
            }
        }

        [HttpGet("{idExperiencia}", Name = "GetExperiencia")]
        public ActionResult Get(string idExperiencia)
        {
            try
            {
                var experienciaLocal = context.experiencia.FirstOrDefault(m => m.id_experiencia == idExperiencia);
                return Ok(experienciaLocal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Experiencia experiencia)
        {
            try
            {
                if (experiencia.id_experiencia == null || experiencia.id_experiencia == "")
                throw new Exception("No puedes ingresar un ID nulo.");

                if (experiencia.id_experiencia.Length <= 3)
                throw new Exception("El ID no puede ser menor a 4 digitos.");

                if (experiencia.experiencia == null|| experiencia.experiencia == "")
                throw new Exception("No puedes ingresar un nombre en nulo.");

                var cursoLocal = context.experiencia.FirstOrDefault(m => m.id_experiencia == experiencia.id_experiencia);
                if (cursoLocal != null)
                throw new Exception("El ID " + cursoLocal.id_experiencia + " ya fue registrado.");

                context.experiencia.Add(experiencia);
                context.SaveChanges();
                return Ok("Se ha guardado correctamente");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{idExperiencia}")]
        public ActionResult Put(string idExperiencia, [FromBody] Experiencia experiencia)
        {
            try
            {
                if ((idExperiencia == "" || experiencia.id_experiencia == "") || (idExperiencia == null || experiencia.id_experiencia == null))
                throw new Exception("No puedes enviar enviar una clave vacia");

                if (idExperiencia.Length <= 3 && experiencia.id_experiencia.Length <= 3)
                throw new Exception("Has ingresado la clave mal, debe ser de 4 digitos.");

                if (idExperiencia != experiencia.id_experiencia)
                throw new Exception("Las claves no corresponden.");

                context.Entry(experiencia).State = EntityState.Modified;
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

                var experienciaLocal = context.experiencia.FirstOrDefault(d => d.id_experiencia == idExperiencia);
                if (experienciaLocal == null )
                throw new Exception("No se ha encontrado el curso con clave " + idExperiencia);

                context.experiencia.Remove(experienciaLocal);
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
