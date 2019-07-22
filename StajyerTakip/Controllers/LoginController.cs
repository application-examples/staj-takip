using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StajyerTakip.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace StajyerTakip.Controllers
{
    public class LoginController : Controller
    {
        private readonly Context db;

        public LoginController(Context db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("kadi") != null)
            {
                return Redirect("~/Home/Index");
            }
                return View();
        }

        [HttpPost]
        public IActionResult Index(Profil hesap)
        {
            var hesap1 = db.Hesaplar.ToList().Find(x => (x.Email == hesap.KullaniciAdi || x.KullaniciAdi == hesap.KullaniciAdi) && x.Sifre == hesap.Sifre);
            if (hesap1 == null)
            {
                ViewData["Mesaj"] = "Kullanıcı adı ve/veya şifre hatalı.";
                return RedirectToAction("Index");
            }
            HttpContext.Session.SetString("kadi", hesap1.KullaniciAdi);
            HttpContext.Session.SetInt32("profilid", hesap1.ID);
            HttpContext.Session.SetInt32("yetki", hesap1.Rol);
            if (hesap1.Rol == 4)
                HttpContext.Session.SetInt32("id", db.Stajyerler.ToList().Find(x => x.ProfilID == hesap1.ID).ID);
            if(hesap1.Rol == 3)
                HttpContext.Session.SetInt32("id", db.BirimKoordinatorleri.ToList().Find(x => x.ProfilID == hesap1.ID).ID);
            if(hesap1.Rol == 2)
                HttpContext.Session.SetInt32("id", db.Moderatorler.ToList().Find(x => x.ProfilID == hesap1.ID).ID);
            //TODO buraya sistem yöneticisi de eklenecek.
            return Redirect("~/Home/Index");

        }
    }
}