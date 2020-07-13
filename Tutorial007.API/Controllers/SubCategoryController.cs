using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;
using Services;
using Services.SubCategoryService;

namespace Tutorial007.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryService _subCategoryService;

        public SubCategoryController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }

        //GET /api/SubCategory
        [HttpGet]
        public IActionResult GetSubCategories()
        {
            return Ok(_subCategoryService.GetSubCategories());
        }

        // GET: /api/SubCategory/GetSubCategoryById/1
        [HttpGet]
        [Route("[action]/{Id:int?}")]
        public IActionResult GetSubCategoryById(int? Id)
        {
            var subCategory = _subCategoryService.getSubCategoryById(Id);
            if (subCategory == null)
            {
                return BadRequest("SubCategory Not Found!!");
            }

            return Ok(subCategory);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult CreateSubCategory([FromBody]SubCategory subCategory)
        {
            if (ModelState.IsValid)
            {
                _subCategoryService.CreateSubCategory(subCategory);
            }
            return Ok(subCategory);
        }

        [HttpPut]
        [Route("[action]")]
        public IActionResult UpdateSubCategory([FromBody]SubCategory subCategory)
        {
            if (ModelState.IsValid)
            {
                _subCategoryService.UpdateSubCategory(subCategory);
            }
            return Ok(subCategory);
        }

        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteSubCategory([FromBody] SubCategory subCategory)
        {
            if (ModelState.IsValid)
            {
                _subCategoryService.DeleteSubCategory(subCategory);
            }
            return Ok();
        }
    }
}
