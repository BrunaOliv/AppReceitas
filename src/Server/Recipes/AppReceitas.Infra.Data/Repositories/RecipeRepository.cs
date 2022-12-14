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
            return  await _recipeContext.Recipes
                .Include(r => r.Category)
                .Include(r => r.Level)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<PaginationFilter<Recipes>> GetRecipesAsync(PaginationFilter<Recipes> paginationFilter)
        {
            var recipes = GetAllRecipes().AsNoTracking();

            if (paginationFilter.Filter != null)
            {
                recipes = FilterRecipes(paginationFilter, recipes);
            }

            var paginationResult = new PaginationFilter<Recipes>
            {
                Data = await recipes
                .Skip(paginationFilter.PageIndex * paginationFilter.PageSize)
                .Take(paginationFilter.PageSize)
                .ToListAsync(),
                TotalItems = await recipes.CountAsync()
            };
            return paginationResult;
        }

        public IQueryable<Recipes> GetAllRecipes()
        {
            return _recipeContext.Recipes
                .Include(c => c.Category)
                .Include(c => c.Level);
        } 

        public IQueryable<Recipes> FilterRecipes(PaginationFilter<Recipes> paginationFilter, IQueryable<Recipes> recipes)
        {
            return recipes
            .Where(recipe => string.IsNullOrEmpty(paginationFilter.Filter.NameRecipe) || recipe.Name.Contains(paginationFilter.Filter.NameRecipe))
            .Where(recipe => string.IsNullOrEmpty(paginationFilter.Filter.Category) || recipe.Category.Name.Contains(paginationFilter.Filter.Category))
            .Where(recipe => string.IsNullOrEmpty(paginationFilter.Filter.Level) || recipe.Level.Name.Contains(paginationFilter.Filter.Level));
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
