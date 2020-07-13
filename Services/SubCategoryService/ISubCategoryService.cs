using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.SubCategoryService
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
