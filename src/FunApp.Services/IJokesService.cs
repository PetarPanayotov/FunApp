using FunApp.Models;
using FunApp.Services.Models.Home;
using FunApp.Services.Models.Jokes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunApp.Services
{
    public interface IJokesService
    {
        IEnumerable<IndexJokeViewModel> GetRandomJokes(int count);

        int GetCount();

        Task<int> Create(int CategoryId, string content);

        JokeDetailsViewModel GetJokeById(int id);

        IEnumerable<IndexJokeViewModel> GetJokesByCategory(int id, int count);
    }
}