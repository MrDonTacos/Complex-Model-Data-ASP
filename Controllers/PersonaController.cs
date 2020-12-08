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
    public class PersonaController: ControllerBase
    {
        private readonly AppDbContext context;
        public PersonaController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.persona.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<persona>/5
        [HttpGet("{id}", Name="GetPersona")]
        public ActionResult Get(int id) 
        {
            try
            {
                // var personas = context.persona.FirsOrDefault(g => g.curp == id);
                return Ok();
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<persona>
        [HttpPost]
        public ActionResult Post([FromBody] Persona persona)
        {
            try
            {
                context.persona.Add(persona);
                context.SaveChanges();
                return CreatedAtRoute("GetPersona", new {curp = persona.curp }, persona);//regresa valores guardados y obtenemos el valor autoincrementable
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<persona>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Persona persona)
        {
            try
            {
                if (persona.curp == id)
                {
                    context.Entry(persona).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetPersona", new { curp = persona.curp }, persona);
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

        // DELETE api/<persona>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            try
            {
                var persona = context.persona.FirstOrDefault(m => m.curp == id);
                if (persona != null) 
                {
                    context.persona.Remove(persona);
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