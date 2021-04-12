using Microsoft.AspNetCore.Mvc;
using MvcPoznamky.Models;
using MvcPoznamky.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace MvcPoznamky.Controllers
{
    public class PoznamkaController : Controller
    {
        private readonly MvcPoznamkyContext _context;

        public PoznamkaController(MvcPoznamkyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Vytvoreni()
        {
            ViewData["Uzivatel"] = HttpContext.Session.GetString("Uzivatel");

            return View();
        }
        [HttpPost]
        [ActionName("Vytvoreni")]
        public IActionResult VytvoreniZpracovani(string autor, string text)
        {
            if (text == null || text.Trim().Length == 0)
                return RedirectToAction("Vytvoreni", "Poznamka");

            _context.Add(new Poznamka() { Autor = _context.Uzivatele.Where(u => u.Jmeno == autor).FirstOrDefault(), Text = text, DatumVytvoreni = DateTime.UtcNow });
            _context.SaveChanges();

            return RedirectToAction("Profil", "Uzivatel");
        }
    }
}
