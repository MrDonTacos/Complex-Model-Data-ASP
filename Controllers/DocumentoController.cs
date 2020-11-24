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
                if (documento.id_documento == null || documento.id_documento == "")
                throw new Exception("No puedes ingresar un ID nulo.");

                if (documento.id_documento.Length <= 3)
                throw new Exception("El ID no puede ser menor a 4 digitos.");

                if (documento.documento == null|| documento.documento == "")
                throw new Exception("No puedes ingresar un nombre en nulo.");

                var documentoLocal = context.documento.FirstOrDefault(m => m.id_documento == documento.id_documento);
                if (documentoLocal != null)
                throw new Exception("El ID " + documento.id_documento + " ya fue registrado.");

                /*var documentoLocal = context.documento.FirstOrDefault(m => m.id_documento == documento.id_documento);
                if (documentoLocal != null)
                throw new Exception("El ID ya fue registrado");*/

                context.documento.Add(documento);
                context.SaveChanges();
                return Ok("Se ha registrado Correctamente");
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
                if ((idDocumento == "" || documento.id_documento == "") || (idDocumento == null || documento.id_documento == null))
                throw new Exception("No puedes enviar enviar una clave vacia");

                if (idDocumento.Length <= 3 && documento.id_documento.Length <= 3)
                throw new Exception("Has ingresado la clave mal, debe ser de 4 digitos.");

                if (idDocumento != documento.id_documento)
                throw new Exception("Las claves no corresponden.");

                context.Entry(documento).State = EntityState.Modified;
                context.SaveChanges();
                return Ok("Fue modificado correctamente");
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
                if (idDocumento.Length <= 3)
                throw new Exception("Has ingresado una clave invalida.");

                if (idDocumento == null || idDocumento == "" || idDocumento == "null")
                throw new Exception("No puedes enviar un registro vacio");

                var documentoLocal = context.documento.FirstOrDefault(d => d.id_documento == idDocumento);
                if (documentoLocal == null )
                throw new Exception("No se ha encontrado el curso con clave "+ idDocumento);

                context.documento.Remove(documentoLocal);
                context.SaveChanges();
                return Ok("Se ha eliminado el curso correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
