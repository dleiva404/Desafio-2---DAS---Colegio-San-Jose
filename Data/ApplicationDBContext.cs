using Microsoft.EntityFrameworkCore;
using ColegioSanJose.Models;

namespace ColegioSanJose.Data
{
    // Contexto de la base de datos 

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Definición de las tablas en la base de datos

        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Expediente> Expedientes { get; set; }
    }
}