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

        [DisplayName("Content")]
        public string Content { get; set; }

        [DisplayName("Category")]
        public string CategoryName { get; set; }
    }
}
