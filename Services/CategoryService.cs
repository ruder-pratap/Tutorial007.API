using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDBContext db;

        public CategoryService(ApplicationDBContext db)
        {
            this.db = db;
        }

        public void CreateCategory(Category category)
        {
            db.Add(category);
            db.SaveChanges();
        }

        public List<Category> GetCategories()
        {
            var result = db.categories.ToList();
            return result;
        }

        public Category getCategoryById(int? Id)
        {
            Category category = db.categories.Find(Id);
            return category;
        }

        public Category UpdateCategory(Category category)
        {
            var categoryData = db.Update(category);
            db.SaveChanges();
            return category;
        }

        public Category DeleteCategory(Category category)
        {
            db.Remove(category);
            db.SaveChanges();
            return category;
        }

    }
}
