using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StajyerTakip.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StajyerTakip.Controllers
{
    public class BirimKoordinatoruController : Controller
    {

        private readonly Context db;
        public BirimKoordinatoruController (Context db)
        {
            this.db = db;
        }

        // GET: /<controller>/
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(BirimKoordinatoru birimkoordinatoru)
        {
            birimkoordinatoru.BirimID = 1;
            birimkoordinatoru.ModeratorID = 1;
            db.Hesaplar.Add(birimkoordinatoru.Profil);
            db.BirimKoordinatorleri.Add(birimkoordinatoru);
            db.SaveChanges();
            return RedirectToAction("Ekle");


        }
    }


}
