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
                context.perfil.Add(perfil);
                context.SaveChanges();
                return CreatedAtRoute("GetDepartamento", new { idPerfil = perfil.id_perfil }, perfil);
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
                if (perfil.id_perfil == idPerfil)
                {
                    context.Entry(perfil).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetPerfil", new { idPerfil = perfil.id_perfil }, perfil);
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

        [HttpDelete("{idPerfil}")]
        public ActionResult Delete(string idPerfil)
        {
            try
            {
                var perfil = context.perfil.FirstOrDefault(d => d.id_perfil == idPerfil);
                if (perfil != null)
                {
                    context.perfil.Remove(perfil);
                    context.SaveChanges();
                    return Ok(idPerfil);
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
