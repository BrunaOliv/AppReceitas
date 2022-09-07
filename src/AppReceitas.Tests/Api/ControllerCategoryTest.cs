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
    public class ControllerCategoryTest
    {
        private readonly Mock<ICategoryService> _categoryService = new Mock<ICategoryService>();

        [Fact]
        public async Task Get_withValidList_shouldReturnOk()
        {
            _categoryService.Setup(x => x.GetCategories()).Returns(Task.FromResult(CategoriesDTOFactory()));
            var controller = CategoryControllerFactory();
            var result = await controller.Get() as OkObjectResult;

            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async Task Get_withEmptyList_ShouldReturnNotFound()
        {
            var controller = CategoryControllerFactory();
            var result = await controller.Get() as NotFoundResult;

            Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
        }

        [Fact]
        public async Task GetById_withValidId_shouldReturnOk()
        {
            var id = 1;
            _categoryService.Setup(x => x.GetById(id)).Returns(Task.FromResult(CategoryDTOFactory()));
            var controller = CategoryControllerFactory();
            var result = await controller.GetById(id) as OkObjectResult;

            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async Task GetById_withInvalidId_shouldReturnNotFound()
        {
            var id = 1;
            var controller = CategoryControllerFactory();
            var result = await controller.GetById(id) as NotFoundResult;

            Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
        }

        [Fact]
        public async Task Post_withValidObject_ShouldReturnOk()
        {
            var category = CategoryDTOFactory();
            var controller = CategoryControllerFactory();
            var result = await controller.Post(category) as CreatedAtRouteResult;
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Post_withNullObject_ShouldReturnBadRequest()
        {
            var controller = CategoryControllerFactory();
            var result = await controller.Post(null) as BadRequestResult;
            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public async Task Put_withValidObjectAndId_shouldReturnOk()
        {
            var category = CategoryDTOFactory();
            var id = 1;
            var controller = CategoryControllerFactory();
            var result = await controller.Update(id, category) as OkObjectResult;
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Put_withNullObject_ShoulReturnNotFound()
        {
            var id = 1;
            var controller = CategoryControllerFactory();
            var result = await controller.Update(id, null) as NotFoundResult;
            Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
        }
        [Fact]
        public async Task Put_WithIncorrectId_ShouldReturnNotFound()
        {
            var id = 2;
            var category = CategoryDTOFactory();
            var controller = CategoryControllerFactory();
            var result = await controller.Update(id, category) as NotFoundResult;
            Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
        }

        [Fact]
        public async Task Delete_withValidId_ShouldReturnOk()
        {
            var id = 1;
            _categoryService.Setup(x => x.GetById(id)).Returns(Task.FromResult(CategoryDTOFactory()));
            var controller = CategoryControllerFactory();
            var result = await controller.DeleteById(id) as OkObjectResult;
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Delete_withInvalidId_ShouldReturnNotFound()
        {
            var id = 2;
            var controller = CategoryControllerFactory();
            var result = await controller.DeleteById(id) as NotFoundResult;
            Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
        }

        public IEnumerable<CategoryDTO> CategoriesDTOFactory()
        {
            return new List<CategoryDTO> {
                new CategoryDTO()
                {
                    Id = 1,
                    Name ="Saladas"
                },
                new CategoryDTO()
                {
                    Id=2,
                    Name ="Sobremesas"
                },
                new CategoryDTO(){
                    Id=3,
                    Name = "Lanches"
                }
            };
        }
        public CategoryDTO CategoryDTOFactory()
        {
            return new CategoryDTO()
            {
                Id = 1,
                Name = "Salada"
            };
        }
        public CategoryController CategoryControllerFactory()
        {
            return new CategoryController(_categoryService.Object);

        }
    }
}
