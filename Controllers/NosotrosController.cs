using Microsoft.AspNetCore.Mvc;

namespace WebFFACIL.Controllers
{
    public class NosotrosController : Controller
    {
        // GET: Nosotros
        public IActionResult Index()
        {
            return View();
        }

        // GET: Nosotros/Historia
        public IActionResult Historia()
        {
            return View();
        }
    }
}
