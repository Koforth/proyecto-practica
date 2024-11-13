using System.ComponentModel.DataAnnotations;

namespace SistemaEscolar.Models
{
    public enum EstadoActividad
    {
        Inactivo = 0,
        Activo = 1,
        Completado = 2
        // Agrega más estados según sea necesario
    }

    public class Actividad
    {
        [Key]
        public int ActividadId { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreActividad { get; set; }

        // Estado de la actividad: por defecto es Activo
        public EstadoActividad Estado { get; set; } = EstadoActividad.Activo;
    }
}

