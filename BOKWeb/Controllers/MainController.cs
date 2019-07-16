using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BOKWeb.Controllers
{
    public class MainController : Controller
    {
        private BOKWebContext _context;

        public MainController(BOKWebContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreatePost()
        {
            return View();
        }
    }
}