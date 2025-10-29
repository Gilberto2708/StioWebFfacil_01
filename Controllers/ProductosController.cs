using Microsoft.AspNetCore.Mvc;

namespace WebFFACIL.Controllers
{
    public class ProductosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // GET: Productos/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Por ahora retornamos la vista, más adelante cargaremos desde BD
            ViewBag.ProductoId = id;
            return View();
        }

        // GET: Productos/Compare
        public IActionResult Compare()
        {
            return View();
        }
    }
}
