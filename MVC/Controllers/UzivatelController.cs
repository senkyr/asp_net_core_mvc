using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class UzivatelController : Controller
    {
        [HttpGet]
        public IActionResult Registrace()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Prihlaseni()
        {
            return View();
        }
    }
}
