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
                context.curso.Add(curso);
                context.SaveChanges();
                return CreatedAtRoute("GetDepartamento", new { idDepto = curso.id_curso}, curso);
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
                if (curso.id_curso == idCurso)
                {
                    context.Entry(curso).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetCurso", new { idCurso = curso.id_curso}, curso);
                }
                else
                {
                    return BadRequest();
                }
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
                var curso = context.curso.FirstOrDefault(d => d.id_curso == idCurso);
                if (curso != null)
                {
                    context.curso.Remove(curso);
                    context.SaveChanges();
                    return Ok(idCurso);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
