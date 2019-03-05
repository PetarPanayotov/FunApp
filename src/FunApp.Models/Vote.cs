using System;
using System.Collections.Generic;
using System.Text;

namespace FunApp.Models
{
    public class Vote
    {
        public int Id { get; set; }

        public int RatingVote { get; set; }

        public string FunAppUserId { get; set; }

        public FunAppUser FunAppUser { get; set; }

        public int JokeId { get; set; }

        public virtual Joke Joke { get; set; }
    }
}
