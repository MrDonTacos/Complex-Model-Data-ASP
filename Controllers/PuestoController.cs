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
                var puesto = context.puesto.FirstOrDefault(m => m.id_puesto == idPuesto);
                return Ok(puesto);
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
                context.puesto.Add(puesto);
                context.SaveChanges();
                return CreatedAtRoute("GetPuesto", new { idPuesto = puesto.id_puesto }, puesto);
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
                if (puesto.id_puesto == idPuesto)
                {
                    context.Entry(puesto).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("Getpuesto", new { idPuesto = puesto.id_puesto }, puesto);
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

        [HttpDelete("{idPuesto}")]
        public ActionResult Delete(string idPuesto)
        {
            try
            {
                var puesto = context.puesto.FirstOrDefault(d => d.id_puesto == idPuesto);
                if (puesto != null)
                {
                    context.puesto.Remove(puesto);
                    context.SaveChanges();
                    return Ok(idPuesto);
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
