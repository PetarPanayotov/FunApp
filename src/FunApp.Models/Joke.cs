using Microsoft.AspNetCore.Identity;
using System;

namespace FunApp.Models
{
    public class Joke
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int Rating { get; set; }
    }
}
