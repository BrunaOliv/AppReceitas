using AppReceitas.Application.DTOs;
using AppReceitas.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppReceitas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationController : ControllerBase
    {
        private readonly IEvaluationService _evaluationService;

        public EvaluationController(IEvaluationService evaluationService)
        {
            _evaluationService = evaluationService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var evaluations = await _evaluationService.GetEvaluation();

            if (evaluations == null)
                return NotFound();

            return Ok(evaluations);
        }
        [HttpGet]
        [Route("{id:int}", Name = "GetEvaluation")]
        public async Task<IActionResult> GetById(int id)
        {
            var evalution = await _evaluationService.GetById(id);

            if (evalution == null)
                return NotFound();

            return Ok(evalution);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EvaluationDTO evaluationDTO)
        {
            if (evaluationDTO == null)
                return BadRequest();

            await _evaluationService.Add(evaluationDTO);
            return new CreatedAtRouteResult("GetEvaluation", new { id = evaluationDTO.Id }, evaluationDTO);
        }
    }
}
