using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Models;

namespace SistemaEscolar.Data
{
    public class SistemaEscolarContext : DbContext
    {
        public SistemaEscolarContext(DbContextOptions<SistemaEscolarContext> options)
            : base(options)
        {
        }

        // Tablas de la base de datos
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuraciones opcionales para definir los esquemas de las tablas
            modelBuilder.Entity<Alumno>().ToTable("Alumno");
            modelBuilder.Entity<Actividad>().ToTable("Actividad");
            modelBuilder.Entity<Usuario>().ToTable("Usuario");

            // Si necesitas definir llaves o restricciones adicionales, puedes hacerlo aquí
            modelBuilder.Entity<Usuario>().HasIndex(u => u.NombreUsuario).IsUnique();
        }
    }
}

