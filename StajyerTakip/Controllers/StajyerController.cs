using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Internal;
using StajyerTakip.Attributes;
using StajyerTakip.Models;

namespace StajyerTakip.Controllers
{
    [GirisKontrol]
    public class StajyerController : Controller
    {

        private readonly Context db;

        public StajyerController(Context db)
        {
            this.db = db;
        }

        [StajyerUstYetki]
        public IActionResult Ekle()
        {
            var Birimler = new List<SelectListItem>();

            foreach (var item in db.Birimler)
            {
                Birimler.Add(new SelectListItem
                {
                    Text = item.Ad,
                    Value = item.ID.ToString()

                });

            }
            ViewBag.Birimler = Birimler;
            return View();
        }

        [HttpPost]
        [StajyerUstYetki]
        public async Task<IActionResult> Ekle(Stajyer stajyer, string[] Birimler, IFormFile img)
        {


            var filepath = @"wwwroot/profile_images";
            if (!Directory.Exists(filepath))
                Directory.CreateDirectory(filepath);
            string path = "";
            if (img != null && img.Length > 0)
            {
                string fullpath = Path.Combine(filepath, img.FileName);
                using (var stream = new FileStream(fullpath, FileMode.Create, FileAccess.ReadWrite))
                {
                    try
                    {
                        await img.CopyToAsync(stream);
                        path = fullpath;
                    }
                    catch (Exception ex)
                    {
                        return Content("Fotoğraf yüklenirken bir sorun oluştu. : " + ex.Message);
                    }
                }
            }
            stajyer.Profil.Fotograf = path;
            List<BirimveStajyer> birimler = new List<BirimveStajyer>();
            for (var i = 0; i < Birimler.Length; i++)
            {
                birimler.Add(new BirimveStajyer { BirimID = Int32.Parse(Birimler[i]), Stajyer = stajyer });
            }


            stajyer.Birimler = birimler;
            db.Hesaplar.Add(stajyer.Profil);
            db.Stajyerler.Add(stajyer);
            db.SaveChanges();
            return Redirect("~/Stajyer/Listele");

        }

        [StajyerID]
        public IActionResult Duzenle(int id)
        {

            var Birimler = new List<SelectListItem>();
            List<BirimveStajyer> Selecteds = db.BirimveStajyer.ToList().FindAll(x => x.StajyerID == id);
            foreach (var item in db.Birimler.ToList())
            {
                Birimler.Add(new SelectListItem { Text = item.Ad, Value = item.ID.ToString(), Selected = Selecteds.Any(x => x.BirimID == item.ID) });
            }

            ViewBag.Birimler = Birimler;
            Stajyer stajyer = db.Stajyerler.ToList().Find(x => x.ID == id);
            Profil profil = db.Hesaplar.ToList().Find(x => x.ID == stajyer.ProfilID);
            stajyer.Profil = profil;
            return View(stajyer);
        }


        [StajyerID]
        [HttpPost]
        public async Task<IActionResult> Duzenle(Stajyer stajyer, int id, string[] Birimler, IFormFile img)
        {
            Stajyer anaveri = db.Stajyerler.Find(id);
            anaveri.Profil = db.Hesaplar.ToList().Find(x => x.ID == anaveri.ProfilID);


            var filepath = @"wwwroot/profile_images";
            if (img == null || img.Length <= 0)
            {

            }
            else
            {
                string fullpath = Path.Combine(filepath, img.FileName);
                using (var stream = new FileStream(fullpath, FileMode.Create, FileAccess.ReadWrite))
                {
                    try
                    {
                        await img.CopyToAsync(stream);
                        anaveri.Profil.Fotograf = fullpath;
                    }
                    catch (Exception ex)
                    {
                        return Content("Fotoğraf yüklenirken bir sorun oluştu. : " + ex.Message);
                    }
                }
            }


            List<BirimveStajyer> birimler = new List<BirimveStajyer>();
            for (var i = 0; i < Birimler.Length; i++)
            {
                birimler.Add(new BirimveStajyer { BirimID = Int32.Parse(Birimler[i]), Stajyer = anaveri });
            }

            List<BirimveStajyer> silinecekbirimler = db.BirimveStajyer.ToList().FindAll(x => x.StajyerID == id);

            foreach (var birim in silinecekbirimler)
            {
                db.BirimveStajyer.Remove(birim);
            }

            anaveri.Birimler = birimler;
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

            db.SaveChanges();

            var yetki = HttpContext.Session.GetInt32("yetki");

            if (yetki == 4)
                return Redirect("~/Home/Index");
            else
                return Redirect("~/Stajyer/Listele");
        }

        [StajyerUstYetki]
        public IActionResult Sil(int id)
        {
            Stajyer stajyer = db.Stajyerler.Find(id);
            stajyer.Profil = db.Hesaplar.Find(stajyer.ProfilID);
            return View(stajyer);
        }

        [StajyerUstYetki]
        [ActionName("Sil"), HttpPost]
        public IActionResult Silme(int id)
        {
            Stajyer stajyer = db.Stajyerler.Find(id);
            db.Hesaplar.Remove(db.Hesaplar.Find(stajyer.ProfilID));
            db.SaveChanges();
            return Redirect("~/Stajyer/Listele");
        }

        [StajyerUstYetki]
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