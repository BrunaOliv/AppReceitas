using AppReceitas.Domain.Entities;
using AppReceitas.Domain.Filters;
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

        public async Task<PaginationEvaluationFilter<Evaluation>> GeyByIdRecipe(PaginationEvaluationFilter<Evaluation>? paginationEvaluationFilter)
        {
            var evaluations = GetEvaluationsById(paginationEvaluationFilter.FilterEvaluation.Id).AsNoTracking();
            var paginationResult = new PaginationEvaluationFilter<Evaluation>
            {
                TotalItems = await evaluations.CountAsync(),
                GeneralAverage = evaluations.Average(e => e.Grade)
            };

            if (paginationEvaluationFilter.FilterEvaluation.EvaluationType != null)
            {
                evaluations = FilterEvaluationType(paginationEvaluationFilter.FilterEvaluation.EvaluationType, evaluations);
            }

            paginationResult.Data = await evaluations
                .Skip(paginationEvaluationFilter.PageIndex * paginationEvaluationFilter.PageSize)
                .Take(paginationEvaluationFilter.PageSize)
                .ToListAsync();

            return paginationResult;
        }

        public IQueryable<Evaluation> GetEvaluationsById(int? id)
        {
            return _evaluationContext.Evaluation.Where(evaluation => id == evaluation.RecipeId);
        }

        public IQueryable<Evaluation> FilterEvaluationType(EvaluationTypeEnum? evaluationType, IQueryable<Evaluation> evaluation)
        {
            if(((int)evaluationType) == 0)
            {
                return evaluation.Where(e => e.Grade > 2);
            }

            return evaluation.Where(e => e.Grade <= 2);      
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
