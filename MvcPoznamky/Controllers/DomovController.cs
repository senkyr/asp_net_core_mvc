using Microsoft.AspNetCore.Mvc;

namespace MvcPoznamky.Controllers
{
    public class DomovController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
