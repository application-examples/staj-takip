using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StajyerTakip.Attributes;

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

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Models.Birim birim)
        {

            db.Birimler.Add(birim);
            db.SaveChanges();
            return Redirect("~/Birim/Listele");

        }

        public IActionResult Duzenle(int id)
        {
            Models.Birim birim = db.Birimler.ToList().Find(x => x.ID == id);


            return View(birim);
        }

        [HttpPost]
        public IActionResult Duzenle(Models.Birim birim, int id)
        {
            Models.Birim anaveri = db.Birimler.Find(id);

            anaveri.Aciklama = birim.Aciklama;
            anaveri.Ad = birim.Ad;

            db.SaveChanges();
            return Redirect("~/Birim/Listele");
        }
        public IActionResult Listele()
        {
            List<Models.Birim> birimler = db.Birimler.ToList();


            return View(birimler);
        }
        public IActionResult Goruntule(int id)
        {
            Models.Birim birim = db.Birimler.Find(id);
            return View(birim);
        }

        [StajyerUstYetki]

        public IActionResult Sil(int id)
        {
            Models.Birim birim = db.Birimler.Find(id);
            return View(birim);
        }


        [ActionName("Sil"), HttpPost]
        [StajyerUstYetki]
        public ActionResult Silme(int id)
        {
            Models.Birim birim = db.Birimler.Find(id);
            db.Birimler.Remove(db.Birimler.Find(birim.ID));
            db.SaveChanges();
            return Redirect("~/Birim/Listele");


        }
    }
   
}
