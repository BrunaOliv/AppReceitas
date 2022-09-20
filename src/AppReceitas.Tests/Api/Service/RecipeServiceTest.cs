using AppReceitas.Application.DTOs;
using AppReceitas.Application.Services;
using AppReceitas.Domain.Entities;
using AppReceitas.Domain.Interfaces;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AppReceitas.Tests.Api.Service
{
    public class RecipeServiceTest
    {
        private readonly Mock<IRecipesRepository> _recipesRepository = new Mock<IRecipesRepository>();
        private readonly Mock<IMapper> _mapper = new Mock<IMapper>();

        [Fact]
        public async Task Add_withRequest()
        {
            var recipe = RecipeDTOFactory();

            var recipeEntity = RecipeEntityFactory();

            _mapper
                .Setup(x => x.Map<Recipes>(recipe))
                .Returns(recipeEntity);

            _recipesRepository
                .Setup(x => x.CreateAsync(recipeEntity));

            var service = new RecipeService(_recipesRepository.Object, _mapper.Object);
            await service.Add(recipe);

            _mapper.Verify(x => x.Map<Recipes>(recipe), Times.Once);
            _recipesRepository.Verify(x => x.CreateAsync(recipeEntity), Times.Once);

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
        public static Recipes RecipeEntityFactory()
        {
            return new Recipes(1, "Suflê de Cenoura", "4 cenouras cozidas e amassadas, 1 colher de margarina, 1 cebola ralada, 1 pitada de sal, 1 copo de leite, 2 colheres de farinha de trigo, 100 g de queijo picado, 3 gemas e claras separadas", "Cozinhe as cenouras e amasse e reserve. Em uma panela coloque a manteiga, a cebola ralada e deixe fritar. Coloque a farinha dissolvida no leite com as 3 gemas. Coloque na panela e o queijo picado. Deixe engrossar, desligue o fogo e coloque a cenoura amassada. Misture bem e coloque as claras em neve. Coloque em um refratário untado com margarina e coloque no forno para gratinar.", null);
    }
    }
}
