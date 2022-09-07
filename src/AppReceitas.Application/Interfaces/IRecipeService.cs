using AppReceitas.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppReceitas.Application.Interfaces
{
    public interface IRecipeService
    {
        Task<PaginationFilterResult<RecipeDTO>> GetRecipes(PaginationFilterRequest paginationFilterRequest);
        Task<RecipeDTO> GetById(int? id);
        Task<RecipeDTO> GetRecipeCategory(int? id);
        Task Add(RecipeDTO recipeDTO);
        Task Update(RecipeDTO recipeDTO);
        Task Remove(int? id);
    }
}
