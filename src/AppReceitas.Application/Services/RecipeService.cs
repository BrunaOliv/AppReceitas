using AppReceitas.Application.DTOs;
using AppReceitas.Application.Interfaces;
using AppReceitas.Domain.Entities;
using AppReceitas.Domain.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppReceitas.Application.Services
{
    public class RecipeService: IRecipeService
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

        public async Task<IEnumerable<RecipeDTO>> GetRecipes()
        {
            var recipeEntity = await _recipesRepository.GetRecipesAsync();
            return _mapper.Map<RecipeDTO[]>(recipeEntity);
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
