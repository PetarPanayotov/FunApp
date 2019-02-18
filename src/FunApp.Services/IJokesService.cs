using FunApp.Models;
using FunApp.Services.Models.Home;
using System.Collections.Generic;

namespace FunApp.Services
{
    public interface IJokesService
    {
        IEnumerable<IndexJokeViewModel> GetRandomJokes(int count);

        int GetCount();
    }
}