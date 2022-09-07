using AppReceitas.Domain.Entities;
using AppReceitas.Domain.Filters;

namespace AppReceitas.Domain.Interfaces
{
    public interface IRecipesRepository
    {
        Task<PaginationFilter<Recipes>> GetRecipesAsync(PaginationFilter<Recipes> paginationFilter);
        Task<Recipes> GetByIdAsync(int? id);
        Task<Recipes> GetRecipesCategoryAsync(int? id);
        Task<Recipes> CreateAsync(Recipes recipe);
        Task<Recipes> UpdateAsync(Recipes recipe);
        Task<Recipes> RemoveAsync(Recipes recipe);
    }
}
