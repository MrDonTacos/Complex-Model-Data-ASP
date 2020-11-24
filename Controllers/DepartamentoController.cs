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

        [HttpGet("{idDepartamento}", Name = "GetDepartamento")]
        public ActionResult Get(string idDepartamento)
        {
            try
            {
                var departamentoLocal = context.departamento.FirstOrDefault(m => m.id_departamento == idDepartamento);
                return Ok(departamentoLocal);
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
                if (departamento.id_departamento == null || departamento.id_departamento == "")
                throw new Exception("No puedes ingresar un ID nulo.");

                if (departamento.id_departamento.Length <= 3)
                throw new Exception("El ID no puede ser menor a 4 digitos.");

                if (departamento.id_departamento == null|| departamento.id_departamento == "")
                throw new Exception("No puedes ingresar un nombre en nulo.");

                var departamentoLocal = context.departamento.FirstOrDefault(m => m.id_departamento == departamento.id_departamento);
                if (departamentoLocal != null)
                throw new Exception("El ID " + departamentoLocal.id_departamento + " ya fue registrado.");

                context.departamento.Add(departamento);
                context.SaveChanges();
                return Ok("Se ha guardado correctamente");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{idDepartamento}")]
        public ActionResult Put(string idDepartamento, [FromBody] Departamento departamento)
        {
            try
            {
                if ((idDepartamento == "" || departamento.id_departamento == "") || (idDepartamento == null || departamento.id_departamento  == null))
                throw new Exception("No puedes enviar enviar una clave vacia");

                if (idDepartamento.Length <= 3 && departamento.id_departamento .Length <= 3)
                throw new Exception("Has ingresado la clave mal, debe ser de 4 digitos.");

                if (idDepartamento != departamento.id_departamento)
                throw new Exception("Las claves no corresponden.");

                context.Entry(departamento).State = EntityState.Modified;
                context.SaveChanges();
                return Ok("Fue modificado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{idDepartamento}")]
        public ActionResult Delete(string idDepartamento)
        {
            try
            {
                if (idDepartamento.Length <= 3)
                throw new Exception("Has ingresado una clave invalida.");

                if (idDepartamento == null || idDepartamento == "" || idDepartamento == "null")
                throw new Exception("No puedes enviar un registro vacio");

                var departamentoLocal = context.departamento.FirstOrDefault(d => d.id_departamento == idDepartamento);
                if (departamentoLocal == null )
                throw new Exception("No se ha encontrado el curso con clave " + idDepartamento);

                context.departamento.Remove(departamentoLocal);
                context.SaveChanges();
                return Ok("Se ha eliminado correctamente");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
