using AppReceitas.Domain.Entities;

namespace AppReceitas.Domain.Interfaces
{
    public interface IRecipesRepository
    {
        Task<IEnumerable<Recipes>> GetRecipesAsync();
        Task<Recipes> GetByIdAsync(int? id);
        Task<Recipes> GetRecipesCategoryAsync(int? id);
        Task<Recipes> CreateAsync(Recipes recipe);
        Task<Recipes> UpdateAsync(Recipes recipe);
        Task<Recipes> RemoveAsync(Recipes recipe);
    }
}
