using AppReceitas.Domain.Entities;
using AppReceitas.Domain.Filters;
using AppReceitas.Domain.Interfaces;
using AppReceitas.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AppReceitas.Infra.Data.Repositories
{
    public class RecipeRepository : IRecipesRepository
    {
        ApplicationDbContext _recipeContext;
        public RecipeRepository(ApplicationDbContext context)
        {
            _recipeContext = context;
        }

        public async Task<Recipes> CreateAsync(Recipes recipe)
        {
            _recipeContext.Add(recipe);
            await _recipeContext.SaveChangesAsync();
            return recipe;
        }

        public async Task<Recipes> GetByIdAsync(int? id)
        {
            return await _recipeContext.Recipes.FindAsync(id);
        }

        public async Task<PaginationFilter<Recipes>> GetRecipesAsync(PaginationFilter<Recipes> paginationFilter)
        {
            var paginationResult = new PaginationFilter<Recipes>
            {
                Data = await _recipeContext.Recipes
                .Where(recipe =>
                    recipe.Name.Contains(paginationFilter.Filter.NameRecipe) ||
                    recipe.Category.Name.Contains(paginationFilter.Filter.Categoria))
                .Skip(paginationFilter.PageIndex * paginationFilter.PageSize)
                .Take(paginationFilter.PageSize)
                .ToListAsync(),
                TotalItems = await _recipeContext.Recipes.CountAsync()
            };
            return paginationResult;
        }

        public async Task<Recipes> GetRecipesCategoryAsync(int? id)
        {
            return await _recipeContext.Recipes.Include(c => c.Category)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Recipes> RemoveAsync(Recipes recipe)
        {
            _recipeContext.Remove(recipe);
            await _recipeContext.SaveChangesAsync();
            return recipe;
        }

        public async Task<Recipes> UpdateAsync(Recipes recipe)
        {
            _recipeContext.Update(recipe);
            await _recipeContext.SaveChangesAsync();
            return recipe;
        }
    }
}
