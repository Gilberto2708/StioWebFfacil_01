using Microsoft.AspNetCore.Mvc;
using WebFFACIL.Models;

namespace WebFFACIL.Controllers
{
    public class ContactoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // POST: Contacto/Enviar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Enviar(ContactoViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Aquí puedes agregar la lógica para:
                // 1. Enviar email
                // 2. Guardar en base de datos
                // 3. Enviar a un CRM

                // Por ahora solo mostramos un mensaje de éxito
                ViewBag.Success = true;

                // Limpiar el formulario
                ModelState.Clear();
                return View(new ContactoViewModel());
            }

            return View(model);
        }
    }
}
