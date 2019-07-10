using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BOKWebsite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BOKWebsite.Controllers
{
    public class NasaController : Controller
    {
        public async Task<IActionResult> APOD()
        {
            NasaApiController nasaApiController = new NasaApiController();
            NasaApod nasaApod = await nasaApiController.GetApodApi();

            return View(nasaApod);
        }
    }
}