using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Refit;
using WebSamples.Models;

namespace WebSamples.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _client;
        private readonly IGitHubUserInterface _restApiService;
        public HomeController()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://api.github.com")
            };
            //_restApiService = RestService.For<IGitHubUserInterface>(_client);
            var gitHubApi = RestService.For<IGitHubApi>("https://api.github.com");
        }
        public async Task<ViewResult> Index()
        {
            try
            {
                var userDetails = await _restApiService.GiTHubUserDetails();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return View();
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
