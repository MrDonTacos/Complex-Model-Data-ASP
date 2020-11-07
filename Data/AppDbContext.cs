using Microsoft.EntityFrameworkCore;
using schoolpractice.Models;
//using schoolpractice.Models;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace schoolpractice.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Materia> materia { get; set; }//nombre de modelo con nombre de tabla db
        public DbSet<Departamento> departamento { get; set; }
        public DbSet<Perfil> perfil { get; set; }
        public DbSet<Puesto> puesto{ get; set; }
        public DbSet<Curso> curso { get; set; }
        public DbSet<EmpleadoCurso> empleado_curso { get; set; }
        public DbSet<Escolaridad> escolaridad{ get; set; }
        public DbSet<Documento> documento { get; set; }
        public DbSet<Categoria> categoria{ get; set; }
        public DbSet<Horario> horario { get; set; }
        public DbSet<EmpleadoDocumento> empleadoDocumento { get; set; }
        public DbSet<Experiencia> experiencia { get; set; }
        public DbSet<Nacionalidad> nacionalidad { get; set; }
        public DbSet<MantenimientoBolsa> mantenimiento_bolsa {get; set;}
        public DbSet<Persona> persona {get; set;}

    }
}
