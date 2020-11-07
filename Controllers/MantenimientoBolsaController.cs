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
    public class MantenimientoBolsaController: ControllerBase
    {
        private readonly AppDbContext context;
        public MantenimientoBolsaController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.mantenimiento_bolsa.ToList())
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        // GET api/<MantenimientoBolsaController>/5
        [HttpGet("{id}", Name="GetMantenimientoBolsa")]
        public ActionResult Get(int id) 
        {
            try
            {
                var mantenimiento = context.mantenimiento_bolsa.FirsOrDefault(g => g.id == id);
                return Ok(mantenimiento);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<MantenimientoBolsaController>
        [HttpPost]
        public ActionResult Post([FromBody] MantenimientoBolsa matenimiento)
        {
            try
            {
                context.mantenimiento_bolsa.Add(matenimiento);
                context.SaveChanges();
                return CreatedAtRoute("GetMantenimientoBolsa", new {id=matenimiento.id }, matenimiento);//regresa valores guardados y obtenemos el valor autoincrementable
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<MantenimientoBolsaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] MantenimientoBolsa matenimiento)
        {
            try
            {
                if (matenimiento.id == id)
                {
                    context.Entry(materia).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetMantenimientoBolsa", new { id = matenimiento.id }, mantenimiento);//regresa valores guardados y obtenemos el valor autoincrementable
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

        // DELETE api/<MantenimientoBolsaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var matenimiento = context.mantenimiento_bolsa.FirstOrDefault(m => m.id == id);
                if (matenimiento != null) 
                {
                    context.mantenimiento_bolsa.Remove(matenimiento);
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