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
    public class DocumentoController : ControllerBase
    {
        private readonly AppDbContext context;
        public DocumentoController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.documento.ToList());
            }
            catch (Exception ext)
            {
                return BadRequest(ext.Message);
            }
        }

        [HttpGet("{idDocumento}", Name = "GetDocumento")]
        public ActionResult Get(string idDocumento)
        {
            try
            {
                var curso = context.documento.FirstOrDefault(m => m.id_documento == idDocumento);
                return Ok(curso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Documento documento)
        {
            try
            {
                context.documento.Add(documento);
                context.SaveChanges();
                return CreatedAtRoute("GetDepartamento", new { idDocumento = documento.id_documento }, documento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{idDocumento}")]
        public ActionResult Put(string idDocumento, [FromBody] Documento documento)
        {
            try
            {
                if (documento.id_documento == idDocumento)
                {
                    context.Entry(documento).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetCurso", new { idCurso = documento.id_documento }, documento);
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

        [HttpDelete("{idDocumento}")]
        public ActionResult Delete(string idDocumento)
        {
            try
            {
                var documento = context.documento.FirstOrDefault(d => d.id_documento == idDocumento);
                if (documento != null)
                {
                    context.documento.Remove(documento);
                    context.SaveChanges();
                    return Ok(idDocumento);
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
