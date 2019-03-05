using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunApp.Models;
using FunApp.Services;
using FunApp.Services.Models.Jokes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FunApp.Web.Controllers
{
    public class JokesController : Controller
    {
        private readonly IJokesService jokesService;
        private readonly IVotesService votesService;
        private readonly ICategoriesService categoriesService;
        private readonly UserManager<FunAppUser> userManager;

        public JokesController(IJokesService jokesService, IVotesService votesService, ICategoriesService categoriesService, UserManager<FunAppUser> userManager)
        {
            this.jokesService = jokesService;
            this.votesService = votesService;
            this.categoriesService = categoriesService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Create()
        {
            this.ViewData["Categories"] = this.categoriesService.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateJokeInputModel input)
        {
            if(!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var id = await this.jokesService.Create(input.CategoryId, input.Content);

            return this.RedirectToAction("Details", new { id = id });
        }

        [Authorize]
        public IActionResult Details(int id)
        {
            var userId = userManager.GetUserId(User);

            var joke = this.jokesService.GetJokeById(id);
            var vote = this.votesService.GetVoteJokeByUser(id, userId);

            var viewModel = new DetailsViewModel
            {
                Joke = joke,
                VoteUser = vote
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public JsonResult RateJoke(int jokeId, int rating)
        {
            var userId = userManager.GetUserId(User);
            var rateJoke = this.votesService.AddRatingToJoke(jokeId, rating, userId);

            if (!rateJoke)
            {
                return Json($"An error occurred while processing your vote");
            }

            this.jokesService.UpdateRatingJoke(jokeId, rating);
            var successMessage = $"You successfully rated the joke with rating of {rating}";

            return Json(successMessage);
        }
    }
}