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
    public class EmpleadoCursoController : ControllerBase
    {
        private readonly AppDbContext context;
        public EmpleadoCursoController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<MateriaController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.empleado_curso.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<MateriaController>/5
        [HttpGet("{idEmpleadoCurso}", Name = "GetEmpleadoCurso")]
        public ActionResult Get(string idEmpleadoCurso)
        {
            try
            {
                var empleadoCurso = context.empleado_curso.FirstOrDefault(g => g.id_empleado_curso == idEmpleadoCurso);
                return Ok(empleadoCurso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // POST api/<MateriaController>
        [HttpPost]
        public ActionResult Post([FromBody] EmpleadoCurso empleadoCurso)
        {
            try
            {
                context.empleado_curso.Add(empleadoCurso);//agrega en tabla
                context.SaveChanges();//guarda
                return CreatedAtRoute("GetEmpleadoCurso", new { id = empleadoCurso.id_empleado_curso }, empleadoCurso);//regresa valores guardados y obtenemos el valor autoincrementable
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<MateriaController>/5
        [HttpPut("{idEmpleadoCurso}")]
        public ActionResult Put(string idEmpleadoCurso, [FromBody] EmpleadoCurso empleadoCurso)
        {
            try//se busca por id la comparativa a eliminar
            {
                if (empleadoCurso.id_empleado_curso == idEmpleadoCurso)
                {
                    context.Entry(empleadoCurso).State = EntityState.Modified;
                    context.SaveChanges();//guarda
                    return CreatedAtRoute("GetMateria", new { idEmpleadoCurso = empleadoCurso.id_empleado_curso }, empleadoCurso);//regresa valores guardados y obtenemos el valor autoincrementable
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

        // DELETE api/<MateriaController>/5
        [HttpDelete("{idEmpleadoCurso}")]
        public ActionResult Delete(string idEmpleadoCurso)
        {
            try
            {
                var empleadoCurso = context.empleado_curso.FirstOrDefault(m => m.id_empleado_curso == idEmpleadoCurso);
                if (empleadoCurso != null)
                {
                    context.empleado_curso.Remove(empleadoCurso);
                    context.SaveChanges();
                    return Ok(idEmpleadoCurso);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }
    }
}
