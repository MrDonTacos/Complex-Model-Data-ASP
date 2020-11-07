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
    public class NacionalidadController : ControllerBase
    {
        private readonly AppDbContext context;
        public NacionalidadController(AppDbContext context) 
        {
            this.context = context;
        }
        // GET: api/<NacionalidadController>
        [HttpGet]
        public ActionResult Get()
        {
            try 
            {
                return Ok(context.nacionalidad.ToList());
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<NacionalidadController>/5
        [HttpGet("{id}", Name ="GetNacionalidad")]
        public ActionResult Get(int id)
        {
            try
            {
                var Nacionalidad = context.nacionalidad.FirstOrDefault(g => g.id_nacionalidad == id.ToString());
                return Ok(Nacionalidad);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<NacionalidadController>
        [HttpPost]
        public ActionResult Post([FromBody] Nacionalidad Nacionalidad)
        {
            try
            {
                context.nacionalidad.Add(Nacionalidad);//agrega en tabla
                context.SaveChanges();//guarda
                return CreatedAtRoute("GetNacionalidad", new {id_nacionalidad = Nacionalidad.id_nacionalidad }, Nacionalidad);//regresa valores guardados y obtenemos el valor autoincrementable
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<NacionalidadController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Nacionalidad Nacionalidad)
        {
            try//se busca por id la comparativa a eliminar
            {
                if (Nacionalidad.id_nacionalidad == id.ToString())
                {
                    context.Entry(Nacionalidad).State = EntityState.Modified;
                    context.SaveChanges();//guarda
                    return CreatedAtRoute("GetNacionalidad", new { id_nacionalidad = Nacionalidad.id_nacionalidad }, Nacionalidad);//regresa valores guardados y obtenemos el valor autoincrementable
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

        // DELETE api/<NacionalidadController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var Nacionalidad = context.nacionalidad.FirstOrDefault(m => m.id_nacionalidad == id.ToString());
                if (Nacionalidad != null) 
                {
                    context.nacionalidad.Remove(Nacionalidad);
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
