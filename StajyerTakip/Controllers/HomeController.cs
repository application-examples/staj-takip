using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using StajyerTakip.Models;
using StajyerTakip.Attributes;

namespace StajyerTakip.Controllers
{
    [GirisKontrol]
    public class HomeController : Controller
    {
        private readonly Context db;

        public HomeController(Context db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            List<Profil> hesaplar = db.Hesaplar.ToList();
            return View(hesaplar);
        }
    }
}