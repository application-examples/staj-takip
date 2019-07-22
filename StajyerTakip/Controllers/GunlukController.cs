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
    public class GunlukController : Controller
    {
        private readonly Context db;
        public GunlukController(Context db)
        {
            this.db = db;
        }
        // GET: /<controller>/
        public IActionResult Ekle(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(int id,Models.Gunluk gunluk)
        {
            gunluk.OgrenciID = id;
            db.Gunlukler.Add(gunluk);
            db.SaveChanges();
            return Redirect("~/Gunluk/Ekle/"+id);


        }
        public IActionResult Duzenle(int id )
        {
            Models.Gunluk gunluk = db.Gunlukler.ToList().Find(x => x.ID == id);


            return View(gunluk);

        }
        [HttpPost]
        public IActionResult Duzenle(Models.Gunluk gunluk, int id)
        {
            Models.Gunluk anaveri = db.Gunlukler.Find(id);

            anaveri.Baslik = gunluk.Baslik;
            anaveri.Bilgiler = gunluk.Bilgiler;
            anaveri.Tarih = gunluk.Tarih;
            


            db.SaveChanges();
            return Redirect("~/Home/Index");
        }

        public ActionResult Listele(int id)
        {
            
            List<Models.Gunluk> gunlukler = db.Gunlukler.ToList().FindAll(x=>x.OgrenciID == id);
            
            foreach(var i in gunlukler)
            {
                i.Ogrenci = db.Stajyerler.Find(i.OgrenciID);
                i.Ogrenci.Profil = db.Hesaplar.Find(i.Ogrenci.ProfilID);
            }
            return View(gunlukler);
        }
        public IActionResult Goruntule(int id)
        {
            Gunluk gunlukler = db.Gunlukler.Find(id);
            
            return View(gunlukler);
        }
    }
}
