using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public class DevamsizlikController : Controller
    {
        private readonly Context db;
        public DevamsizlikController(Context db)
        {
            this.db = db;
        }

        [StajyerUstYetki]
        public IActionResult Duzenle(int id)
        {
            var yetki = (int)HttpContext.Session.GetInt32("yetki");
            var kisiid = (int)HttpContext.Session.GetInt32("id");
            var profilid = (int)HttpContext.Session.GetInt32("profilid");
            var username = HttpContext.Session.GetString("kadi");

            Stajyer stajyer = db.Stajyerler.Where(x => x.ID == id).Include(x => x.Devamsizliklar).Include(x => x.Birimler).Include(x => x.Profil).SingleOrDefault();

            if (yetki == 3)
            {
                BirimKoordinatoru koordinator = db.BirimKoordinatorleri.Where(x => x.ID == kisiid).Include(x => x.Birimler).Include(x => x.Profil).SingleOrDefault();
                foreach (var birim in koordinator.Birimler)
                {
                    if (stajyer.Birimler.Any(x => x.BirimID == birim.BirimID))
                    {
                        return View(stajyer);

                    }
                }
                return Redirect("~/Error/AuthProblem");
            }

            return View(stajyer);
        }

        [StajyerUstYetki]
        public IActionResult Yonet()
        {
            var id = (int)HttpContext.Session.GetInt32("id");
            var yetki = HttpContext.Session.GetInt32("yetki");
            var profilid = HttpContext.Session.GetInt32("profilid");
            var kadi = HttpContext.Session.GetString("kadi");

            if (yetki == 3)
            {
                BirimKoordinatoru koordinator = db.BirimKoordinatorleri.Where(x => x.ID == id).Include(x => x.Profil).Include(x => x.Birimler).FirstOrDefault();
                List<Stajyer> stajyerler = db.Stajyerler.Include(x => x.Birimler).Include(x => x.Devamsizliklar).Include(x => x.Gunlukler).Include(x => x.Profil).ToList();

                List<Stajyer> stajyers = new List<Stajyer>();
                foreach (var birim in koordinator.Birimler)
                {
                    foreach (var stajyer in stajyerler)
                    {
                        if (stajyer.Birimler.Any(x => x.BirimID == birim.BirimID) && !stajyers.Any(x => x.ID == stajyer.ID))
                        {
                            stajyers.Add(stajyer);
                        }
                    }
                }
                return View(stajyers);

            }
            else
            {
                List<Stajyer> stajyerler = db.Stajyerler.Include(x => x.Birimler).Include(x => x.Devamsizliklar).Include(x => x.Gunlukler).Include(x => x.Profil).ToList();
                return View(stajyerler);
            }
        }

        [StajyerUstYetki]
        public IActionResult Listele()
        {
            var id = (int)HttpContext.Session.GetInt32("id");
            var yetki = HttpContext.Session.GetInt32("yetki");
            var profilid = HttpContext.Session.GetInt32("profilid");
            var kadi = HttpContext.Session.GetString("kadi");

            if (yetki == 3)
            {
                BirimKoordinatoru koordinator = db.BirimKoordinatorleri.Where(x => x.ID == id).Include(x => x.Profil).Include(x => x.Birimler).FirstOrDefault();
                List<Stajyer> stajyerler = db.Stajyerler.Include(x => x.Birimler).Include(x => x.Devamsizliklar).Include(x => x.Gunlukler).Include(x => x.Profil).ToList();

                List<Stajyer> stajyers = new List<Stajyer>();
                foreach (var birim in koordinator.Birimler)
                {
                    foreach (var stajyer in stajyerler)
                    {
                        if (stajyer.Birimler.Any(x => x.BirimID == birim.BirimID) && !stajyers.Any(x => x.ID == stajyer.ID))
                        {
                            stajyers.Add(stajyer);
                        }
                    }
                }
                return View(stajyers);

            }
            else
            {
                List<Stajyer> stajyerler = db.Stajyerler.Include(x => x.Birimler).Include(x => x.Devamsizliklar).Include(x => x.Gunlukler).Include(x => x.Profil).ToList();
                return View(stajyerler);
            }
        }

        [StajyerUstYetki]
        public IActionResult Ekle(int id)
        {

            Models.Stajyer stajyer = db.Stajyerler.Where(x => x.ID == id).Include(x => x.Profil).Include(x => x.Birimler).SingleOrDefault();
            var yetki = HttpContext.Session.GetInt32("yetki");
            var kisiid = HttpContext.Session.GetInt32("id");

            if (yetki == 3)
            {
                BirimKoordinatoru koordinator = db.BirimKoordinatorleri.Where(x => x.ID == kisiid).Include(x => x.Birimler).SingleOrDefault();

                foreach (var birim in koordinator.Birimler)
                {
                    if (stajyer.Birimler.Any(x => x.BirimID == birim.BirimID))
                    {
                        return View(stajyer);
                    }
                }
                return Redirect("~/Error/AuthProblem");
            }

            return View(stajyer);
        }

        [StajyerUstYetki]
        [HttpPost]
        public JsonResult Ekle(int id, Models.Devamsizlik devamsizlik)
        {

            devamsizlik.ID = 0;
            db.Devamsizlik.Add(devamsizlik);
            db.SaveChanges();
            return Json(new { result = false, message = "başarılı" });
        }

        public JsonResult TarihAl()
        {

            DateTime date = DateTime.UtcNow;
            return Json(new { tarih = date });
        }
        [HttpPost]
        public string AdSoyadCek(int id)
        {
            Stajyer stajyer = db.Stajyerler.Where(x => x.ID == id).Include(x => x.Profil).SingleOrDefault();

            string adsoyad = stajyer.Profil.Ad + " " + stajyer.Profil.Soyad;

            return adsoyad;
        }

        [HttpPost]
        public IActionResult DevamsizlikTablosu(int id)
        {
            List<Devamsizlik> Devamsizliklar = db.Devamsizlik.ToList().FindAll(x => x.StajyerID == id);

            return View(Devamsizliklar);
        }
        [StajyerID]
        public IActionResult Goruntule(int id)
        {
            var yetki = (int)HttpContext.Session.GetInt32("yetki");
            var kisiid = (int)HttpContext.Session.GetInt32("id");

            Stajyer stajyer = db.Stajyerler.Where(x => x.ID == id).Include(x => x.Birimler).Include(x => x.Devamsizliklar).Include(x => x.Profil).SingleOrDefault();
            if (yetki == 3)
            {
                BirimKoordinatoru koordinator = db.BirimKoordinatorleri.Where(x => x.ID == kisiid).Include(x => x.Birimler).SingleOrDefault();

                foreach (var birim in koordinator.Birimler)
                {
                    if (stajyer.Birimler.Any(x => x.BirimID == birim.BirimID))
                    {
                        return View(stajyer);
                    }
                }
                return Redirect("~/Error/AuthProblem");
            }

            return View(stajyer);
        }
        [StajyerUstYetki]
        public IActionResult Sil(int id)
        {
            Devamsizlik devamsizlik = db.Devamsizlik.Find(id);
            devamsizlik.Stajyer = db.Stajyerler.Where(x => x.ID == devamsizlik.StajyerID).Include(x => x.Profil).Include(x => x.Devamsizliklar).SingleOrDefault();
            var yetki = HttpContext.Session.GetInt32("yetki");
            var kisiid = HttpContext.Session.GetInt32("id");

            if (yetki == 3)
            {
                BirimKoordinatoru koordinator = db.BirimKoordinatorleri.Where(x => x.ID == kisiid).Include(x => x.Birimler).Include(x => x.Profil).SingleOrDefault();

                foreach (var birim in koordinator.Birimler)
                {
                    if (devamsizlik.Stajyer.Birimler.Any(x => x.BirimID == birim.BirimID))
                    {
                        return View(devamsizlik);
                    }
                }
                return Redirect("~/Error/AuthProblem");
            }

            return View(devamsizlik);
        }

        [StajyerUstYetki]
        [ActionName("Sil"), HttpPost]
        public IActionResult Silme(int id)
        {
            Devamsizlik devamsizlik = db.Devamsizlik.Find(id);
            int stajyerID = devamsizlik.StajyerID;
            db.Devamsizlik.Remove(devamsizlik);
            db.SaveChanges();
            List<Devamsizlik> devamsizliklar = db.Devamsizlik.ToList().FindAll(x => x.StajyerID == stajyerID);
            return PartialView("DevamsizlikTablosu", devamsizliklar);


        }

        [StajyerUstYetki]
        [HttpPost]
        public IActionResult Silx(int id)
        {
            Devamsizlik devamsizlik = db.Devamsizlik.Find(id);
            int stajyerID = devamsizlik.StajyerID;
            int a = 0;
            db.Devamsizlik.Remove(devamsizlik);
            db.SaveChanges();
            List<Devamsizlik> devamsizliklar = db.Devamsizlik.ToList().FindAll(x => x.StajyerID == stajyerID);
            return PartialView("DevamsizlikTablosu", devamsizliklar);
        }
    }
}
