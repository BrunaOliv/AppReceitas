using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Application.DTOs;
using ProductCatalog.Application.Interfaces;

namespace ProductCatalog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryService _subCategoryService;

        public SubCategoryController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService ?? throw new ArgumentNullException(nameof(subCategoryService));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var subCategories = await _subCategoryService.GetSubCategories();

            if (subCategories == null || !subCategories.Any())
                return NotFound("SubCategory not found");

            return Ok(subCategories);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetSubCategory")]
        public async Task<IActionResult> GetById(int id)
        {
            var subCategory = await _subCategoryService.GetById(id);

            if (subCategory == null)
                return NotFound("SubCategory Not Found");

            return Ok(subCategory);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SubCategoryDTO subCategory)
        {
            if (subCategory == null)
                return BadRequest("Invalid SubCategory");

            await _subCategoryService.Add(subCategory);
            return new CreatedAtRouteResult("GetSubCategory", new { id = subCategory.Id }, subCategory);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] SubCategoryDTO subCategory)
        {

            if (subCategory == null)
                return NotFound("SubCategory Not Found");

            if (id != subCategory.Id)
                return NotFound("SubCategory Not Found");

            await _subCategoryService.Update(subCategory);

            return Ok(subCategory);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var category = await _subCategoryService.GetById(id);
            if (category == null)
                return NotFound("SubCategory Not Found");

            await _subCategoryService.Remove(id);
            return Ok(category);
        }
    }
}
