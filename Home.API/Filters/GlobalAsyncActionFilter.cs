using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Home.API.Filters
{
    public class GLobalAsyncActionFilter : IAsyncActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("This is GLobalActionFilter OnActionExecuted");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("This is GLobalActionFilter OnActionExecuting");
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine("This is GLobalAsyncActionFilter before OnActionExecutionAsync");
            var resultContext = await next();
            Console.WriteLine("This is GLobalAsyncActionFilter after OnActionExecutionAsync");
        }
    }
}
