using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StajyerTakip.Attributes
{
    public class GirisKontrol : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var user = context.HttpContext.Session.GetString("kadi");
            var yetki = context.HttpContext.Session.GetInt32("yetki");
            if(user == null)
            {
                context.Result = new RedirectResult("~/Login/Index");
            }
            base.OnActionExecuting(context);
        }
    }
}
