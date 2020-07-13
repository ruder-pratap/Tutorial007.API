using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.CategoryService
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
