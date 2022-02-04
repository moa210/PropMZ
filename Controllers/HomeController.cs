﻿namespace PropMZ.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Models;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) => _logger = logger;

        public IActionResult Index() => View();

        public IActionResult AboutUs() => View();

        public IActionResult Ethos() => View();

        public IActionResult OurVision() => View();

        public IActionResult Learn() => View();

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel
                                             { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
