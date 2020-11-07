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
    public class DepartamentoController : ControllerBase
    {
        private readonly AppDbContext context;
        public DepartamentoController(AppDbContext context) 
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult Get() 
        {
            try
            {
                return Ok(context.departamento.ToList());
            }
            catch (Exception ext) 
            {
                return BadRequest(ext.Message);
            }
        }

        [HttpGet("{idDepto}", Name = "GetDepartamento")]
        public ActionResult Get(string idDepto)
        {
            try
            {
                var departamento = context.departamento.FirstOrDefault(m => m.id_depto == idDepto);
                return Ok(departamento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Departamento departamento)
        {
            try
            {
                context.departamento.Add(departamento);
                context.SaveChanges();
                return CreatedAtRoute("GetDepartamento", new { idDepto = departamento.id_depto }, departamento);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{idDepto}")]
        public ActionResult Put(string idDepto, [FromBody] Departamento departamento)
        {
            try
            {
                if (departamento.id_depto == idDepto)
                {
                    context.Entry(departamento).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetDepartamento", new { idDepto = departamento.id_depto }, departamento);
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

        [HttpDelete("{idDepto}")]
        public ActionResult Delete(string idDepto)
        {
            try
            {
                var departamento = context.departamento.FirstOrDefault(d => d.id_depto == idDepto);
                if (departamento != null)
                {
                    context.departamento.Remove(departamento);
                    context.SaveChanges();
                    return Ok(idDepto);
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
