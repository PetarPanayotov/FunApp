﻿using FunApp.Services.Models;
using System.Collections.Generic;

namespace FunApp.Services
{
    public interface ICategoriesService
    {
        IEnumerable<IdAndNameViewModel> GetAll();

        bool IsCategoryIdValid(int categoryId);
    }
}