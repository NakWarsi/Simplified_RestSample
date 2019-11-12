using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Refit;
using WebSamples.Models;

namespace WebSamples.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _client;
        private readonly IGitHubApi _restApiService;
        public HomeController()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://api.github.com"),
                DefaultRequestHeaders = {UserAgent = { ProductInfoHeaderValue.Parse("NakWarsi")}}
            };
            _restApiService = RestService.For<IGitHubApi>(_client);
        }
        public async Task<ViewResult> Index()
        {
            UserDetails userDetails;
            try
            {
                userDetails = await _restApiService.GiTHubUserDetails();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return View(userDetails);
        }

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
