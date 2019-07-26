using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StajyerTakip.Attributes;
using StajyerTakip.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StajyerTakip.Controllers
{
    [GirisKontrol]
    public class BirimKoordinatoruController : Controller
    {

        private readonly Context db;
        public BirimKoordinatoruController(Context db)
        {
            this.db = db;
        }

        [BirimKoordinatoruUstYetki]
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
        [BirimKoordinatoruUstYetki]
        public async Task<IActionResult> Ekle(BirimKoordinatoru birimkoordinatoru, string[] Birimler, IFormFile img)
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
            birimkoordinatoru.Profil.Fotograf = path;

            List<BirimveKoordinator> birimler = new List<BirimveKoordinator>();

            for (var i = 0; i < Birimler.Length; i++)
            {
                birimler.Add(new BirimveKoordinator { BirimID = Int32.Parse(Birimler[i]), BirimKoordinatoru = birimkoordinatoru });
            }

            birimkoordinatoru.Birimler = birimler;
            db.Hesaplar.Add(birimkoordinatoru.Profil);
            db.BirimKoordinatorleri.Add(birimkoordinatoru);
            db.SaveChanges();
            return Redirect("~/BirimKoordinatoru/Listele");


        }

        [StajyerUstYetki]
        [BirimKoordinatoruID]
        public IActionResult Duzenle(int id)
        {

            var Birimler = new List<SelectListItem>();
            var Selecteds = db.BirimveKoordinator.ToList().FindAll(x => x.BirimKoordinatoruID == id);

            foreach (var item in db.Birimler)
            {
                Birimler.Add(new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = item.Ad,
                    Selected = Selecteds.Any(x => x.BirimID == item.ID)
                });
            }
            ViewBag.Birimler = Birimler;
            BirimKoordinatoru birimkoordinatoru = db.BirimKoordinatorleri.ToList().Find(x => x.ID == id);
            Profil profil = db.Hesaplar.ToList().Find(x => x.ID == birimkoordinatoru.ProfilID);
            birimkoordinatoru.Profil = profil;
            return View(birimkoordinatoru);
        }

        [StajyerUstYetki]
        [HttpPost]
        [BirimKoordinatoruID]
        public async Task<IActionResult> Duzenle(BirimKoordinatoru birimkoordinatoru, int id, string[] Birimler, IFormFile img)
        {
            BirimKoordinatoru anaveri = db.BirimKoordinatorleri.Find(id);
            Profil profil = db.Hesaplar.ToList().Find(x => x.ID == anaveri.ProfilID);

            var filepath = @"wwwroot/profile_images";
            if (img == null || img.Length <= 0) { }
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

            var silinecekbirimler = db.BirimveKoordinator.ToList().FindAll(x => x.BirimKoordinatoruID == id);
            foreach (var birim in silinecekbirimler)
            {
                db.BirimveKoordinator.Remove(birim);
            }

            var birimler = new List<BirimveKoordinator>();

            for (var i = 0; i < Birimler.Length; i++)
            {
                birimler.Add(new BirimveKoordinator
                {
                    BirimKoordinatoru = anaveri,
                    BirimID = Int32.Parse(Birimler[i])
                });
            }

            anaveri.Birimler = birimler;
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

        [BirimKoordinatoruUstYetki]
        [StajyerUstYetki]
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

        [BirimKoordinatoruID]
        [StajyerUstYetki]
        public IActionResult Goruntule(int id)
        {
            Models.BirimKoordinatoru birimkoordinatoru = db.BirimKoordinatorleri.Find(id);
            birimkoordinatoru.Profil = db.Hesaplar.Find(birimkoordinatoru.ProfilID);

            return View(birimkoordinatoru);
        }


    }


}
