using System;
using System.Collections.Generic;
using System.Text;

namespace FunApp.Services.Models.Jokes
{
    public class DetailsViewModel
    {
        public JokeDetailsViewModel Joke { get; set; }

        public int VoteUser { get; set; }
    }
}
