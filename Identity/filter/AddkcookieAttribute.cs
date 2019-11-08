using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
namespace WebApp.Filters
{
    public class AddkcookieAttribute : Attribute, IResourceFilter
    {
        

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
       
          
        }
        
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            CookieOptions cookie = new CookieOptions();
               
            if (context.HttpContext.Request.Cookies["testcookie"] == null)
            {
                context.Result = new ContentResult()
                {
                    Content = "کوکی مرورگر غیرفعال است لطفا کوکی را فعال نمایید !"
                };

            }
        }
    }
}