using AppReceitas.Domain.Entities;
using AppReceitas.Domain.Filters;

namespace AppReceitas.Domain.Interfaces
{
    public interface IEvaluationRepository
    {
        Task<IEnumerable<Evaluation>> GetEvaluations();
        Task<Evaluation> GetById(int? id);
        Task<Evaluation> Create(Evaluation evaluation);
        Task<Evaluation> Update(Evaluation evaluation);
        Task<Evaluation> Remove(Evaluation evaluation);
        Task<PaginationEvaluationFilter<Evaluation>> GeyByIdRecipe(PaginationEvaluationFilter<Evaluation>? paginationEvaluationFilter);
    }
}
