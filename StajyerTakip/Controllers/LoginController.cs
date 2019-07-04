using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StajyerTakip.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            //Login indexe yönlendir.
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}