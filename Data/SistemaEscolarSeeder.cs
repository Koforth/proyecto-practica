using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SistemaEscolar.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaEscolar.Data
{
    public static class SistemaEscolarSeeder
    {
        public static async Task InitializeAsync(SistemaEscolarContext context)
        {
            // Asegúrate de que la base de datos esté creada
            await context.Database.EnsureCreatedAsync();

            // Verificar si ya existen usuarios en la base de datos
            if (!context.Usuarios.Any())
            {
                // Crear usuario administrador por defecto
                var adminUser = new Usuario
                {
                    NombreUsuario = "admin",
                    Contrasena = "admin123", // Nota: en un sistema real, hashea esta contraseña
                    Rol = "Admin"
                };

                context.Usuarios.Add(adminUser);
            }

            // Puedes agregar otros datos iniciales, como actividades o alumnos de ejemplo
            if (!context.Actividades.Any())
            {
                context.Actividades.AddRange(
                    new Actividad { NombreActividad = "Matemáticas", Estado = EstadoActividad.Activo },
                    new Actividad { NombreActividad = "Ciencias", Estado = EstadoActividad.Activo }
                );
            }

            if (!context.Alumnos.Any())
            {
                context.Alumnos.Add(new Alumno
                {
                    NombreAlumno = "Juan Pérez",
                    Direccion = "Calle Falsa 123",
                    Cedula = "123456789",
                    Telefono = "5551234567",
                    Correo = "juan.perez@example.com",
                    FechaNac = new DateTime(2000, 1, 1),
                    FechaRegistro = DateTime.Now,
                    Estado = 1
                });
            }

            await context.SaveChangesAsync();
        }
    }
}
