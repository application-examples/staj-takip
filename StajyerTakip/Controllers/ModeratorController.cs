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
    public class ModeratorController : Controller
    {
        private readonly Context db;

        public ModeratorController(Context db)
        {
            this.db = db;
        }

        [ModeratorUstYetki]
        public IActionResult Ekle()
        {
            return View();
        }

        [ModeratorUstYetki]
        [HttpPost]
        public IActionResult Ekle(Moderator moderator)
        {
            db.Hesaplar.Add(moderator.Profil);
            db.Moderatorler.Add(moderator);
            db.SaveChanges();
            return Redirect("~/Moderator/Listele");
        }

        [BirimKoordinatoruUstYetki]
        [ModeratorID]
        public IActionResult Duzenle(int id)
        {
            Moderator moderator = db.Moderatorler.ToList().Find(x => x.ID == id);
            Profil profil = db.Hesaplar.ToList().Find(x => x.ID == moderator.ProfilID);
            moderator.Profil = profil;
            return View(moderator);
        }

        [HttpPost]
        [ModeratorID]
        [BirimKoordinatoruUstYetki]
        public IActionResult Duzenle(Moderator moderator, int id)
        {
            Moderator anaveri = db.Moderatorler.Find(id);
            Profil profil = db.Hesaplar.ToList().Find(x => x.ID == anaveri.ProfilID);

            anaveri.Profil.Ad = moderator.Profil.Ad;
            anaveri.Profil.Soyad = moderator.Profil.Soyad;
            anaveri.Profil.KullaniciAdi = moderator.Profil.KullaniciAdi;
            anaveri.Profil.Sifre = moderator.Profil.Sifre;
            anaveri.Profil.Email = moderator.Profil.Email;
            anaveri.Profil.Telefon = moderator.Profil.Telefon;
            anaveri.Unvan = moderator.Unvan;
            anaveri.Profil.Adres = moderator.Profil.Adres;
            anaveri.Profil.Il = moderator.Profil.Il;
            anaveri.Profil.Ilce = moderator.Profil.Ilce;
            anaveri.Profil.Sokak = moderator.Profil.Sokak;


            db.SaveChanges();
            var yetki = HttpContext.Session.GetInt32("yetki");

            if(yetki != 2)
                return Redirect("~/Moderator/Listele");
            else
                return Redirect("~/Home/Index");


        }

        [ModeratorUstYetki]
        public IActionResult Sil(int id)
        {
            Moderator moderator = db.Moderatorler.Find(id);
            moderator.Profil = db.Hesaplar.Find(moderator.ProfilID);

            return Redirect("~/Moderator/Listele");
        }

        [ModeratorUstYetki]
        public IActionResult Listele()
        {
            List<Models.Moderator> moderatorler = db.Moderatorler.ToList();
            List<Models.Profil> profiller = db.Hesaplar.ToList();
            foreach (var i in moderatorler)
            {
                i.Profil = profiller.Find(x => x.ID == i.ProfilID);
            }
            return View(moderatorler);


        }
        [ModeratorID]
        [BirimKoordinatoruUstYetki]
        public IActionResult Goruntule(int id)
        {
            Models.Moderator moderator = db.Moderatorler.Find(id);
            Models.Profil profil = db.Hesaplar.Find(moderator.ProfilID);
            return View(moderator);
        }
    }
}
