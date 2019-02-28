using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.AppState.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.AppState.Controllers
{
    public class LoginController : Controller
    {
       
        public IActionResult Login()
        {
            return View();
        }
       
        [HttpPost]
        public IActionResult Login(String userName, String password)
        {
             
           if(!userName.Equals("a") && !password.Equals("1"))
            {
                return RedirectToAction("Login");
            }
            
            Response.Cookies.Append("mykey", "myvalue",
            new CookieOptions()
            {
                //Expires = DateTime.Now.AddSeconds(10)
            });

            var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, userName)
                }, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return View();


        }

        public IActionResult Buy(String userName, String password)
        {
            
            string cookieValueFromReq = Request.Cookies["Key"];
            var cookie = Request.Cookies["mykey"];

            if (cookie == null)
                return RedirectToAction("Login");
          
           
            

            return View();
        }
    }
}