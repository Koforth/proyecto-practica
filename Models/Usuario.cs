using System.ComponentModel.DataAnnotations;

namespace SistemaEscolar.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreUsuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; }

        [Required]
        public string Rol { get; set; } // Ejemplo: "Admin", "Docente", "Estudiante"
    }
}
