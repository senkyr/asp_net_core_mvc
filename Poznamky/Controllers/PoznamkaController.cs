using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AspPoznamky.Data;
using AspPoznamky.Models;
using System;
using System.Linq;

namespace AspPoznamky.Controllers
{
    public class PoznamkaController : Controller
    {
        private readonly AspPoznamkyContext _context;

        public PoznamkaController(AspPoznamkyContext context)
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

            Uzivatel uzivatel = _context.Uzivatele
                .Where(u => u.Jmeno == HttpContext.Session.GetString("Uzivatel"))
                .FirstOrDefault();

            if (uzivatel != null)
            {
                _context.Poznamky.Add(new Poznamka() {
                    Autor = uzivatel,
                    Text = text,
                    DatumVytvoreni = DateTime.UtcNow
                });
                _context.SaveChanges();
            }

            return RedirectToAction("Profil", "Uzivatel");
        }

        public IActionResult Smazani(int id)
        {
            Poznamka poznamka = _context.Poznamky
                .Where(p => p.Id == id)
                .First();

            Uzivatel autor = _context.Uzivatele
                .Where(u => u == poznamka.Autor)
                .First();

            Uzivatel prihlaseny = _context.Uzivatele
                .Where(u => u.Jmeno == HttpContext.Session.GetString("Uzivatel"))
                .First();

            if (autor == prihlaseny)
            {
                _context.Remove(poznamka);
                _context.SaveChanges();
            }

            return RedirectToAction("Profil", "Uzivatel");
        }

        [HttpGet]
        public IActionResult Uprava(int id)
        {
            Poznamka poznamka = _context.Poznamky
                .Where(p => p.Id == id)
                .First();

            Uzivatel autor = _context.Uzivatele
                .Where(u => u == poznamka.Autor)
                .First();

            Uzivatel prihlaseny = _context.Uzivatele
                .Where(u => u.Jmeno == HttpContext.Session.GetString("Uzivatel"))
                .First();

            if(autor == prihlaseny)
            {
                return View(poznamka);
            }

            return RedirectToAction("Profil", "Uzivatel");
        }
    }
}
