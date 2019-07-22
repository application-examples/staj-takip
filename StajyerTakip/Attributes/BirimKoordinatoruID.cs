using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StajyerTakip.Attributes
{
    public class BirimKoordinatoruID : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            int id = (int)context.HttpContext.Session.GetInt32("id");
            var yetki = context.HttpContext.Session.GetInt32("yetki");

            if (yetki == 3)
                context.ActionArguments["id"] = id;
            base.OnActionExecuting(context);
        }
    }
}
