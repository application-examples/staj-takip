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
    [BirimYetki]
    public class BirimController : Controller
    {
        private readonly Context db;
        public BirimController(Context db)
        {
            this.db = db;
        }


        [BirimKoordinatoruUstYetki]
        [HttpPost]
        public JsonResult Ekle(Models.Birim birim)
        {


            db.Birimler.Add(birim);
            db.SaveChanges();
            Birim birim1 = db.Birimler.LastOrDefault();
            return Json(birim1);
        }

       
        [BirimKoordinatoruUstYetki]
        [HttpPost]
        public JsonResult Duzenle(Models.Birim birim, int id)
        {
            Models.Birim anaveri = db.Birimler.Find(id);

            anaveri.Aciklama = birim.Aciklama;
            anaveri.Ad = birim.Ad;

            db.SaveChanges();

            List<Birim> birimler = db.Birimler.OrderByDescending(x=>x.ID).ToList();

            return Json(birimler);
        }

        [BirimKoordinatoruUstYetki]
        public IActionResult Listele()
        {
            return View();
        }

        [BirimKoordinatoruUstYetki]
        [HttpPost]
        public JsonResult BirimleriCek()
        {
            List<Models.Birim> birimler = db.Birimler.OrderByDescending(x => x.ID).ToList();

            return Json(birimler);
        }

        [BirimKoordinatoruUstYetki]
        [HttpPost]
        public JsonResult Goruntule(int id)
        {
            Models.Birim birim = db.Birimler.Find(id);
            return Json(birim);
        }

        [BirimKoordinatoruUstYetki]
        [HttpPost]
        public JsonResult Sil(int id)
        {
            Models.Birim birim = db.Birimler.Find(id);
            db.Birimler.Remove(birim);
            db.SaveChanges();
            return Json(true);
        }

      
    }

}
