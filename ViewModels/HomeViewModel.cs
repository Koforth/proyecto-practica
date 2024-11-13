using SistemaEscolar.Models;
using System.Collections.Generic;

namespace SistemaEscolar.ViewModels
{
    public class HomeViewModel
    {
        public List<Actividad> Actividades { get; set; }
        public List<Alumno> Alumnos { get; set; }
        public List<Usuario> Usuarios { get; set; }
    }
}
