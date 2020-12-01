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
    public class MantenimientoEmpleadoController : ControllerBase
    {
        private readonly AppDbContext context;
        public MantenimientoEmpleadoController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.mantenimiento_empleado.ToList());
            }
            catch (Exception ext)
            {
                return BadRequest(ext.Message);
            }
        }

        [HttpGet("{id}", Name = "GetMantenimiento")]
        public ActionResult Get(int? id)
        {
            try
            {
                var matenimientoEmpleado = context.mantenimiento_empleado.FirstOrDefault(m => m.id == id);
                return Ok(matenimientoEmpleado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
