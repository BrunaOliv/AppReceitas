using AppReceitas.Application.DTOs;
using AppReceitas.Application.Services;
using AppReceitas.Domain.Entities;
using AppReceitas.Domain.Filters;
using AppReceitas.Domain.Interfaces;
using AutoMapper;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AppReceitas.Tests.Api.Service
{
    public class RecipeServiceTest
    {
        private readonly Mock<IRecipesRepository> _recipesRepository = new Mock<IRecipesRepository>();
        private readonly Mock<IMapper> _mapper = new Mock<IMapper>();

        [Fact]
        public async Task Add_AddRecipe_NoReturn()
        {
            var recipe = RecipeDTOFactory();
            var recipeEntity = RecipeEntityFactory();
            _mapper.Setup(x => x.Map<Recipes>(recipe)).Returns(recipeEntity);
            _recipesRepository.Setup(x => x.CreateAsync(recipeEntity));

            var service = new RecipeService(_recipesRepository.Object, _mapper.Object);
            await service.Add(recipe);

            _mapper.Verify(x => x.Map<Recipes>(recipe), Times.Once);
            _recipesRepository.Verify(x => x.CreateAsync(recipeEntity), Times.Once);
        }

        [Fact]
        public async Task GetById_withValidId_ShouldReturnValidRecipe()
        {
            var id = 1;
            var recipeDTO = RecipeDTOFactory();
            var recipeEntity = RecipeEntityFactory();
            _mapper.Setup(x => x.Map<RecipeDTO>(recipeEntity)).Returns(recipeDTO);
            _recipesRepository.Setup(x => x.GetByIdAsync(id)).Returns(Task.FromResult(recipeEntity));

            var service = new RecipeService(_recipesRepository.Object, _mapper.Object);
            var result = await service.GetById(id);

            Assert.IsType<RecipeDTO>(result);
            _mapper.Verify(x => x.Map<RecipeDTO>(recipeEntity), Times.Once);
            _recipesRepository.Verify(x => x.GetByIdAsync(id), Times.Once);
        }

        [Fact]
        public async Task GetRecipeCategory_withValidId_ShouldReturnValidRecipe()
        {
            var id = 1;
            var recipeDTO = RecipeDTOFactory();
            var recipeEntity = RecipeEntityFactory();
            _mapper.Setup(x => x.Map<RecipeDTO>(recipeEntity)).Returns(recipeDTO);
            _recipesRepository.Setup(x => x.GetRecipesCategoryAsync(id)).Returns(Task.FromResult(recipeEntity));

            var service = new RecipeService(_recipesRepository.Object, _mapper.Object);
            var result = await service.GetRecipeCategory(id);

            Assert.IsType<RecipeDTO>(result);
            _mapper.Verify(x => x.Map<RecipeDTO>(recipeEntity), Times.Once);
            _recipesRepository.Verify(x => x.GetRecipesCategoryAsync(id), Times.Once);
        }


        [Fact]
        public async Task GetRecipes_withValidRequest_ShouldReturnValidRecipeList()
        {
            var paginationRequest = PaginationFilterRequestFactory();
            var paginationResult = RecipesDTOFactory();
            var listEntity = ListRecipeEntityFactory();
            _mapper.Setup(x => x.Map<PaginationFilter<Recipes>>(paginationRequest)).Returns(listEntity);
            _recipesRepository.Setup(x => x.GetRecipesAsync(listEntity)).Returns(Task.FromResult(listEntity));
            _mapper.Setup(x => x.Map<PaginationFilterResult<RecipeDTO>>(listEntity)).Returns(paginationResult);

            var service = new RecipeService(_recipesRepository.Object, _mapper.Object);
            var result = await service.GetRecipes(paginationRequest);

            Assert.IsType<PaginationFilterResult<RecipeDTO>>(result);
            _mapper.Verify(x => x.Map<PaginationFilter<Recipes>>(paginationRequest), Times.Once);
            _mapper.Verify(x => x.Map<PaginationFilterResult<RecipeDTO>>(listEntity), Times.Once);
            _recipesRepository.Verify(x => x.GetRecipesAsync(listEntity), Times.Once);
        }

        [Fact]
        public async Task Remove_RemoveRecipe_NoReturn()
        {
            var id = 1;
            var recipeEntity = RecipeEntityFactory();
            _recipesRepository.Setup(x => x.GetByIdAsync(id)).Returns(Task.FromResult(recipeEntity));
            _recipesRepository.Setup(x => x.RemoveAsync(recipeEntity));

            var service = new RecipeService(_recipesRepository.Object, _mapper.Object);
            await service.Remove(id);

            _recipesRepository.Verify(x => x.GetByIdAsync(id), Times.Once);
            _recipesRepository.Verify(x => x.RemoveAsync(recipeEntity), Times.Once);
        }

        [Fact]
        public async Task Update_UpdateRecipe_NoReturn()
        {
            var recipe = RecipeDTOFactory();
            var recipeEntity = RecipeEntityFactory();
            _mapper.Setup(x => x.Map<Recipes>(recipe)).Returns(recipeEntity);
            _recipesRepository.Setup(x => x.UpdateAsync(recipeEntity));

            var service = new RecipeService(_recipesRepository.Object, _mapper.Object);
            await service.Update(recipe);

            _mapper.Verify(x => x.Map<Recipes>(recipe), Times.Once);
            _recipesRepository.Verify(x => x.UpdateAsync(recipeEntity), Times.Once);
        }

        public static RecipeDTO RecipeDTOFactory()
        {
            return new RecipeDTO()
            {
                Id = 1,
                Name = "Suflê de Cenoura",
                Ingredients = "4 cenouras cozidas e amassadas, 1 colher de margarina, 1 cebola ralada, 1 pitada de sal, 1 copo de leite, 2 colheres de farinha de trigo, 100 g de queijo picado, 3 gemas e claras separadas",
                PreparationMode = "Cozinhe as cenouras e amasse e reserve. Em uma panela coloque a manteiga, a cebola ralada e deixe fritar. Coloque a farinha dissolvida no leite com as 3 gemas. Coloque na panela e o queijo picado. Deixe engrossar, desligue o fogo e coloque a cenoura amassada. Misture bem e coloque as claras em neve. Coloque em um refratário untado com margarina e coloque no forno para gratinar.",
                Image = null,
                Category = null,
                CategoryId = 1,
            };
        }
        public static PaginationFilter<Recipes> ListRecipeEntityFactory()
        {
            return new PaginationFilter<Recipes>
            {
                PageSize = 10,
                PageIndex = 1,
                TotalItems = 1,
                Data = new List<Recipes> { new Recipes(1, "Suflê de Cenoura", "4 cenouras cozidas e amassadas, 1 colher de margarina, 1 cebola ralada, 1 pitada de sal, 1 copo de leite, 2 colheres de farinha de trigo, 100 g de queijo picado, 3 gemas e claras separadas", "Cozinhe as cenouras e amasse e reserve. Em uma panela coloque a manteiga, a cebola ralada e deixe fritar. Coloque a farinha dissolvida no leite com as 3 gemas. Coloque na panela e o queijo picado. Deixe engrossar, desligue o fogo e coloque a cenoura amassada. Misture bem e coloque as claras em neve. Coloque em um refratário untado com margarina e coloque no forno para gratinar.", null) }
            };
        }

        public static Recipes RecipeEntityFactory()
        {
            return new Recipes(1, "Suflê de Cenoura", "4 cenouras cozidas e amassadas, 1 colher de margarina, 1 cebola ralada, 1 pitada de sal, 1 copo de leite, 2 colheres de farinha de trigo, 100 g de queijo picado, 3 gemas e claras separadas", "Cozinhe as cenouras e amasse e reserve. Em uma panela coloque a manteiga, a cebola ralada e deixe fritar. Coloque a farinha dissolvida no leite com as 3 gemas. Coloque na panela e o queijo picado. Deixe engrossar, desligue o fogo e coloque a cenoura amassada. Misture bem e coloque as claras em neve. Coloque em um refratário untado com margarina e coloque no forno para gratinar.", null);
        }
        public static PaginationFilterRequest PaginationFilterRequestFactory()
        {
            return new PaginationFilterRequest()
            {
                PageIndex = 0,
                PageSize = 10
            };
        }
        public PaginationFilterResult<RecipeDTO> RecipesDTOFactory()
        {
            return new PaginationFilterResult<RecipeDTO>
            {
                TotalItems = 2,
                Data = new List<RecipeDTO>
               {
                    new RecipeDTO
                {
                    Id = 1,
                    Name = "Suflê de Cenoura",
                    Ingredients = "4 cenouras cozidas e amassadas, 1 colher de margarina, 1 cebola ralada, 1 pitada de sal, 1 copo de leite, 2 colheres de farinha de trigo, 100 g de queijo picado, 3 gemas e claras separadas",
                    PreparationMode = "Cozinhe as cenouras e amasse e reserve. Em uma panela coloque a manteiga, a cebola ralada e deixe fritar. Coloque a farinha dissolvida no leite com as 3 gemas. Coloque na panela e o queijo picado. Deixe engrossar, desligue o fogo e coloque a cenoura amassada. Misture bem e coloque as claras em neve. Coloque em um refratário untado com margarina e coloque no forno para gratinar.",
                    Image = null,
                    Category = null,
                    CategoryId = 1,
                },
                new RecipeDTO
                {
                    Id = 2,
                    Name = "Panqueca de Banana Fit",
                    Ingredients = "1 banana, 2 colheres de aveia, 1 colher de cacau em pó 100%, 2 ovos",
                    PreparationMode = "Amasse a banana, depois coloque em um recipiente fundo, bata com o garfo os 2 ovos junto com a banana, depois acrescente a aveia e o cacau. Bata tudo com o garfo e depois coloque na frigideira untada e antiaderente, tampe a frigideira e vire após dourar. Minha dica é fazer panquecas pequenas, fica mais fácil de virar. E quando tiver pronta, você pode polvilhar coco ralado sobre as panquecas.",
                    Image = null,
                    Category = null,
                    CategoryId = 11,
                }
               }
            };
        }
    }
}
