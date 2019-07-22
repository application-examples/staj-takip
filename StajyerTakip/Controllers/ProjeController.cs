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
    public class ProjeController : Controller
    {

        private readonly Context db;

        public ProjeController (Context db)
        {
            this.db = db;
        }

        // GET: /<controller>/
        [StajyerUstYetki]
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Models.Proje proje)
        {
            proje.ID = 1;
            db.Projeler.Add(proje);
            db.SaveChanges();
            return RedirectToAction("Ekle");
        }
        [StajyerUstYetki]
        public IActionResult Duzenle(int id)
        {
            Models.Proje proje = db.Projeler.ToList().Find(x => x.ID ==id);
            return View(proje);
        }
        [HttpPost]
         public IActionResult Duzenle(Models.Proje proje, int id)
        {
            Models.Proje anaveri = db.Projeler.Find(id);

            anaveri.Ad = proje.Ad;
            anaveri.Icerik = proje.Icerik;
            anaveri.KullanilanTeknolojiler = proje.KullanilanTeknolojiler;
            anaveri.Baslangic = proje.Baslangic;
            anaveri.Bitis = proje.Bitis;

            db.SaveChanges();
            return View(proje);

        }

        public IActionResult Listele(int id)
        {
            List<Models.Proje> projeler = db.Projeler.ToList().FindAll(x => x.ID == id);
            return View(projeler);
        }
        //TODO sadece stajyer yetkisi verilecek.
        public IActionResult Puanla()
        {
            List<Proje> projeler = db.Projeler.ToList();
            Stajyer stajyer = db.Stajyerler.Find(1);

            stajyer.Projeler = db.StajyerProjeler.ToList().FindAll(x => x.StajyerID == stajyer.ID);
            
            foreach(var i in stajyer.Projeler)
            {
                i.Stajyer = stajyer;
                i.Proje = projeler.Find(x => x.ID == i.ProjeID);
            }

          

            return View(stajyer);

        }

        public IActionResult Goruntule(int id)
        {
            List<Proje> projeler = db.Projeler.ToList().FindAll(x => x.ID == id);
            

            return View(projeler);
        }

      

    }


        
    

}
