using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StajyerTakip.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StajyerTakip.Controllers
{
    public class ModeratorController : Controller
    {
        private readonly Context db;

        public ModeratorController (Context db)
        {
            this.db = db;
        }


        // GET: /<controller>/
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle (Moderator moderator)
        {
            db.Hesaplar.Add(moderator.Profil);
            db.Moderatorler.Add(moderator);
            db.SaveChanges();
            return RedirectToAction("Ekle");
        }
       

         public IActionResult Duzenle(int id)
        {
            Moderator moderator = db.Moderatorler.ToList().Find(x => x.ID == id);
            Profil profil = db.Hesaplar.ToList().Find(x => x.ID == moderator.ProfilID);
            moderator.Profil = profil;
            return View(moderator);
        }
       
        [HttpPost]
         
        public IActionResult Duzenle(Moderator moderator, int id)
        {
            Moderator anaveri = db.Moderatorler.Find(id);
            Profil profil = db.Hesaplar.ToList().Find(x => x.ID == moderator.ProfilID);

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
            anaveri.Profil.Rol = moderator.Profil.Rol;


            db.SaveChanges();


            return View();



        }
        

        public IActionResult Sil(int id)
        {
            Moderator moderator = db.Moderatorler.Find(id);
            moderator.Profil = db.Hesaplar.Find(moderator.ProfilID);

            return View(moderator);
        }


    }
}
