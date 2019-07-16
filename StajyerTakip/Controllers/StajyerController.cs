using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StajyerTakip.Models;

namespace StajyerTakip.Controllers
{
    public class StajyerController : Controller
    {

        private readonly Context db;

        public StajyerController(Context db)
        {
            this.db = db;
        }
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Ekle(Stajyer stajyer)
        {
            db.Hesaplar.Add(stajyer.Profil);
            db.Stajyerler.Add(stajyer);
            db.SaveChanges();
            return RedirectToAction("Ekle");

        }

        public IActionResult Duzenle(int id)
        {
            Stajyer stajyer = db.Stajyerler.ToList().Find(x => x.ID == id);
            Profil profil = db.Hesaplar.ToList().Find(x => x.ID == stajyer.ProfilID);
            stajyer.Profil = profil;
            return View(stajyer);
        }

        [HttpPost]
        public IActionResult Duzenle(Stajyer stajyer, int id)
        {
            Stajyer anaveri = db.Stajyerler.Find(id);
            anaveri.Profil = db.Hesaplar.ToList().Find(x => x.ID == stajyer.ProfilID);




            anaveri.Profil.Ad = stajyer.Profil.Ad;
            anaveri.Profil.Soyad = stajyer.Profil.Soyad;
            anaveri.Profil.KullaniciAdi = stajyer.Profil.KullaniciAdi;
            anaveri.Profil.Sifre = stajyer.Profil.Sifre;
            anaveri.Profil.Email = stajyer.Profil.Email;
            anaveri.Profil.Telefon = stajyer.Profil.Telefon;
            anaveri.Okul = stajyer.Okul;
            anaveri.Bolum = stajyer.Bolum;
            anaveri.Profil.Adres = stajyer.Profil.Adres;
            anaveri.Profil.Il = stajyer.Profil.Il;
            anaveri.Profil.Ilce = stajyer.Profil.Ilce;
            anaveri.Profil.Sokak = stajyer.Profil.Sokak;
            anaveri.Profil.Rol = stajyer.Profil.Rol;
            db.SaveChanges();

            return View();

        }

        public ActionResult Listele()
        {
            List<Stajyer> stajyerler = db.Stajyerler.ToList();
            List<Profil> hesaplar = db.Hesaplar.ToList();

            foreach (var i in stajyerler)
            {
                i.Profil = hesaplar.Find(x => x.ID == i.ProfilID);
            }
            return View(stajyerler);
        }
    }
}