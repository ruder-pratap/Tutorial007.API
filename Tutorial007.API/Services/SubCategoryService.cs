using System.Collections.Generic;
using System.Linq;
using Tutorial007.API.Models;

namespace Tutorial007.API.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ApplicationDbContext db;

        public SubCategoryService(ApplicationDbContext db) 
        {
            this.db = db;
        }

        public void CreateSubCategory(SubCategory subCategory)
        {
            db.Add(subCategory);
            db.SaveChanges();
        }

        public SubCategory DeleteSubCategory(SubCategory subCategory)
        {
            db.Remove(subCategory);
            db.SaveChanges();
            return subCategory;
        }

        public List<SubCategory> GetSubCategories()
        {
            var result = db.SubCategories.ToList();
            return result;
        }

        public SubCategory getSubCategoryById(int? Id)
        {
            SubCategory subCategory = db.SubCategories.Find(Id);
            return subCategory;
        }

        public SubCategory UpdateSubCategory(SubCategory subCategory)
        {
            var subCategoryData = db.Update(subCategory);
            db.SaveChanges();
            return subCategory;
        }
    }
}
