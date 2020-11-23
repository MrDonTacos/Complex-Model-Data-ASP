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
    public class CursoController : ControllerBase
    {
        private readonly AppDbContext context;
        public CursoController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.curso.ToList());
            }
            catch (Exception ext)
            {
                return BadRequest(ext.Message);
            }
        }

        [HttpGet("{idCurso}", Name = "GetCurso")]
        public ActionResult Get(string idCurso)
        {
            try
            {
                var curso = context.curso.FirstOrDefault(m => m.id_curso == idCurso);
                return Ok(curso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Curso curso)
        {
            try
            {
                if (curso.id_curso == null || curso.id_curso == "")
                throw new Exception("No puedes ingresar un ID nulo.");

                if (curso.id_curso.Length <= 3)
                throw new Exception("El ID no puede ser menor a 4 digitos.");

                if (curso.nom_curso == null|| curso.nom_curso == "")
                throw new Exception("No puedes ingresar un nombre en nulo.");

                var cursoLocal = context.curso.FirstOrDefault(m => m.id_curso == curso.id_curso);
                if (cursoLocal != null)
                throw new Exception("El ID " + cursoLocal.id_curso + " ya fue registrado.");

                context.curso.Add(curso);
                context.SaveChanges();
                return Ok("Se ha registrado Correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{idCurso}")]
        public ActionResult Put(string idCurso, [FromBody] Curso curso)
        {
            try
            {
                if ((idCurso == "" || curso.id_curso == "") || (idCurso == null || curso.id_curso == null))
                throw new Exception("No puedes enviar enviar una clave vacia");

                if (idCurso.Length <= 3 && curso.id_curso.Length <= 3)
                throw new Exception("Has ingresado la clave mal, debe ser de 4 digitos.");

                if (idCurso != curso.id_curso)
                throw new Exception("Las claves no corresponden.");//ESTA CONDICION NO DEBERIA PASAR POR SI PASA, HAY PROBLEMA EN EL FRONDTEDN

                /*var cursoLocal = context.curso.FirstOrDefault(m => m.id_curso == idCurso);//DA ERROR YA QUE NO PUEDE HACER LA CONSULTA DE OTRA INSTANCIA
                if (cursoLocal == null)
                throw new Exception("El registro "+curso.nom_curso+" no existe.");*/

                context.Entry(curso).State = EntityState.Modified;
                context.SaveChanges();
                return Ok("Fue modificado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{idCurso}")]
        public ActionResult Delete(string idCurso)
        {
            try
            {
                if (idCurso.Length <= 3)
                throw new Exception("Has ingresado una clave invalida.");

                if (idCurso == null || idCurso == "" || idCurso == "null")
                throw new Exception("No puedes enviar un registro vacio");

                var curso = context.curso.FirstOrDefault(d => d.id_curso == idCurso);
                if (curso == null )
                throw new Exception("No se ha encontrado el curso con clave "+idCurso);

                context.curso.Remove(curso);
                context.SaveChanges();
                return Ok("Se ha eliminado correctamente el curso "+curso.nom_curso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
