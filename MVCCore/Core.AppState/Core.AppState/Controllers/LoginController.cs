using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.AppState.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Core.AppState.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        private bool IsAuthenticated(string username, string password)
        {
            return (username == "admin" && password == "123");
        }
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            //if (String.IsNullOrEmpty(userName) && String.IsNullOrEmpty(password))
            //{
            //    return RedirectToAction("Login");
            //}
            if (!IsAuthenticated(model.Username, model.Password))
                return View();
            // create claims
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Cookie authentication demo"),
            };

            // create identity
            ClaimsIdentity identity = new ClaimsIdentity(claims, "cookie");

            // create principal
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            HttpContext.SignInAsync(
            scheme: "DemoSecurityScheme",
            principal: principal,
            properties: new AuthenticationProperties
            {
                //IsPersistent = true, // for 'remember me' feature
                //ExpiresUtc = DateTime.UtcNow.AddMinutes(1)
            });

            //check name and password]
            //if (userName.Equals("admin") && password.Equals("123"))
            //{
            //    //Create the identity for the user  
            //    var identity = new ClaimsIdentity(new[] {
            //        new Claim(ClaimTypes.Name, userName)
            //    }, CookieAuthenticationDefaults.AuthenticationScheme);

            //    var principal = new ClaimsPrincipal(identity);

            //    var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            //    return RedirectToAction("Index", "Home");
            //}
            return Redirect(model.RequestPath ?? "/");


        }

        public IActionResult Buy(String userName, String password)
        {

            if (String.IsNullOrEmpty(userName) && String.IsNullOrEmpty(password))
            {
                return RedirectToAction("Login");
            }
            return View();
        }
    }
}