using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial007.API.Models;
using Tutorial007.Shared;

namespace Tutorial007.API.Services
{
    public interface ICategoryService
    {
        public List<Category> GetCategories();

        public Category getCategoryById(int? Id);

        public void CreateCategory(Category category);

        public Category UpdateCategory(Category category);

        public Category DeleteCategory(Category category);
    }
}
