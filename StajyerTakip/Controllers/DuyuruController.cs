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
    [GirisKontrol]
    public class DuyuruController : Controller
    {
        private readonly Context db;

        public DuyuruController(Context _db)
        {
            db = _db;
        }


        [HttpPost]
        [StajyerUstYetki]
        public JsonResult Ekle(Duyuru duyuru)
        {
            var yetki = (int)HttpContext.Session.GetInt32("yetki");
            var id = (int)HttpContext.Session.GetInt32("profilid");
            duyuru.EklenmeTarihi = DateTime.UtcNow;
            duyuru.GuncellenmeTarihi = DateTime.UtcNow;
            duyuru.EkleyenID = id;
            duyuru.EkleyenYetki = yetki;

            db.Duyurular.Add(duyuru);
            db.SaveChanges();

            return Json(true);
        }


        [HttpPost]
        [StajyerUstYetki]
        public JsonResult Duzenle(Duyuru duyuru, int id)
        {
            Duyuru anaveri = db.Duyurular.Find(id);

            anaveri.GuncellenmeTarihi = DateTime.UtcNow;
            anaveri.Baslik = duyuru.Baslik;
            anaveri.Icerik = duyuru.Icerik;

            db.SaveChanges();
            return Json(true);
        }

        [StajyerUstYetki]
        [HttpPost]
        public JsonResult Sil(int id)
        {
            Duyuru anaveri = db.Duyurular.Find(id);
            db.Duyurular.Remove(anaveri);
            db.SaveChanges();
            return Json(true);

        }

        public JsonResult DuyuruCekJson(int id)
        {
            Duyuru duyuru = db.Duyurular.Find(id);

            return Json(duyuru);
        }


        public JsonResult DuyurulariCekJson()
        {
            List<Duyuru> duyurular = db.Duyurular.OrderByDescending(x => x.EklenmeTarihi).ToList();

            List<object> liste = new List<object>();
            foreach (var duyuru in duyurular)
            {
                string adsoyad = "";
                try
                {
                    Profil profil = db.Hesaplar.Find(duyuru.EkleyenID);
                    adsoyad = profil.Ad + " " + profil.Soyad;
                }
                catch (Exception ex)
                {
                    adsoyad = "<i>[Silinen Kullanıcı]</i>";
                }
                var nesne = new { duyuru = duyuru, adsoyad = adsoyad };
                liste.Add(nesne);
            }


            return Json(liste);
        }


        public IActionResult Listele()
        {
            return View();

        }

        public IActionResult Goruntule(int id)
        {
            Duyuru duyuru = db.Duyurular.Find(id);
            var yetki = HttpContext.Session.GetInt32("yetki");
            var kisiid = (int)HttpContext.Session.GetInt32("id");

            if (yetki == 3)
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

        [HttpPost]
        public IActionResult DuyurulariCek()
        {
            List<Duyuru> Duyurular = db.Duyurular.ToList();

            return PartialView("_Duyurular", Duyurular);
        }

    }
}