using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AspPoznamky.Data;
using AspPoznamky.Models;
using System.Collections.Generic;
using System.Linq;

namespace AspPoznamky.Controllers
{
    public class UzivatelController : Controller
    {
        private readonly AspPoznamkyContext _context;

        public UzivatelController(AspPoznamkyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Registrace()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Registrace")]
        public IActionResult RegistraceZpracovani(string jmeno, string heslo, string heslo_kontrola)
        {
            if (heslo.Trim() == "" || heslo_kontrola.Trim() == "" || heslo != heslo_kontrola)
                return RedirectToAction("Registrace", "Uzivatel");
            
            if(_context.Uzivatele.Where(u => u.Jmeno == jmeno).FirstOrDefault() != null)
                return RedirectToAction("Registrace", "Uzivatel");

            _context.Add(new Uzivatel {
                Jmeno = jmeno,
                Heslo = BCrypt.Net.BCrypt.HashPassword(heslo)
            });
            _context.SaveChanges();

            return RedirectToAction("Prihlaseni", "Uzivatel");
        }

        [HttpGet]
        public IActionResult Prihlaseni()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Prihlaseni")]
        public IActionResult PrihlaseniZpracovani(string jmeno, string heslo)
        {
            Uzivatel uzivatel = _context.Uzivatele
                .Where(u => u.Jmeno == jmeno)
                .FirstOrDefault();

            if (uzivatel == null)
                return RedirectToAction("Prihlaseni", "Uzivatel");

            if (!BCrypt.Net.BCrypt.Verify(heslo, uzivatel.Heslo))
                return RedirectToAction("Prihlaseni", "Uzivatel");

            HttpContext.Session.SetString("Uzivatel", jmeno);

            return RedirectToAction("Profil", "Uzivatel");
        }

        public IActionResult Profil()
        {
            string jmeno = HttpContext.Session.GetString("Uzivatel");

            Uzivatel uzivatel = _context.Uzivatele
                .Where(u => u.Jmeno == jmeno)
                .FirstOrDefault();

            if (uzivatel == null)
                return RedirectToAction("Prihlaseni", "Uzivatel");

            return View(uzivatel);
        }

        public IActionResult Odhlaseni()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Domov");
        }

        [HttpGet]
        public IActionResult Zruseni()
        {
            Uzivatel uzivatel = _context.Uzivatele
                .Where(u => u.Jmeno == HttpContext.Session.GetString("Uzivatel"))
                .FirstOrDefault();

            if(uzivatel == null)
                return RedirectToAction("Prihlaseni", "Uzivatel");

            return View(uzivatel);
        }

        [HttpPost]
        [ActionName("Zruseni")]
        public IActionResult ZruseniZpracovani(int id, string heslo)
        {
            Uzivatel uzivatel = _context.Uzivatele
                .Where(u => u.Id == id)
                .FirstOrDefault();

            if (uzivatel == null)
                return RedirectToAction("Prihlaseni", "Uzivatel");

            if (!BCrypt.Net.BCrypt.Verify(heslo, uzivatel.Heslo))
                return RedirectToAction("Zruseni", "Uzivatel");

            Poznamka[] poznamky = _context.Poznamky
                .Where(p => p.Autor == uzivatel)
                .ToArray();

            _context.Poznamky
                .RemoveRange(poznamky);
            _context.Uzivatele
                .Remove(uzivatel);
            _context.SaveChanges();

            return RedirectToAction("Odhlaseni", "Uzivatel");
        }
    }
}
