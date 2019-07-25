using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StajyerTakip.Attributes;
using StajyerTakip.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StajyerTakip.Controllers
{
    [GirisKontrol]
    public class BirimKoordinatoruController : Controller
    {

        private readonly Context db;
        public BirimKoordinatoruController (Context db)
        {
            this.db = db;
        }

        [BirimKoordinatoruUstYetki]
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        [BirimKoordinatoruUstYetki]
        public IActionResult Ekle(BirimKoordinatoru birimkoordinatoru)
        {
            db.Hesaplar.Add(birimkoordinatoru.Profil);
            db.BirimKoordinatorleri.Add(birimkoordinatoru);
            db.SaveChanges();
            return Redirect("~/BirimKoordinatoru/Listele");


        }

        [BirimKoordinatoruID]
        public IActionResult Duzenle(int id)
        {
            BirimKoordinatoru birimkoordinatoru = db.BirimKoordinatorleri.ToList().Find(x => x.ID == id);
            Profil profil = db.Hesaplar.ToList().Find(x => x.ID == birimkoordinatoru.ProfilID);
            birimkoordinatoru.Profil = profil;
            return View(birimkoordinatoru);
        }
         
        [HttpPost]
        [BirimKoordinatoruID]
        public IActionResult Duzenle(BirimKoordinatoru birimkoordinatoru, int id)
        {
            BirimKoordinatoru anaveri = db.BirimKoordinatorleri.Find(id);
            Profil profil = db.Hesaplar.ToList().Find(x => x.ID == anaveri.ProfilID);


            anaveri.Profil.Ad = birimkoordinatoru.Profil.Ad;
            anaveri.Profil.Soyad = birimkoordinatoru.Profil.Soyad;
            anaveri.Profil.KullaniciAdi = birimkoordinatoru.Profil.KullaniciAdi;
            anaveri.Profil.Sifre = birimkoordinatoru.Profil.Sifre;
            anaveri.Profil.Email = birimkoordinatoru.Profil.Email;
            anaveri.Profil.Telefon = birimkoordinatoru.Profil.Telefon;
            anaveri.Unvan = birimkoordinatoru.Unvan;
            anaveri.Profil.Adres = birimkoordinatoru.Profil.Adres;
            anaveri.Profil.Il = birimkoordinatoru.Profil.Il;
            anaveri.Profil.Ilce = birimkoordinatoru.Profil.Ilce;
            anaveri.Profil.Sokak = birimkoordinatoru.Profil.Sokak;

            db.SaveChanges();

            var yetki = HttpContext.Session.GetInt32("yetki");

            if (yetki != 3)
                return Redirect("~/BirimKoordinatoru/Listele");
            else
                return Redirect("~/Home/Index");
        }

        [BirimKoordinatoruUstYetki]
        public IActionResult Sil(int id)
        {
            //Niyazi
            BirimKoordinatoru koordinator = db.BirimKoordinatorleri.Find(id);
            koordinator.Profil = db.Hesaplar.Find(koordinator.ProfilID);
            return View(koordinator);
        }

        [ActionName("Sil"), HttpPost]
        [BirimKoordinatoruID]
        public ActionResult Silme(int id)
        {
            BirimKoordinatoru koordinator = db.BirimKoordinatorleri.Find(id);
            db.Hesaplar.Remove(db.Hesaplar.Find(koordinator.ProfilID));
            db.SaveChanges();
            return Redirect("~/BirimKoordinatoru/Listele");
        }
        public IActionResult Listele()
        {
            List<Models.BirimKoordinatoru> birimkoordinatorleri = db.BirimKoordinatorleri.ToList();
            List<Models.Profil> profiller = db.Hesaplar.ToList();
            foreach (var i in birimkoordinatorleri)
            {
                i.Profil = profiller.Find(x => x.ID == i.ProfilID);
            }
            return View(birimkoordinatorleri);

            
        }
        public IActionResult Goruntule(int id)
        {
            Models.BirimKoordinatoru birimkoordinatoru = db.BirimKoordinatorleri.Find(id);
            birimkoordinatoru.Profil = db.Hesaplar.Find(birimkoordinatoru.ProfilID);
            return View(birimkoordinatoru);
        }
    }


}
