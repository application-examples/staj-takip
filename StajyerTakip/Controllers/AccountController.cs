using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StajyerTakip.Controllers
{
    public class AccountController : Controller
    {
        private readonly Context db;

        public AccountController(Context _db)
        {
            db = _db;
        }


        public  JsonResult UsernameCheck(string username)
        {
            return db.Hesaplar.Where(x => x.KullaniciAdi == username).SingleOrDefault() != null ? Json(true) : Json(false);
        }

        public JsonResult EmailCheck(string email)
        {
            return db.Hesaplar.Where(x => x.Email == email).SingleOrDefault() != null ? Json(true) : Json(false);
        }

        public JsonResult Duyurular()
        {
            return Json(db.Duyurular.ToList());
        }

        public IActionResult Deneme()
        {
            return View();
        }
    }
}