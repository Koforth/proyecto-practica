using Microsoft.AspNetCore.Mvc;
using SistemaEscolar.Models;
using SistemaEscolar.ViewModels;
using System.Linq;
using SistemaEscolar.Data;


namespace SistemaEscolar.Controllers
{
    public class HomeController : Controller
    {
        private readonly SistemaEscolarContext _context;

        public HomeController(SistemaEscolarContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var viewModel = new HomeViewModel
            {
                Actividades = _context.Actividades.Take(5).ToList(),
                Alumnos = _context.Alumnos.Take(5).ToList(),
                Usuarios = _context.Usuarios.Take(5).ToList()
            };

            return View(viewModel);
        }
    }
}
