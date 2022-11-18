using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Application.DTOs;
using ProductCatalog.Application.Interfaces;

namespace ProductCatalog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _categoryService.GetCategories();

            if (categories == null || !categories.Any())
                return NotFound("Category not found");

            return Ok(categories);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetCategory")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetById(id);

            if (category == null)
                return NotFound("Category Not Found");

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryDTO category)
        {
            if (category == null)
                return BadRequest("Invalid Category");

            await _categoryService.Add(category);
            return new CreatedAtRouteResult("GetCategory", new { id = category.Id }, category);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] CategoryDTO category)
        {

            if (category == null)
                return NotFound("Category Not Found");

            if (id != category.Id)
                return NotFound("Category Not Found");

            await _categoryService.Update(category);

            return Ok(category);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var category = await _categoryService.GetById(id);
            if (category == null)
                return NotFound("Category Not Found");

            await _categoryService.Remove(id);
            return Ok(category);
        }
    }
}
