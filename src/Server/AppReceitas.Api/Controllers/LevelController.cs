using AppReceitas.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppReceitas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelController : ControllerBase
    {
        private readonly ILevelService _levelService;
        public LevelController(ILevelService levelService)
        {
            _levelService = levelService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var levels = await _levelService.GetLevels();

            if (levels == null || !levels.Any())
                return NotFound("Levels Not Found");

            return Ok(levels);
        }
    }
}
