using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSamples.Models;

namespace WebSamples.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _client;
        public HomeController()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("")
            };   
            //_restApiService = RestService.For<ICycloidalCellApiService>(_client)
        }
        public IActionResult Index()
        {
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
