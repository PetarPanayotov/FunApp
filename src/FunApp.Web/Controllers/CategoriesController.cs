﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunApp.Services;
using FunApp.Services.Models.Home;
using FunApp.Web.Models.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

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

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var name = await this.categoriesService.Create(input.CategoryName);

            TempData["CategoryName"] = name;

            return this.RedirectToAction("Index","Home");
        }
    }
}