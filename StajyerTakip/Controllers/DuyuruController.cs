using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StajyerTakip.Attributes;
using StajyerTakip.Models;

namespace StajyerTakip.Controllers
{
    public class DuyuruController : Controller
    {
        private readonly Context db;

        public DuyuruController(Context _db)
        {
            db = _db;
        }

        [StajyerUstYetki]
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        [StajyerUstYetki]
        public IActionResult Ekle(Duyuru duyuru)
        {
            var yetki = (int)HttpContext.Session.GetInt32("yetki");
            var id = (int) HttpContext.Session.GetInt32("id");

            duyuru.EklenmeTarihi = DateTime.UtcNow;
            duyuru.GuncellenmeTarihi = DateTime.UtcNow;
            duyuru.EkleyenID = id;
            duyuru.EkleyenYetki = yetki;

            db.Duyurular.Add(duyuru);
            db.SaveChanges();

            return Redirect("~/Duyuru/Listele");
        }

        [StajyerUstYetki]
        public IActionResult Duzenle(int id)
        {
            Duyuru duyuru = db.Duyurular.Find(id);
            return View(duyuru);

        }

        [HttpPost]
        [StajyerUstYetki]
        public IActionResult Duzenle(Duyuru duyuru,int id)
        {
            Duyuru anaveri = db.Duyurular.Find(id);

            anaveri.GuncellenmeTarihi = DateTime.UtcNow;
            anaveri.Baslik = duyuru.Baslik;
            anaveri.Icerik = duyuru.Icerik;

            db.SaveChanges();
            return Redirect("~/Duyuru/Listele");
        }

        [StajyerUstYetki]
        public IActionResult Sil(int id)
        {
            Duyuru anaveri = db.Duyurular.Find(id);
            return View(anaveri);

        }

        [HttpPost]
        [ActionName("Sil")]
        [StajyerUstYetki]
        public IActionResult Silme(int id)
        {
            Duyuru duyuru = db.Duyurular.Find(id);

            db.Duyurular.Remove(duyuru);
            db.SaveChanges();
            return Redirect("~/Duyuru/Listele");
        }

        public IActionResult Listele()
        {
            List<Duyuru> duyurular = db.Duyurular.ToList();
            return View(duyurular);

        }

        public IActionResult Goruntule(int id)
        {
            Duyuru duyuru = db.Duyurular.Find(id);
            var yetki = HttpContext.Session.GetInt32("yetki");
            var kisiid = (int)HttpContext.Session.GetInt32("id");

            if(yetki == 3)
            {
                BirimKoordinatoru koordinator = db.BirimKoordinatorleri.Where(x => x.ID == kisiid).Include(x => x.Profil).SingleOrDefault();
                ViewBag.EkleyenKisi = koordinator.Profil.Ad + " " + koordinator.Profil.Soyad;
            }
            if (yetki == 2)
            {
                Moderator moderator = db.Moderatorler.Where(x => x.ID == kisiid).Include(x => x.Profil).SingleOrDefault();
                ViewBag.EkleyenKisi = moderator.Profil.Ad + " " + moderator.Profil.Soyad;
            }
            if (yetki == 1)
            {
                SistemYoneticisi yonetici = db.SistemYoneticisi.Where(x => x.ID == kisiid).Include(x => x.Profil).SingleOrDefault();
                ViewBag.EkleyenKisi = yonetici.Profil.Ad + " " + yonetici.Profil.Soyad;
            }
            return View(duyuru);
        }
       
    }
}