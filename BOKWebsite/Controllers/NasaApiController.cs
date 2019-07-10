using BOKWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BOKWebsite.Controllers
{
    public class NasaApiController : ControllerBase
    {
        public async Task<NasaApod> GetApodApi()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.nasa.gov/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Dictionary<string, string> queryParams = new Dictionary<string, string>
                {
                    { "api_key", "DEMO_KEY" }
                };
                string url = QueryHelpers.AddQueryString("planetary/apod", queryParams);

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    NasaApod nasaApod = await response.Content.ReadAsAsync<NasaApod>();
                    return nasaApod;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
