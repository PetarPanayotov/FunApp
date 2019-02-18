using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FunApp.Web.Models;
using FunApp.Common;
using FunApp.Models;
using FunApp.Services;
using FunApp.Services.Models.Home;

namespace FunApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJokesService jokesService;

        public HomeController(IJokesService jokesService)
        {
            this.jokesService = jokesService;
        }

        public IActionResult Index()
        {
            var jokes = this.jokesService.GetRandomJokes(20);

            var viewModel = new IndexViewModel
            {
                Jokes = jokes
            };

            return View(viewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "My application has " + this.jokesService.GetCount() + " Jokes";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
