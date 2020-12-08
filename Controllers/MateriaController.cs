using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using schoolpractice.Context;
using schoolpractice.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace schoolpractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        private readonly AppDbContext context;
        public MateriaController(AppDbContext context) 
        {
            this.context = context;
        }
        // GET: api/<MateriaController>
        [HttpGet]
        public ActionResult Get()
        {
            try 
            {
                return Ok(context.materia.ToList());
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<MateriaController>/5
        [HttpGet("{id}", Name ="GetMateria")]
        public ActionResult Get(int id)
        {
            try
            {
                var materia = context.materia.FirstOrDefault(g => g.id == id);
                return Ok(materia);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<MateriaController>
        [HttpPost]
        public ActionResult Post([FromBody] Materia materia)
        {
            try
            {
                materia.clvmateria = materia.id.ToString();
                context.materia.Add(materia);//agrega en tabla
                context.SaveChanges();//guarda
                return CreatedAtRoute("GetMateria", new {id=materia.id }, materia);//regresa valores guardados y obtenemos el valor autoincrementable
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<MateriaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Materia materia)
        {
            try//se busca por id la comparativa a eliminar
            {
                materia.clvmateria = materia.id.ToString();
                if (materia.id == id)
                {
                    context.Entry(materia).State = EntityState.Modified;
                    context.SaveChanges();//guarda
                    return CreatedAtRoute("GetMateria", new { id = materia.id }, materia);//regresa valores guardados y obtenemos el valor autoincrementable
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
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var materia = context.materia.FirstOrDefault(m => m.id == id);
                if (materia != null) 
                {
                    context.materia.Remove(materia);
                    context.SaveChanges();
                    return Ok(id);
                }
                else {
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
