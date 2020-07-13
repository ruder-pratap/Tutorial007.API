using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Services;
using Services.CategoryService;

namespace Tutorial007.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        //GET /api/Category
        [HttpGet]
        public IActionResult GetCategories()
        {
            return Ok(_categoryService.GetCategories());
        }

        // GET: /api/Category/GetCategoryById/1
        [HttpGet]
        [Route("[action]/{Id:int?}")]
        public IActionResult GetCategoryById(int? Id)  
        {  
            Category category = _categoryService.getCategoryById(Id);  
            if (category == null)  
            {  
                return BadRequest("Category Not Found!!");  
            }  
  
            return Ok(category);  
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult CreateCategory([FromBody]Category category)
        {
            if (ModelState.IsValid)
            {
                //IMAPPER.MAP(CATEVM, Category);
                _categoryService.CreateCategory(category);
            }
            return Ok(category);
        }

        [HttpPut]
        [Route("[action]")]
        public IActionResult UpdateCategory([FromBody]Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.UpdateCategory(category);
            }
            return Ok(category);
        }

        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteCategory([FromBody]Category category)
        {
            if(ModelState.IsValid)
            {
                _categoryService.DeleteCategory(category);
            }
            return Ok();
        }

    }
}
