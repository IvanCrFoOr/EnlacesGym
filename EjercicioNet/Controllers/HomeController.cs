using Microsoft.AspNetCore.Mvc;

namespace EjercicioNet.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
