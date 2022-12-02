using Microsoft.AspNetCore.Mvc;

namespace SistemaWebEmpleado.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
