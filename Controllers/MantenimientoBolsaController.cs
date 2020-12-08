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
                return Ok(context.mantenimiento_bolsa.ToList());
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
                // var mantenimiento = context.mantenimiento_bolsa.FirsOrDefault(g => g.id == id);
                return Ok();
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<MantenimientoBolsaController>
        [HttpPost]
        public ActionResult Post([FromBody] MantenimientoFuerte matenimiento)
        {
            try
            {
                Persona persona = new Persona();
                MantenimientoBolsa bolsa = new MantenimientoBolsa ();
                persona = new Persona{
                    curp = matenimiento.CURP,
                    nombre = matenimiento.Nombre,
                    apellido_materno = matenimiento.APaterno,
                    apellid_paterno = matenimiento.AMaterno,
                    id_fk_sexo = matenimiento.Sexo,
                    fecha_nacimiento = matenimiento.FechaNacimiento,
                    direccion = matenimiento.Direccion,
                    telefono = matenimiento.Teléfono,
                    id_fk_nacionalidad = matenimiento.Nacionalidad,
                };
                
               var p = context.persona.Add(persona);

                context.SaveChanges();
                bolsa = new MantenimientoBolsa{
                    id_persona = matenimiento.CURP,
                    id_perfil = matenimiento.Perfil,
                    id_experiencia = matenimiento.Experiencia,
                    id_escolaridad = matenimiento.Escolaridad,
                    id_estatus = matenimiento.Estatus,
                    id_documentos = null,
                    observaciones = matenimiento.Observaciones,
                    fecha_ingreso = matenimiento.FechaIngreso
                };

                var EntityBolsa = context.mantenimiento_bolsa.Add(bolsa);
                context.SaveChanges();
                return CreatedAtRoute("GetMantenimientoBolsa", new {id=EntityBolsa.Entity.id }, matenimiento);//regresa valores guardados y obtenemos el valor autoincrementable
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<MantenimientoBolsaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] MantenimientoFuerte matenimiento)
        {
            try
            {
                if (matenimiento.id == id)
                {
                      Persona persona = new Persona();
                MantenimientoBolsa bolsa = new MantenimientoBolsa ();
                persona = new Persona{
                    curp = matenimiento.CURP,
                    nombre = matenimiento.Nombre,
                    apellido_materno = matenimiento.APaterno,
                    apellid_paterno = matenimiento.AMaterno,
                    id_fk_sexo = matenimiento.Sexo,
                    fecha_nacimiento = matenimiento.FechaNacimiento,
                    direccion = matenimiento.Direccion,
                    telefono = matenimiento.Teléfono,
                    id_fk_nacionalidad = matenimiento.Nacionalidad,
                };

                bolsa = new MantenimientoBolsa{
                    id_persona = matenimiento.CURP,
                    id_perfil = matenimiento.Perfil,
                    id_experiencia = matenimiento.Experiencia,
                    id_escolaridad = matenimiento.Escolaridad,
                    id_estatus = matenimiento.Estatus,
                    id_documentos = null,
                    observaciones = matenimiento.Observaciones,
                    fecha_ingreso = matenimiento.FechaIngreso
                };

                    context.Entry(persona).State = EntityState.Modified;
                    context.Entry(bolsa).State = EntityState.Modified;
                    context.SaveChanges();
                    return Ok();
                   // return CreatedAtRoute("GetMantenimientoBolsa", new { id = matenimiento.id }, mantenimiento);//regresa valores guardados y obtenemos el valor autoincrementable
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