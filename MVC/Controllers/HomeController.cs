using Microsoft.AspNetCore.Mvc;

namespace MVC
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
