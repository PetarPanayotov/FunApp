﻿using FunApp.Services.Models;
using FunApp.Services.Models.Categories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunApp.Services
{
    public interface ICategoriesService
    {
        IEnumerable<CategoryIdAndNameViewModel> GetAll();

        bool IsCategoryIdValid(int categoryId);

        bool IsCategoryNameValid(string categoryName);

        Task<string> Create(string categoryName);
    }
}