﻿using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Text;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ViewResult Index()
        {
            return View("Welcome");
        }

        public ContentResult GetContent()
        {

            return Content("<label style= \"color:red;\"> Welcome to RMS!! </label>", "text/html", Encoding.UTF8);
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