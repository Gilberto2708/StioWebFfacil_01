using Microsoft.AspNetCore.Mvc;
using WebFFACIL.Models;

namespace WebFFACIL.Controllers
{
    public class DistribuidoresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        // GET: Distribuidores/Registro
        public IActionResult Registro()
        {
            return View();
        }

        // POST: Distribuidores/Registro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registro(DistribuidorViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Aquí puedes agregar la lógica para:
                // 1. Enviar email al equipo de distribuidores
                // 2. Guardar en base de datos
                // 3. Enviar notificación

                ViewBag.Success = true;

                // Limpiar el formulario
                ModelState.Clear();
                return View(new DistribuidorViewModel());
            }

            return View(model);
        }

        // GET: Distribuidores/Beneficios
        public IActionResult Beneficios()
        {
            return View();
        }
    }
}
