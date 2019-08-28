using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StajyerTakip.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Net;

namespace StajyerTakip.Controllers
{
    public class LoginController : Controller
    {
        private readonly Context db;
        public LoginController(Context db)
        {
            this.db = db;
            
        }

        public IActionResult TestView()
        {
            return View();
        }

        public JsonResult Duyurular()
        {
            Console.WriteLine(DateTime.Now);
            List<Duyuru> a = new List<Duyuru>
            {
                new Duyuru{ID=1,Baslik="ss"},
                new Duyuru{ID=1,Baslik="ss"}
            };

            Console.WriteLine(DateTime.Now);

            return Json(a);

        }

        [HttpPost]
        public JsonResult GetSessionValues()
        {
            var session = new {
                session_id = HttpContext.Session.GetInt32("id"),
                session_auth_id = HttpContext.Session.GetInt32("yetki"),
                session_profile_id = HttpContext.Session.GetInt32("profilid")
            };
            return Json(session);
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
            SHA1 sha = new SHA1CryptoServiceProvider();
            var data = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(hesap.Sifre)));
            var hesap1 = db.Hesaplar.ToList().Find(x => (x.Email == hesap.KullaniciAdi || x.KullaniciAdi == hesap.KullaniciAdi) && x.Sifre == data);
            if (hesap1 == null)
            {
                ViewData["Mesaj"] = "Kullanıcı adı ve/veya şifre hatalı.";
                return RedirectToAction("Index");
            }
            HttpContext.Session.SetString("kadi", hesap1.KullaniciAdi);
            HttpContext.Session.SetInt32("profilid", hesap1.ID);
            HttpContext.Session.SetInt32("yetki", hesap1.Rol);
            HttpContext.Session.SetString("profilfotograf", hesap1.Fotograf ?? "/images/man.png");


            if (hesap1.Rol == 4)
                HttpContext.Session.SetInt32("id", db.Stajyerler.ToList().Find(x => x.ProfilID == hesap1.ID).ID);
            if (hesap1.Rol == 3)
                HttpContext.Session.SetInt32("id", db.BirimKoordinatorleri.ToList().Find(x => x.ProfilID == hesap1.ID).ID);
            if (hesap1.Rol == 2)
                HttpContext.Session.SetInt32("id", db.Moderatorler.ToList().Find(x => x.ProfilID == hesap1.ID).ID);
            if (hesap1.Rol == 1)
                HttpContext.Session.SetInt32("id", db.SistemYoneticisi.ToList().Find(x => x.ProfilID == hesap1.ID).ID);
            return Redirect("~/Home/Index");

        }
    }
}