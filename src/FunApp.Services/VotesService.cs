using FunApp.Common;
using FunApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunApp.Services
{
    public class VotesService : IVotesService
    {
        private readonly IRepository<Vote> votesRepository;

        public VotesService(IRepository<Vote> votesRepository)
        {
            this.votesRepository = votesRepository;
        }

        public bool AddRatingToJoke(int jokeId, int rating, string userId)
        {
            var voteRating = this.votesRepository.All()
                .Where(j => j.JokeId == jokeId)
                .Where(j => j.FunAppUserId == userId)
                .FirstOrDefault();

            if (voteRating != null)
            {
                voteRating.RatingVote = rating;
                this.votesRepository.Update(voteRating);
                this.votesRepository.SaveChangesAsync();

                return true;
            } 
            else if(voteRating == null)
            {
                var vote = new Vote
                {
                    RatingVote = rating,
                    FunAppUserId = userId,
                    JokeId = jokeId
                };

               this.votesRepository.AddAsync(vote);
               this.votesRepository.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public int GetVoteJokeByUser(int jokeId, string userId)
        {
            var rating = this.votesRepository
               .All()
               .Where(x => x.JokeId == jokeId)
               .Where(x => x.FunAppUserId == userId)
               .FirstOrDefault();

            if(rating == null)
            {
                return 0;
            }
            else
            {
                return rating.RatingVote;
            }
           
        }
    }
}
