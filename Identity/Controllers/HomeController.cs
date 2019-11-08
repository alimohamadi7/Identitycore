using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Identity.Models;
using Identity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using WebApp.Filters;
using Microsoft.AspNetCore.DataProtection;

namespace Identity.Controllers
{
    
    public class HomeController : Controller
    {
       
     
        
        const string SessionName = "_Name";
        const string SessionAge = "_Age";
        
        public IActionResult Index()
        {
            HttpContext.Session.SetString(SessionName, "Jarvik");
            HttpContext.Session.SetInt32(SessionAge, 24);
            return View();
        }
        [Authorize(nameof(ConstantPolicies.DynamicPermission))]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
