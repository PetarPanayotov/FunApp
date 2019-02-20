using FunApp.Services.Models;
using FunApp.Services.Models.Categories;
using System.Collections.Generic;

namespace FunApp.Services
{
    public interface ICategoriesService
    {
        IEnumerable<CategoryIdAndNameViewModel> GetAll();

        bool IsCategoryIdValid(int categoryId);
    }
}