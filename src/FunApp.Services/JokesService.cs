using FunApp.Common;
using FunApp.Models;
using FunApp.Services.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FunApp.Services
{
    public class JokesService : IJokesService
    {
        private readonly IRepository<Joke> jokesRepository;

        public JokesService(IRepository<Joke> jokesRepository)
        {
            this.jokesRepository = jokesRepository;
        }

        public IEnumerable<IndexJokeViewModel> GetRandomJokes(int count)
        {
            var jokes = this.jokesRepository.All()
              .OrderBy(x => Guid.NewGuid())
              .Select(x => new IndexJokeViewModel
              {
                  Content = x.Content,
                  CategoryName = x.Category.Name,
              }).Take(count).ToList();

            return jokes;
        }

        public int GetCount()
        {
            return this.jokesRepository.All().Count();
        }
    }
}
