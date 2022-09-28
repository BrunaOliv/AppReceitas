using AppReceitas.Application.DTOs;
using AppReceitas.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppReceitas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        private IBlobService _blobService;
        public RecipeController(IRecipeService recipeService, IBlobService blobService)
        {
            _recipeService = recipeService;
            _blobService = blobService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationFilterRequest paginationFilterRequest)
        {
            var recipes = await _recipeService.GetRecipes(paginationFilterRequest);

            if(recipes == null)
                return NotFound("Recipe Not Found");

            return Ok(recipes);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetRecipe")]
        public async Task<IActionResult> GetById(int id)
        {
            var recipe = await _recipeService.GetById(id);

            if (recipe == null)
                return NotFound("Recipe Not Found");

            return Ok(recipe);
        }
        
        [HttpGet]
        [Route("category")]
        public async Task<IActionResult> GetRecipeCategory(int id)
        {
            var recipe = await _recipeService.GetRecipeCategory(id);

            if (recipe == null)
                return NotFound("Recipe Not Found");

            return Ok(recipe);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RecipeDTO recipe)
        {
            if (recipe == null)
                return BadRequest("Recipe invalid");

            await _recipeService.Add(recipe);
            return Ok();
            //return new CreatedAtRouteResult("GetRecipe", new { id = recipe.Id }, recipe);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] RecipeDTO recipe)
        {
            if (recipe == null)
                return NotFound("Recipe Not Found");

            if (id != recipe.Id)
                return NotFound("Recipe Not Found");

            await _recipeService.Update(recipe);
            return Ok(recipe);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var recipe = await _recipeService.GetById(id);

            if (recipe == null)
                return NotFound("Recipe Not Found");

            await _recipeService.Remove(id);
            return Ok(recipe);
        }

        [HttpPost(), DisableRequestSizeLimit]
        [Route("image")]
        public async Task<ActionResult> UploadProfilePicture()
        {
            IFormFile file = Request.Form.Files[0];
            if (file == null)
            {
                return BadRequest();
            }

            var result = await _blobService.UploadFileBlobAsync(
                    "appreceitas",
                    file.OpenReadStream(),
                    file.ContentType,
                    file.FileName);

            var toReturn = result.AbsoluteUri;

            return Ok(new { path = toReturn });
        }
    }
}
