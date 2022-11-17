using AppReceitas.Application.DTOs;
using AppReceitas.Application.Interfaces;
using AppReceitas.Domain.Entities;
using AppReceitas.Domain.Filters;
using AppReceitas.Domain.Interfaces;
using AutoMapper;

namespace AppReceitas.Application.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipesRepository _recipesRepository;
        private readonly IMapper _mapper;
        public RecipeService(IRecipesRepository recipesRepository, IMapper mapper)
        {
            _recipesRepository = recipesRepository;
            _mapper = mapper;
        }

        public async Task Add(RecipeDTO recipeDTO)
        {
            var recipeEntity = _mapper.Map<Recipes>(recipeDTO);
            await _recipesRepository.CreateAsync(recipeEntity);
        }

        public async Task<RecipeDTO> GetById(int? id)
        {
            var recipeEntity = await _recipesRepository.GetByIdAsync(id);
            return _mapper.Map<RecipeDTO>(recipeEntity);
        }

        public async Task<RecipeDTO> GetRecipeCategory(int? id)
        {
            var recipeEntity = await _recipesRepository.GetRecipesCategoryAsync(id);
            return _mapper.Map<RecipeDTO>(recipeEntity);
        }

        public async Task<PaginationFilterResult<RecipeDTO>> GetRecipes(PaginationFilterRequest paginationFilterRequest)
        {
            var paginationFilter = _mapper.Map<PaginationFilter<Recipes>>(paginationFilterRequest);
            var recipeEntity = await _recipesRepository.GetRecipesAsync(paginationFilter);
            return _mapper.Map<PaginationFilterResult<RecipeDTO>>(recipeEntity);
        }

        public async Task Remove(int? id)
        {
            var recipeEntity = _recipesRepository.GetByIdAsync(id).Result;
            await _recipesRepository.RemoveAsync(recipeEntity);
        }

        public async Task Update(RecipeDTO recipeDTO)
        {
            var recipeEntity = _mapper.Map<Recipes>(recipeDTO);
            await _recipesRepository.UpdateAsync(recipeEntity);
        }

    }
}
