using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BOKWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace BOKWebsite.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            RegisterModel registerModel = new RegisterModel();
            return View(registerModel);
        }
    }
}