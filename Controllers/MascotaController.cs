using Microsoft.AspNetCore.Mvc;
using PetCare.Data;
using PetCare.Models;


namespace PetCare.Controllers
{
    public class MascotaController : Controller
    {
        private readonly IMascotaRepository _repo;


        public MascotaController(IMascotaRepository repo)
        {
            _repo = repo;
        }


        
        public IActionResult Index()
        {
            var lista = _repo.ObtenerMascotas();
            return View(lista);
        }


        
        public IActionResult Registrar()
        {
            return View(new Mascota { FechaIngreso = DateTime.Today });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Guardar(Mascota modelo)
        {
            if (!ModelState.IsValid)
            {
                return View("Registrar", modelo);
            }


            _repo.AgregarMascota(modelo);
            TempData["Ok"] = $"Mascota '{modelo.Nombre}' registrada correctamente.";
            return RedirectToAction(nameof(Index));
        }
    }
}