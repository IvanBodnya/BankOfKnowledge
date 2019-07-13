using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BOKWebsite.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BOKWebsite.Controllers
{
    public class AccountController : Controller
    {
        [Authorize]
        public IActionResult VIP()
        {
            VIPModel VIPModel = new VIPModel
            {
                OwnerID = "1", Email = "ivanbodnya@gmail.com", Password = "1234aed"
            };
            return View(VIPModel);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string userName, string password)
        {
            if(!string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(password))
            {
                return RedirectToAction("Login");
            }
            if (userName == "Admin" && password == "password")
            {
                ClaimsIdentity identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name,userName)
                }, CookieAuthenticationDefaults.AuthenticationScheme);  

                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                Task login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("VIP", "Account");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Employee");
        }
    }
}