using Microsoft.AspNetCore.Mvc;
using MvcPoznamky.Models;
using MvcPoznamky.Data;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace MvcPoznamky.Controllers
{
    public class UzivatelController : Controller
    {
        private readonly MvcPoznamkyContext _context;

        public UzivatelController(MvcPoznamkyContext context)
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

            _context.Add(new Uzivatel() { Jmeno = jmeno, Heslo = BCrypt.Net.BCrypt.HashPassword(heslo) });
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
            Uzivatel u = _context.Uzivatele.Where(u => u.Jmeno == jmeno).FirstOrDefault();

            if (u == null)
                return RedirectToAction("Prihlaseni", "Uzivatel");

            if (!BCrypt.Net.BCrypt.Verify(heslo, u.Heslo))
                return RedirectToAction("Prihlaseni", "Uzivatel");

            HttpContext.Session.SetString("Uzivatel", jmeno);

            return RedirectToAction("Profil", "Uzivatel");
        }

        public IActionResult Profil()
        {
            string jmeno = HttpContext.Session.GetString("Uzivatel");

            Uzivatel uzivatel = _context.Uzivatele.Where(u => u.Jmeno == jmeno).FirstOrDefault();

            if (uzivatel == null)
                return RedirectToAction("Prihlaseni", "Uzivatel");

            return View(uzivatel);
        }

        public IActionResult Odhlaseni()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Domov");
        }
    }
}
