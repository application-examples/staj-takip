using System;
using System.Collections.Generic;
using System.IO;
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
        public IActionResult Ekle(Moderator moderator, string img)
        {
            var id = HttpContext.Session.GetInt32("id");
            var filepath = @"wwwroot/profile_images";
            if (!Directory.Exists(filepath))
                Directory.CreateDirectory(filepath);
            string path = "/images/man-200x200.png";
            if (!string.IsNullOrEmpty(img))
            {
                var t = img.Replace("data:image/jpeg;base64,", "");
                byte[] imagebytes = Convert.FromBase64String(t);
                string filename = "IMG_" + id + "_" + DateTime.UtcNow.ToString("yyyyMMdd_hhmmss") + new Random().Next(0, 99);
                var ext = ".png";
                filename += ext;
                string fullpath = Path.Combine(filepath, filename);


                using (var stream = new FileStream(fullpath, FileMode.Create, FileAccess.ReadWrite))
                {
                    try
                    {
                        using (BinaryWriter bw = new BinaryWriter(stream))
                        {
                            bw.Write(imagebytes);
                        }
                        path = fullpath.Replace("wwwroot", "");
                    }
                    catch (Exception ex)
                    {
                        return Content("Fotoğraf yüklenirken bir sorun oluştu. : " + ex.Message);
                    }
                }
            }
            moderator.Profil.Rol = 2;
            moderator.Profil.Fotograf = path;
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
        public  IActionResult Duzenle(Moderator moderator, int id, string img)
        {
            Moderator anaveri = db.Moderatorler.Find(id);
            Profil profil = db.Hesaplar.ToList().Find(x => x.ID == anaveri.ProfilID);

            var yetki = HttpContext.Session.GetInt32("yetki");

            var filepath = @"wwwroot/profile_images";
            if (string.IsNullOrEmpty(img))
            {

            }
            else
            {
                var t = img.Replace("data:image/jpeg;base64,", "");
                byte[] imagebytes = Convert.FromBase64String(t);

                string filename = "IMG_" + id + "_" + DateTime.UtcNow.ToString("yyyyMMdd_hhmmss") + new Random().Next(0, 99);
                var ext = ".png";
                filename += ext;

                string fullpath = Path.Combine(filepath, filename);
                using (var stream = new FileStream(fullpath, FileMode.Create, FileAccess.ReadWrite))
                {
                    try
                    {
                        using (BinaryWriter bw = new BinaryWriter(stream))
                        {
                            bw.Write(imagebytes);
                        }
                        anaveri.Profil.Fotograf = fullpath.Replace("wwwroot", "");
                    }
                    catch (Exception ex)
                    {
                        return Content("Fotoğraf yüklenirken bir sorun oluştu. : " + ex.Message);
                    }
                }
            }
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
            if (yetki != 2)
                return Redirect("~/Moderator/Listele");
            else
                return Redirect("~/Home/Index");


        }

        [ModeratorUstYetki]
        public IActionResult Sil(int id)
        {
            Moderator moderator = db.Moderatorler.Find(id);
            moderator.Profil = db.Hesaplar.Find(moderator.ProfilID);

            return View(moderator);
        }

        [HttpPost]
        [ActionName("Sil")]
        [ModeratorUstYetki]
        public IActionResult Silme(int id)
        {
            Moderator moderator = db.Moderatorler.Where(x => x.ID == id).SingleOrDefault();
            db.Hesaplar.Remove(db.Hesaplar.Find(moderator.ID));

            db.SaveChanges();

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
