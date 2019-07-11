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


    }
}
