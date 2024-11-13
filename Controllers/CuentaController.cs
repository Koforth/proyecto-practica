using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Data;
using SistemaEscolar.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SistemaEscolar.Controllers
{
    public class CuentaController : Controller
    {
        private readonly SistemaEscolarContext _context;

        public CuentaController(SistemaEscolarContext context)
        {
            _context = context;
        }

        // GET: Cuenta/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Cuenta/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string nombreUsuario, string contrasena)
        {
            if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(contrasena))
            {
                ModelState.AddModelError("", "Usuario o contraseña incorrectos.");
                return View();
            }

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.NombreUsuario == nombreUsuario && u.Contrasena == contrasena);
            if (usuario == null)
            {
                ModelState.AddModelError("", "Usuario o contraseña incorrectos.");
                return View();
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuario.NombreUsuario),
                new Claim(ClaimTypes.Role, usuario.Rol)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index", "Alumnos"); // Redirigir al controlador principal
        }

        // POST: Cuenta/Logout
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Cuenta");
        }
    }
}
