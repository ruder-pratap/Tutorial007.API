using System.Collections.Generic;
using Tutorial007.API.Models;

namespace Tutorial007.API.Services
{
    public interface ISubCategoryService
    {
        public List<SubCategory> GetSubCategories();

        public SubCategory getSubCategoryById(int? Id);

        public void CreateSubCategory(SubCategory subCategory);

        public SubCategory UpdateSubCategory(SubCategory subCategory);

        public SubCategory DeleteSubCategory(SubCategory subCategory);
    }
}
