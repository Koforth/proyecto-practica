using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaEscolar.Models
{
    public class Alumno
    {
        [Key]
        public int AlumnoId { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreAlumno { get; set; }

        // Edad puede ser calculada desde FechaNac, por lo que es opcional incluirlo como campo estático
        //[Required]  // Si se mantiene, debería ser actualizada al cambiar FechaNac
        //public int Edad { get; set; } 

        [StringLength(100)]
        public string Direccion { get; set; }

        [Required]
        [StringLength(20)]
        public string Cedula { get; set; }

        [Required]
        [Phone] // Usa la validación de número de teléfono si lo cambias a string
        public string Telefono { get; set; }  // Cambiado a string para soportar formato específico

        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        public DateTime FechaNac { get; set; }

        [Required]
        public DateTime FechaRegistro { get; set; }

        // 1 = Activo por defecto
        public int Estado { get; set; } = 1;
    }
}

