using Microsoft.AspNetCore.Mvc;

namespace AspPoznamky.Controllers
{
    public class DomovController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
