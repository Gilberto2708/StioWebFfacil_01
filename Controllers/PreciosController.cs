using Microsoft.AspNetCore.Mvc;

namespace WebFFACIL.Controllers
{
    public class PreciosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // GET: Precios/Calculadora
        public IActionResult Calculadora()
        {
            return View();
        }
    }
}
