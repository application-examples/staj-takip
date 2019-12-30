using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using StajyerTakip.Models;
using StajyerTakip.Attributes;
using MySql.Data.MySqlClient;

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
            List<Duyuru> Duyurular = db.Duyurular.OrderByDescending(x => x.ID).Take(5).ToList();
            ViewBag.Duyurular = Duyurular;
            return View();
        }

        public IActionResult Deneme()
        {
            return View();
        }

        public JsonResult VeriCek()
        {
            Duyuru duyuru = db.Duyurular.Where(x => x.ID == 1).SingleOrDefault();
            return Json(duyuru);
        }

        public JsonResult VeriCek1()
        {
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection("server = localhost; Port= 3306; userid = root; database = denemedb; charset = utf8; convertzerodatetime = true");

            conn.Open();
            MySqlCommand cmd = new MySqlCommand("select *from duyurular where duyurular.ID = 1", conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            Duyuru duyuru = new Duyuru();
            duyuru.ID = reader.GetInt32(0);
            duyuru.Baslik = reader.GetString(0);
            reader.Close();
            cmd.Cancel();
            conn.Close();
            return Json(duyuru);
        }
    }
}