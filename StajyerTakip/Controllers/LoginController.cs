using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StajyerTakip.Models;

namespace StajyerTakip.Controllers
{
    public class LoginController : Controller
    {
        private readonly Context db;

        public LoginController(Context db)
        {
            this.db = db;
        }
        private bool durum = false;
        public IActionResult Index()
        {
            //Login indexe yönlendir.
            if(!durum)
                ViewData["Mesaj"] = "";

            return View();
        }

        [HttpPost]

        public IActionResult Index(Profil hesap)
        {
            if (db.Hesaplar.ToList().Find(x => (x.Email == hesap.KullaniciAdi || x.KullaniciAdi == hesap.KullaniciAdi) && x.Sifre == hesap.Sifre) == null)
            {
                durum = true;
                ViewData["Mesaj"] = "Kullanıcı adı ve/veya şifre hatalı.";
                return RedirectToAction("Index");

            }

            return Redirect("~/Home/Index");

        }
    }
}