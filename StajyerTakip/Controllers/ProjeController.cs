using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StajyerTakip.Attributes;
using StajyerTakip.Models;
using static System.Net.Mime.MediaTypeNames;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StajyerTakip.Controllers
{
    [GirisKontrol]
    public class ProjeController : Controller
    {

        private readonly Context db;

        public ProjeController(Context db)
        {
            this.db = db;
        }

        [StajyerUstYetki]
        [HttpPost]
        public async JsonResult Duzenle(Models.Proje proje, int id, string[] stajyerler, string[] bkoordinatorleri)
        {

            var yetki = HttpContext.Session.GetInt32("yetki");
            var idx = HttpContext.Session.GetInt32("id");

             Models.Proje anaveri = await db.Projeler.Where(x => x.ID == id).Include(x => x.Stajyerler).ThenInclude(x => x.Stajyer).ThenInclude(x => x.Profil).Include(x => x.BirimKoordinatorleri).ThenInclude(x => x.BirimKoordinatoru).ThenInclude(x => x.Profil).SingleOrDefaultAsync();

            List<StajyerProje> yeniStajyerler = new List<StajyerProje>();
            List<ProjeBirim> yeniBKler = new List<ProjeBirim>();
            for (var i = 0; i < stajyerler.Length; i++)
            {
                yeniStajyerler.Add(new StajyerProje
                {
                    Proje = anaveri,
                    StajyerID = Int32.Parse(stajyerler[i])
                });
            }

            for (var i = 0; i < bkoordinatorleri.Length; i++)
            {
                yeniBKler.Add(new ProjeBirim
                {
                    Proje = anaveri,
                    BirimKoordinatoruID = Int32.Parse(bkoordinatorleri[i])
                });
            }

            var silinecekStajyerler = db.StajyerProjeler.ToList().FindAll(x => x.ProjeID == id);
            var silinecekBKler = db.ProjeBirim.ToList().FindAll(x => x.ProjeID == id);
            if (yetki != 3)
            {
                foreach (var bk in silinecekBKler)
                {
                    db.ProjeBirim.Remove(bk);
                }
                anaveri.BirimKoordinatorleri = yeniBKler;
            }
            foreach (var stajyer in silinecekStajyerler)
            {
                db.StajyerProjeler.Remove(stajyer);
            }



            anaveri.Stajyerler = yeniStajyerler;
            anaveri.Ad = proje.Ad;
            anaveri.Icerik = proje.Icerik;
            anaveri.KullanilanTeknolojiler = proje.KullanilanTeknolojiler;
            anaveri.Baslangic = proje.Baslangic;
            anaveri.Bitis = proje.Bitis;

            await db.SaveChangesAsync();
            return Json(true);

        }

        public IActionResult Goruntule(int id)
        {
            Proje proje = db.Projeler.Where(x => x.ID == id).Include(x => x.Stajyerler).ThenInclude(x => x.Stajyer).ThenInclude(x => x.Profil).Include(x => x.BirimKoordinatorleri).ThenInclude(x => x.BirimKoordinatoru).ThenInclude(x => x.Profil).SingleOrDefault();
            return View(proje);
        }

        [HttpPost]
        [StajyerUstYetki]
        public JsonResult EkleAjax(string[] stajyerler, string[] bkoordinatorleri, Proje proje)
        {

            var yetki = HttpContext.Session.GetInt32("yetki");
            var id = HttpContext.Session.GetInt32("id");
            proje.Stajyerler = new List<StajyerProje>();
            proje.BirimKoordinatorleri = new List<ProjeBirim>();
            foreach (var i in stajyerler)
            {
                proje.Stajyerler.Add(new StajyerProje
                {
                    StajyerID = Convert.ToInt32(i.ToString()),
                    Proje = proje
                });
            }
            if (yetki != 3)
            {
                foreach (var i in bkoordinatorleri)
                {
                    proje.BirimKoordinatorleri.Add(new ProjeBirim
                    {
                        BirimKoordinatoruID = Convert.ToInt32(i.ToString()),
                        Proje = proje
                    });
                }
            }
            if (yetki == 3)
            {
                proje.BirimKoordinatorleri.Add(new ProjeBirim
                {
                    BirimKoordinatoruID = (int)id,
                    Proje = proje
                });
            }
            db.Projeler.Add(proje);
            db.SaveChanges();
            return Json(true);
        }

        public IActionResult Projeler()
        {
            return View();
        }


        [StajyerUstYetki]
        public JsonResult ProjeCek(int id)
        {
            Proje proje = db.Projeler.Find(id);
            return Json(proje);
        }

        public JsonResult StajyerCek()
        {
            var Stajyerler = db.Stajyerler.Include(x => x.Profil).ToList();
            var results = new List<object>();

            foreach (var i in Stajyerler)
            {
                results.Add(new
                {
                    id = i.ID,
                    text = i.Profil.Ad + " " + i.Profil.Soyad
                });
            }

            return Json(new { results = results });
        }


        public JsonResult BKCek()
        {

            var BK = db.BirimKoordinatorleri.Include(x => x.Profil).ToList();
            var results = new List<object>();

            foreach (var i in BK)
            {
                results.Add(new
                {
                    id = i.ID,
                    text = i.Profil.Ad + " " + i.Profil.Soyad

                });
            }

            return Json(new { results = results });
        }

        public JsonResult ProjeleriCekJson()
        {
            var yetki = HttpContext.Session.GetInt32("yetki");
            var id = HttpContext.Session.GetInt32("id");
            List<Proje> Projeler;
            if (yetki == 2 || yetki == 1)
            {
                Projeler = db.Projeler.ToList();
                return Json(Projeler);
            }
            if (yetki == 3)
            {
                var bk = db.ProjeBirim.Where(x => x.BirimKoordinatoruID == id).Include(x => x.Proje);
                Projeler = new List<Proje>();
                foreach (var i in bk)
                {
                    Projeler.Add(i.Proje);
                }
                return Json(Projeler);

            }
            if (yetki == 4)
            {
                var stajyer = db.StajyerProjeler.Where(x => x.StajyerID == id).Include(x => x.Proje);
                Projeler = new List<Proje>();
                foreach (var i in stajyer)
                {
                    Projeler.Add(i.Proje);
                }
                return Json(Projeler);
            }

            return Json(false);
        }




        [StajyerUstYetki]
        [HttpPost]
        public JsonResult SilAjax(int id)
        {
            Proje proje = db.Projeler.Find(id);
            db.Projeler.Remove(proje);
            db.SaveChanges();
            return Json(true);
        }


        public JsonResult GetAllMessages (int id)
        {

            List<Chat> Mesajlar = db.Mesajlar.Where(x => x.ProjeID == id).OrderByDescending(x=>x.ID).Include(x => x.YazanProfil).ToList();

            return Json(Mesajlar);
        }

        [HttpPost]
        public JsonResult MessageSend(int id,Chat chat)
        {
            chat.ProjeID = id;
            chat.Tarih = DateTime.Now;
            db.Mesajlar.Add(chat);
            db.SaveChanges();
            return Json(true);
        }
    }





}
