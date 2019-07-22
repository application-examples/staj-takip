using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StajyerTakip.Attributes
{
    public class ModeratorID : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var yetki = context.HttpContext.Session.GetInt32("yetki");
            int id = (int)context.HttpContext.Session.GetInt32("id");

            if (yetki == 2)
                context.ActionArguments["id"] = id;

            base.OnActionExecuting(context);
        }
    }
}
