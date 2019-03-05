using FunApp.Models;
using FunApp.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FunApp.Services.Models.Jokes
{
    public class JokeDetailsViewModel : IMapFrom<Joke>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string CategoryName { get; set; }

        public int ratingJokeByUser { get; set; }

        public string HtmlContent // replace new line in html 
        {
            get
            {
                return this.Content.Replace("\n", "<br />\n");
            }
        }
    }
}
