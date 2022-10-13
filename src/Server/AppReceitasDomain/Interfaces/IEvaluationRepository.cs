using AppReceitas.Domain.Entities;

namespace AppReceitas.Domain.Interfaces
{
    public interface IEvaluationRepository
    {
        Task<IEnumerable<Evaluation>> GetEvaluations();
        Task<Evaluation> GetById(int? id);
        Task<Evaluation> Create(Evaluation evaluation);
        Task<Evaluation> Update(Evaluation evaluation);
        Task<Evaluation> Remove(Evaluation evaluation);
        Task<IEnumerable<Evaluation>> GeyByIdRecipe(int? id);
    }
}
