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
    public class PerfilController : ControllerBase
    {
        private readonly AppDbContext context;
        public PerfilController(AppDbContext context) 
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult Get() 
        {
            try
            {
                return Ok(context.perfil.ToList());
            }
            catch (Exception ext) 
            {
                return BadRequest(ext.Message);
            }
        }

        [HttpGet("{idPerfil}", Name = "GetPerfil")]
        public ActionResult Get(string idPerfil)
        {
            try
            {
                var perfil = context.perfil.FirstOrDefault(m => m.id_perfil == idPerfil);
                return Ok(perfil);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Perfil perfil)
        {
            try
            {
                if (perfil.id_perfil == null || perfil.id_perfil == "")
                throw new Exception("No puedes ingresar un ID nulo.");

                if (perfil.id_perfil.Length <= 3)
                throw new Exception("El ID no puede ser menor a 4 digitos.");

                if (perfil.perfil == null|| perfil.perfil == "")
                throw new Exception("No puedes ingresar un nombre en nulo.");

                var perfilLocal = context.perfil.FirstOrDefault(m => m.id_perfil == perfil.id_perfil);
                if (perfilLocal != null)
                throw new Exception("El ID " + perfilLocal.id_perfil + " ya fue registrado.");

                context.perfil.Add(perfil);
                context.SaveChanges();
                return Ok("Se ha registrado Correctamente");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{idPerfil}")]
        public ActionResult Put(string idPerfil, [FromBody] Perfil perfil)
        {
            try
            {
                if ((idPerfil == "" || perfil.id_perfil == "") || (idPerfil == null || perfil.id_perfil == null))
                throw new Exception("No puedes enviar enviar una clave vacia");

                if (idPerfil.Length <= 3 && perfil.id_perfil.Length <= 3)
                throw new Exception("Has ingresado la clave mal, debe ser de 4 digitos.");

                if (idPerfil != perfil.id_perfil)
                throw new Exception("Las claves no corresponden.");

                context.Entry(perfil).State = EntityState.Modified;
                context.SaveChanges();
                return Ok("Se ha modificado correctamente el perfil " + perfil.perfil);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{idPerfil}")]
        public ActionResult Delete(string idPerfil)
        {
            try
            {
                if (idPerfil.Length <= 3)
                throw new Exception("Has ingresado una clave invalida.");

                if (idPerfil == null || idPerfil == "" || idPerfil == "null")
                throw new Exception("No puedes enviar un registro vacio");

                var perfilLocal = context.perfil.FirstOrDefault(d => d.id_perfil == idPerfil);
                if (perfilLocal == null )
                throw new Exception("No se ha encontrado el curso con clave " + idPerfil);

                context.perfil.Remove(perfilLocal);
                context.SaveChanges();
                return Ok("Se ha eliminado correctamente.");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
