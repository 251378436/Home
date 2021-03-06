using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Home.API.Filters
{
    public class GLobalActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("This is GLobalActionFilter OnActionExecuted");
            context.HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("This is GLobalActionFilter OnActionExecuting");
        }
    }
}
