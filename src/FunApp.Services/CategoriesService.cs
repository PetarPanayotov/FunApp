using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunApp.Common;
using FunApp.Models;
using FunApp.Services.Models;
using FunApp.Services.Models.Categories;

namespace FunApp.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IRepository<Category> categoriesRepository;

        public CategoriesService(IRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<CategoryIdAndNameViewModel> GetAll()
        {
            var categories = this.categoriesRepository.All().OrderBy(x => x.Name)
                .Select(x => new CategoryIdAndNameViewModel { Id = x.Id, Name = x.Name })
                .ToList();

            return categories;
        }

        public bool IsCategoryIdValid(int categoryId)
        {
            return this.categoriesRepository.All().Any(x => x.Id == categoryId);
        }

        public bool IsCategoryNameValid(string categoryName)
        {
            return this.categoriesRepository.All().Any(x => x.Name == categoryName);
        }

        public async Task<string> Create(string categoryName)
        {
            var category = new Category
            { 
                Name = categoryName
            };

            await this.categoriesRepository.AddAsync(category);
            await this.categoriesRepository.SaveChangesAsync();

            return category.Name;
        }
    }
}
