using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StajyerTakip.Attributes
{
    public class StajyerID : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var yetki = context.HttpContext.Session.GetInt32("yetki");
            if (yetki == 4)
                context.ActionArguments["id"] = context.HttpContext.Session.GetInt32("id");

            base.OnActionExecuting(context);
        }
    }
}
