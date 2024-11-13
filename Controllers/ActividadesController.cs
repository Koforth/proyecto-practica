using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Data;
using SistemaEscolar.Models;
using System.Threading.Tasks;
using System.Linq;

namespace SistemaEscolar.Controllers
{
    public class ActividadesController : Controller
    {
        private readonly SistemaEscolarContext _context;

        public ActividadesController(SistemaEscolarContext context)
        {
            _context = context;
        }

        // GET: Actividades
        public async Task<IActionResult> Index()
        {
            return View(await _context.Actividades.ToListAsync());
        }

        // GET: Actividades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var actividad = await _context.Actividades.FirstOrDefaultAsync(m => m.ActividadId == id);
            if (actividad == null) return NotFound();
            return View(actividad);
        }

        // GET: Actividades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Actividades/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActividadId,NombreActividad,Estado")] Actividad actividad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actividad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actividad);
        }

        // GET: Actividades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var actividad = await _context.Actividades.FindAsync(id);
            if (actividad == null) return NotFound();
            return View(actividad);
        }

        // POST: Actividades/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActividadId,NombreActividad,Estado")] Actividad actividad)
        {
            if (id != actividad.ActividadId) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actividad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActividadExists(actividad.ActividadId)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(actividad);
        }

        // GET: Actividades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var actividad = await _context.Actividades.FirstOrDefaultAsync(m => m.ActividadId == id);
            if (actividad == null) return NotFound();
            return View(actividad);
        }

        // POST: Actividades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actividad = await _context.Actividades.FindAsync(id);
            if (actividad == null) return NotFound(); // Verificación adicional
            _context.Actividades.Remove(actividad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActividadExists(int id)
        {
            return _context.Actividades.Any(e => e.ActividadId == id);
        }
    }
}

