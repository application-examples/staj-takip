using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StajyerTakip.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult AuthProblem()
        {
            return View();
        }
    }
}