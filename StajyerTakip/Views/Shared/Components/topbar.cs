using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StajyerTakip.Controllers
{
    public class topbar : ViewComponent
    {
        private readonly Context db;

        public topbar(Context _db)
        {
            db = _db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var duyurular = await db.Duyurular.ToListAsync(); 
            return View("Topbar", duyurular);   
        }

    }
}
