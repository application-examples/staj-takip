using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        // GET: /<controller>/
        public IActionResult Ekle(int id)
        {
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
