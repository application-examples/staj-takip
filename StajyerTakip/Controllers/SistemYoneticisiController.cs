using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StajyerTakip.Attributes;
using StajyerTakip.Models;

namespace StajyerTakip.Controllers
{
    public class SistemYoneticisiController : Controller
    {

        private readonly Context db;

        public SistemYoneticisiController(Context _db)
        {
            db = _db;
        }

        [ModeratorUstYetki]
        public IActionResult Duzenle()
        {
            var id = HttpContext.Session.GetInt32("id");

            SistemYoneticisi yonetici = db.SistemYoneticisi.Where(x => x.ID == id).Include(x => x.Profil).SingleOrDefault();

            return View(yonetici);
        }

        [HttpPost]
        [ModeratorUstYetki]

        public  IActionResult Duzenle(SistemYoneticisi update, string img)
        {
            var id = HttpContext.Session.GetInt32("id");
            SistemYoneticisi anaveri = db.SistemYoneticisi.Where(x => x.ID == id).Include(x => x.Profil).SingleOrDefault();


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
            anaveri.Profil.Ad = update.Profil.Ad;
            anaveri.Profil.Adres = update.Profil.Adres;
            anaveri.Profil.Email = update.Profil.Email;
            anaveri.Profil.Il = update.Profil.Il;
            anaveri.Profil.Ilce = update.Profil.Ilce;
            anaveri.Profil.KullaniciAdi = update.Profil.KullaniciAdi;
            anaveri.Profil.Sifre = update.Profil.Sifre;
            anaveri.Profil.Sokak = update.Profil.Sokak;
            anaveri.Profil.Soyad = update.Profil.Soyad;
            anaveri.Profil.Telefon = update.Profil.Telefon;

            db.SaveChanges();

            return Redirect("~/Home/Index");
        }


    }
}