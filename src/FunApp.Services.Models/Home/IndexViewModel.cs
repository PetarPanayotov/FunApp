﻿using FunApp.Models;
using FunApp.Services.Models.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunApp.Services.Models.Home
{
    public class IndexViewModel
    {
        public IEnumerable<IndexJokeViewModel> Jokes { get; set; }

        public IEnumerable<CategoryIdAndNameViewModel> Categories { get; set; }
    }

    
}
