using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class DomovController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
