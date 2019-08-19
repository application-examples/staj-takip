using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StajyerTakip.Attributes
{
    public class ExceptionAttribute : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            

        }
    }
}
