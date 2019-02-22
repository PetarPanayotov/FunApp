using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunApp.Services;
using FunApp.Services.Models.Home;
using Microsoft.AspNetCore.Mvc;

namespace FunApp.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IJokesService jokesService;
        private readonly ICategoriesService categoriesService;

        public CategoriesController(IJokesService jokesService, ICategoriesService categoriesService)
        {
            this.jokesService = jokesService;
            this.categoriesService = categoriesService;
        }

        public IActionResult Index(int id)
        {
            var jokes = this.jokesService.GetJokesByCategory(id, 20);
            var categories = this.categoriesService.GetAll();

            var viewModel = new IndexViewModel
            {
                Jokes = jokes,
                Categories = categories
            };

            return View(viewModel);
        }
    }
}