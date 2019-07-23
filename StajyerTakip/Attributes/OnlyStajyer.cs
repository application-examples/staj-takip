using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StajyerTakip.Attributes
{
    public class OnlyStajyer : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var yetki = context.HttpContext.Session.GetInt32("yetki");
            
            if(yetki != 4)

            base.OnActionExecuting(context);
        }
    }
}
