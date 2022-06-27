using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto1.Data;
using Proyecto1.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Proyecto1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDBContext _applicationDBContext;

        public HomeController(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _applicationDBContext.Usuario.ToListAsync());
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _applicationDBContext.Usuario.Add(usuario);
                await _applicationDBContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var usuario = _applicationDBContext.Usuario.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            else
            {
                return View(usuario);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _applicationDBContext.Update(usuario);
                await _applicationDBContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        [HttpGet]
        public IActionResult Detalle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var usuario = _applicationDBContext.Usuario.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            else
            {
                return View(usuario);
            }
        }

        [HttpGet]
        public IActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var usuario = _applicationDBContext.Usuario.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            else
            {
                return View(usuario);
            }
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            var usuario = await _applicationDBContext.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return View();
            }
            _applicationDBContext.Usuario.Remove(usuario);
            await _applicationDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
