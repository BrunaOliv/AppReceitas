using AppReceitas.Api.Controllers;
using AppReceitas.Application.DTOs;
using AppReceitas.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace AppReceitas.Tests.Api
{
    public class RecipeControllerTest
    {
        private readonly Mock<IRecipeService> _recipeService = new Mock<IRecipeService>();
        private readonly Mock<IBlobService> _blobService = new Mock<IBlobService>();
        private readonly Mock<IImageService> _imageService = new Mock<IImageService>();

        [Fact]
        public async Task Get_withValidList_shouldReturnOk()
        {
            var paginationRequest = PaginationFilterRequestFactory();
            _recipeService.Setup(x => x.GetRecipes(paginationRequest)).Returns(Task.FromResult(RecipesDTOFactory()));
            var controller = new RecipeController(_recipeService.Object, _blobService.Object, _imageService.Object);
            var result = await controller.Get(paginationRequest) as OkObjectResult;

            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            Assert.IsType<PaginationFilterResult<RecipeDTO>>(result.Value);

            _recipeService.Verify(x => x.GetRecipes(paginationRequest), Times.Once);
        }

        [Fact]
        public async Task Get_withEmptyList_ShouldReturnNotFound()
        {
            var paginationRequest = PaginationFilterRequestFactory();
            var controller = new RecipeController(_recipeService.Object, _blobService.Object, _imageService.Object);
            var result = await controller.Get(paginationRequest) as NotFoundObjectResult;

            Assert.Equal("Recipe Not Found", result.Value);
            Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
            Assert.IsType<NotFoundObjectResult>(result);

            _recipeService.Verify(x => x.GetRecipes(paginationRequest), Times.Once);
        }

        [Fact]
        public async Task GetById_withValidId_ShouldReturnOk()
        {
            var id = 1;
            _recipeService.Setup(x => x.GetById(id)).Returns(Task.FromResult(RecipeDTOFactory()));
            var controller = new RecipeController(_recipeService.Object, _blobService.Object, _imageService.Object);
            var result = await controller.GetById(id) as OkObjectResult;

            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            Assert.IsType<RecipeDTO>(result.Value);

            _recipeService.Verify(x => x.GetById(id), Times.Once);
        }

        [Fact]
        public async Task GetById_withInvalidId_ShouldReturnNotound()
        {
            var id = 2;
            var controller = new RecipeController(_recipeService.Object, _blobService.Object, _imageService.Object);
            var result = await controller.GetById(id) as NotFoundObjectResult;

            Assert.Equal("Recipe Not Found", result.Value);
            Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
            Assert.IsType<NotFoundObjectResult>(result);

            _recipeService.Verify(x => x.GetById(id), Times.Once);
        }

        [Fact]
        public async Task Post_withValidObject_SouldReturnOk()
        {
            var recipe = RecipeDTOFactory();
            var controller = new RecipeController(_recipeService.Object, _blobService.Object, _imageService.Object);
            var result = await controller.Post(recipe) as CreatedAtRouteResult;

            Assert.NotNull(result);
            Assert.IsType<RecipeDTO>(result.Value);

            _recipeService.Verify(x => x.Add(recipe), Times.Once);
        }

        [Fact]
        public async Task Post_withInvalidObject_ShouldReturnBadRequest()
        {
            RecipeDTO recipe = null;
            var controller = new RecipeController(_recipeService.Object, _blobService.Object, _imageService.Object);
            var result = await controller.Post(recipe) as BadRequestObjectResult;

            Assert.Equal("Recipe invalid", result.Value);
            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
            Assert.IsType<BadRequestObjectResult>(result);

            _recipeService.Verify(x => x.Add(recipe), Times.Never);
        }

        [Fact]
        public async Task Put_WithValidIdAndObject_ShouldReturnOk()
        {
            var id = 1;
            var recipe = RecipeDTOFactory();
            var controller = new RecipeController(_recipeService.Object, _blobService.Object, _imageService.Object);
            var result = await controller.Put(id, recipe) as OkObjectResult;

            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            Assert.IsType<RecipeDTO>(result.Value);

            _recipeService.Verify(x => x.Update(recipe), Times.Once);
        }
        [Fact]
        public async Task Put_withNullObject_ShouldReturnNotFound()
        {
            RecipeDTO recipe = null;
            var id = 1;
            var controller = new RecipeController(_recipeService.Object, _blobService.Object, _imageService.Object);
            var result = await controller.Put(id, recipe) as NotFoundObjectResult;

            Assert.Equal("Recipe Not Found", result.Value);
            Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
            Assert.IsType<NotFoundObjectResult>(result);

            _recipeService.Verify(x => x.Update(recipe), Times.Never);
        }

        [Fact]
        public async Task Put_WithIncorrectId_ShouldReturnNotFound()
        {
            var recipe = RecipeDTOFactory();
            var id = 2;
            var controller = new RecipeController(_recipeService.Object, _blobService.Object, _imageService.Object);
            var result = await controller.Put(id, recipe) as NotFoundObjectResult;

            Assert.Equal("Recipe Not Found", result.Value);
            Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
            Assert.IsType<NotFoundObjectResult>(result);

            _recipeService.Verify(x => x.Update(recipe), Times.Never);
        }

        [Fact]
        public async Task Delete_WithValidId_ShouldRetunrOk()
        {
            var id = 1;
            _recipeService.Setup(x => x.GetById(id)).Returns(Task.FromResult(RecipeDTOFactory()));
            var controller = new RecipeController(_recipeService.Object, _blobService.Object, _imageService.Object);
            var result = await controller.Delete(id) as OkObjectResult;

            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            Assert.IsType<RecipeDTO>(result.Value);

            _recipeService.Verify(x => x.Remove(id), Times.Once);
            _recipeService.Verify(x => x.GetById(id), Times.Once);
        }
        [Fact]
        public async Task Delete_withInvalidId_ShouldReturnNotFound()
        {
            var id = 2;
            var controller = new RecipeController(_recipeService.Object, _blobService.Object, _imageService.Object);
            var result = await controller.Delete(id) as NotFoundObjectResult;

            Assert.Equal("Recipe Not Found", result.Value);
            Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
            Assert.IsType<NotFoundObjectResult>(result);

            _recipeService.Verify(x => x.Remove(id), Times.Never);
            _recipeService.Verify(x => x.GetById(id), Times.Once);
        }

        public PaginationFilterResult<RecipeDTO> RecipesDTOFactory()
        {
            return new PaginationFilterResult<RecipeDTO> {
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
        public static PaginationFilterRequest PaginationFilterRequestFactory()
        {
            return new PaginationFilterRequest()
            {
                PageIndex = 0,
                PageSize = 10
            };
        }
    }
}
