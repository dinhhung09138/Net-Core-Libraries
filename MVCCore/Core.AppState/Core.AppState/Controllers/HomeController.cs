using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.AppState.Controllers
{
    public class HomeController : Controller
    {
        const string SessionName = "_Name";
        const string SessionAge = "_Age";
        public IActionResult Index()
        {
            HttpContext.Session.SetString(SessionName, "Nam");
            HttpContext.Session.SetInt32(SessionAge, 20);
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Name = HttpContext.Session.GetString(SessionName);  
            ViewBag.Age = HttpContext.Session.GetInt32(SessionAge);  
            return View();
        }

        
    }
}
