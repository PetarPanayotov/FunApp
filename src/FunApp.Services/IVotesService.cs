using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FunApp.Services
{
    public interface IVotesService
    {
        bool AddRatingToJoke(int jokeId, int rating, string userId);

        int GetVoteJokeByUser(int jokeId, string userId);
    }
}
