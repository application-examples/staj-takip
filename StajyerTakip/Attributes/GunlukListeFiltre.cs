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
    public class GunlukListeFiltre : ActionFilterAttribute
    {

        private readonly Context db;

        public GunlukListeFiltre(Context _db)
        {
            db = _db;
        }


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var id = (int)context.HttpContext.Session.GetInt32("id");
            var yetki = context.HttpContext.Session.GetInt32("yetki");
            var profilid = context.HttpContext.Session.GetInt32("profilid");
            var kadi = context.HttpContext.Session.GetString("kadi");

            if (yetki == 3)
            {
                BirimKoordinatoru koordinator = db.BirimKoordinatorleri.Where(x => x.ID == id).Include(x => x.Profil).Include(x => x.Birimler).SingleOrDefault();
                int listid = (int)context.ActionArguments["id"];
                Stajyer stajyer = db.Stajyerler.Where(x => x.ID == listid).Include(x => x.Profil).Include(x => x.Birimler).SingleOrDefault();
                foreach (var birim in koordinator.Birimler)
                {
                    if (stajyer.Birimler.Any(x => x.BirimID == birim.BirimID))
                    {
                        return;
                    }
                }
                context.Result = new RedirectResult("~/Error/AuthProblem");
            }
            base.OnActionExecuting(context);
        }
    }
}
