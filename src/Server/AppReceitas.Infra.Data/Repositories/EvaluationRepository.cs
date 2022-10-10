using AppReceitas.Domain.Entities;
using AppReceitas.Domain.Interfaces;
using AppReceitas.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AppReceitas.Infra.Data.Repositories
{
    public class EvaluationRepository : IEvaluationRepository
    {
        ApplicationDbContext _evaluationContext;
        public EvaluationRepository(ApplicationDbContext context)
        {
            _evaluationContext = context;
        }
        public async Task<Evaluation> Create(Evaluation evaluation)
        {
            _evaluationContext.Add(evaluation);
            await _evaluationContext.SaveChangesAsync();
            return evaluation;
        }

        public async Task<Evaluation> GetById(int? id)
        {
            return await _evaluationContext.Evaluation.FindAsync(id);
        }

        public async Task<IEnumerable<Evaluation>> GetEvaluations()
        {
            return await _evaluationContext.Evaluation.ToListAsync();
        }

        public async Task<Evaluation> Remove(Evaluation evaluation)
        {
            _evaluationContext.Remove(evaluation);
            await _evaluationContext.SaveChangesAsync();
            return evaluation;
        }

        public async Task<Evaluation> Update(Evaluation evaluation)
        {
            _evaluationContext.Update(evaluation);
            await _evaluationContext.SaveChangesAsync();
            return evaluation;
        }
    }
}
