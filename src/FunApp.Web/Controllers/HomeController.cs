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
        private readonly ICategoriesService categoriesService;

        public HomeController(IJokesService jokesService, ICategoriesService categoriesService)
        {
            this.jokesService = jokesService;
            this.categoriesService = categoriesService;
        }

        public IActionResult Index()
        {
            var jokes = this.jokesService.GetRandomJokes(20);
            var categories = this.categoriesService.GetAll();

            var viewModel = new IndexViewModel
            {
                Jokes = jokes,
                Categories = categories
            };

            return View(viewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "My application has " + this.jokesService.GetCount() + " Jokes";

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
