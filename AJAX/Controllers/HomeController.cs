using AJAX.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AJAX.Controllers
{
    public class HomeController : Controller
    {
      

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult FirstAjex()
        {
            return View();
        }
        public IActionResult Address()
        {
            return View();
        }
        public IActionResult consider()
        {
            return View();
        }
        public IActionResult Promise()
        {
            return View();
        }
        public IActionResult Fetch()
        {
            return View();
        }

        public IActionResult Homework3()
        {
            return View();
        }

        public IActionResult Homework2()
        {
            return View();
        }
        public IActionResult AjexPost()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult jQuery()
        {
            return View();
        }

        public IActionResult Partial()
        {
            ViewBag.data = "Hello partial!";
            return PartialView();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
