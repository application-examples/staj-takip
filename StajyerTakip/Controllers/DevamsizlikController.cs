using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StajyerTakip.Attributes;
using StajyerTakip.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public IActionResult Listele()
        {
            var yetki = HttpContext.Session.GetInt32("yetki");
            List<Stajyer> stajyerler = new List<Stajyer>();
            if (yetki == 3)
            {
                BirimKoordinatoru koordinator = db.BirimKoordinatorleri.Find(HttpContext.Session.GetInt32("id"));
                koordinator.Birimler = db.BirimveKoordinator.ToList().FindAll(x=>x.BirimKoordinatoruID == koordinator.ID);
                foreach(var i in koordinator.Birimler)
                {

                }
            }
            if (yetki == 2 || yetki == 1)
            {
                stajyerler = db.Stajyerler.ToList();
                foreach (var i in stajyerler)
                {
                    i.Profil = db.Hesaplar.Find(i.ProfilID);
                    i.Devamsizliklar = db.Devamsizlik.ToList().FindAll(x => x.StajyerID == i.ID);
                }
            }

            return View(stajyerler);
        }

        [StajyerUstYetki]
        public IActionResult Ekle(int id)
        {
            if (id == 0)
                return RedirectToAction("Listele");
            Models.Stajyer stajyer = db.Stajyerler.Find(id);
            stajyer.Profil = db.Hesaplar.Find(stajyer.ProfilID);
            return View(stajyer);
        }

        [HttpPost]
        public IActionResult Ekle(int id, Models.Devamsizlik devamsizlik)
        {
            devamsizlik.StajyerID = id;
            devamsizlik.ID = 0;
            db.Devamsizlik.Add(devamsizlik);
            db.SaveChanges();
            return RedirectToAction("Ekle");
        }

        [StajyerID]
        public IActionResult Goruntule(int id)
        {
            List<Devamsizlik> veriler = db.Devamsizlik.ToList().FindAll(x => x.StajyerID == id);
            Models.Stajyer stajyer = db.Stajyerler.Find(id);
            Models.Profil profil = db.Hesaplar.ToList().Find(x => x.ID == stajyer.ProfilID);
            stajyer.Profil = profil;

            StajyerDevamsizlik d = new StajyerDevamsizlik();
            d.Veriler = veriler;
            d.Stajyer = stajyer;
            return View(d);
        }
        [StajyerUstYetki]
        public IActionResult Sil(int id)
        {
            Devamsizlik devamsizlik = db.Devamsizlik.Find(id);
            devamsizlik.Stajyer = db.Stajyerler.Find(devamsizlik.StajyerID);
            devamsizlik.Stajyer.Profil = db.Hesaplar.Find(devamsizlik.Stajyer.ID);
            return View(devamsizlik);
        }
        [ActionName("Sil"), HttpPost]
        public IActionResult Silme(int id)
        {
            Devamsizlik devamsizlik = db.Devamsizlik.Find(id);
            db.Devamsizlik.Remove(devamsizlik);
            db.SaveChanges();
            return Redirect("~/Home/Index");


        }
    }
}
