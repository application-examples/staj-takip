using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using StajyerTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StajyerTakip.Attributes
{
    public class GunlukGoruntuleme : ActionFilterAttribute
    {
        private readonly Context db;

        public GunlukGoruntuleme(Context _db)
        {
            db = _db;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var id = (int)context.HttpContext.Session.GetInt32("id");
            var yetki = context.HttpContext.Session.GetInt32("yetki");
            var profilid = context.HttpContext.Session.GetInt32("profilid");
            var kadi = context.HttpContext.Session.GetString("kadi");

            int gunlukid = (int) context.ActionArguments["id"];

            if (yetki == 4)
            {
                Stajyer stajyer = db.Stajyerler.Where(x => x.ID == id).Include(x => x.Profil).Include(x=>x.Gunlukler).FirstOrDefault();
                if (!stajyer.Gunlukler.Any(x => x.ID == gunlukid))
                    context.Result = new RedirectResult("~/Gunluk/Listele/" + id);
            }
            if(yetki == 3)
            {
                //Birim koordinatörünün sadece kendi biriminden olan stajyerlerin günlüklerini görüntülemeye hakkı vardır.

                BirimKoordinatoru koordinator = db.BirimKoordinatorleri.Where(x => x.ID == id).Include(x => x.Profil).Include(x => x.Birimler).FirstOrDefault();
                Gunluk gunluk = db.Gunlukler.Find(gunlukid);
                Stajyer stajyer = db.Stajyerler.Where(x => x.ID == gunluk.OgrenciID).Include(x => x.Profil).Include(x => x.Birimler).FirstOrDefault();

                foreach(var birim in koordinator.Birimler)
                {
                    if(stajyer.Birimler.Any(x=>x.BirimID == birim.BirimID))
                    {
                        return;
                    }
                }
                context.Result = new RedirectResult("~/Error/AuthProblem");
            }
            if(yetki == 2 || yetki == 1)
            {
                //Burada bir şey yapmamıza gerek yok Moderatör ve sistem yöneticisi bütün günlükleri görüntüleyebilir.
            }
            base.OnActionExecuting(context);
        }
    }
}
