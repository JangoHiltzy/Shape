using Microsoft.AspNetCore.Mvc;

namespace Shape.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
