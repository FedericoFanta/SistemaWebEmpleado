using Microsoft.EntityFrameworkCore;
using SistemaWebEmpleado.Models;
using System;

namespace SistemaWebEmpleado.Data
{
    public class EmpleadoContext:DbContext
    {
        public EmpleadoContext(DbContextOptions<EmpleadoContext> options)
            : base(options)
        {
        }

        public DbSet<Empleado> Empleados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //OPCIONAL INICIALIZAR LA BASE DE DATOS CON 2 PERSONAS
            modelBuilder.Entity<Empleado>().HasData(
               new Empleado
               {
                   Id = 1,
                   Nombre = "Tayson",
                   Apellido = "Shuseps",
                   DNI= "18117000",
                   Legajo = "AA12345",
                   Titulo = "Administrativo"
               },
               new Empleado
               {
                   Id = 2,
                   Nombre = "Andrew",
                   Apellido = "Tippett",
                   DNI= "40125443",
                   Legajo = "AA54321",
                   Titulo = "Ingeniero"
               });
        }

    }
}
