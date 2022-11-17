using AppReceitas.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppReceitas.Application.Interfaces
{
    public interface IEvaluationService
    {
        Task<IEnumerable<EvaluationDTO>> GetEvaluation();
        Task<EvaluationDTO> GetById(int? id);
        Task Update(EvaluationDTO evaluationDTO);
        Task Remove(int? id);
        Task Add(EvaluationDTO evaluationDTO);
        Task<PaginationFilterEvaluationResult<EvaluationDTO>> GetEvaluationByIdRecipe(PaginationFilterEvaluationRequest paginationFilterEvaluationRequest);
    }
}
