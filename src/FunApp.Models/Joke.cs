using Microsoft.AspNetCore.Identity;
using System;

namespace FunApp.Models
{
    public class Joke
    {
        public string Id { get; set; }

        public string Content { get; set; }

        public string CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
