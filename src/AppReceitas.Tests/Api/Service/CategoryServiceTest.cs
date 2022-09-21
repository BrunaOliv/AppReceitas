using AppReceitas.Application.DTOs;
using AppReceitas.Application.Services;
using AppReceitas.Domain.Entities;
using AppReceitas.Domain.Interfaces;
using AutoMapper;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AppReceitas.Tests.Api.Service
{
    public class CategoryServiceTest
    {
        private readonly Mock<ICategoryRepository> _categoryRepository = new Mock<ICategoryRepository>();
        private readonly Mock<IMapper> _mapper = new Mock<IMapper>();

        [Fact]
        public async Task GetCategories_GetAllCategories_ShoulReturnValidList()
        {
            var categoryDTO = CategoriesDTOFactory();
            var categoryEntity = CategoryListEntityFactory();
            _mapper.Setup(x => x.Map<IEnumerable<CategoryDTO>>(categoryEntity)).Returns(categoryDTO);
            _categoryRepository.Setup(x => x.GetCategories()).Returns(Task.FromResult(categoryEntity));

            var service = new CategoryService(_categoryRepository.Object, _mapper.Object);
            var result = await service.GetCategories();

            Assert.IsType<List<CategoryDTO>>(result);
            _mapper.Verify(x => x.Map<IEnumerable<CategoryDTO>>(categoryEntity), Times.Once);
            _categoryRepository.Verify(x => x.GetCategories(), Times.Once);
        }


        [Fact]
        public async Task GetById_GetCategorieswithValidId_ShoulReturnValidCategory()
        {
            var id = 1;
            var categoryDTO = CategoryDTOFactory();
            var categoryEntity = CategoryEntityFactory();
            _mapper.Setup(x => x.Map<CategoryDTO>(categoryEntity)).Returns(categoryDTO);
            _categoryRepository.Setup(x => x.GetById(id)).Returns(Task.FromResult(categoryEntity));

            var service = new CategoryService(_categoryRepository.Object, _mapper.Object);
            var result = await service.GetById(id);

            Assert.IsType<CategoryDTO>(result);
            _mapper.Verify(x => x.Map<CategoryDTO>(categoryEntity), Times.Once);
            _categoryRepository.Verify(x => x.GetById(id), Times.Once);
        }

        [Fact]
        public async Task Update_UpdateCategory_NoReturn()
        {
            var categoryDTO = CategoryDTOFactory();
            var categoryEntity = CategoryEntityFactory();
            _mapper.Setup(x => x.Map<Category>(categoryDTO)).Returns(categoryEntity);
            _categoryRepository.Setup(x => x.Update(categoryEntity));

            var service = new CategoryService(_categoryRepository.Object, _mapper.Object);
            await service.Update(categoryDTO);

            _mapper.Verify(x => x.Map<Category>(categoryDTO), Times.Once);
            _categoryRepository.Verify(x => x.Update(categoryEntity), Times.Once);
        }

        [Fact]
        public async Task Remove_RemoveCategory_NoReturn()
        {
            var id = 1;
            var categoryEntity = CategoryEntityFactory();
            _categoryRepository.Setup(x => x.GetById(id)).Returns(Task.FromResult(categoryEntity));
            _categoryRepository.Setup(x => x.Remove(categoryEntity)).Returns(Task.FromResult(categoryEntity));

            var service = new CategoryService(_categoryRepository.Object, _mapper.Object);
            await service.Remove(id);

            _categoryRepository.Verify(x => x.Remove(categoryEntity), Times.Once);
            _categoryRepository.Verify(x => x.GetById(id), Times.Once);
        }

        [Fact]
        public async Task Add_AddCategory_NoReturn()
        {
            var categoryDTO = CategoryDTOFactory();
            var categoryEntity = CategoryEntityFactory();
            _mapper.Setup(x => x.Map<Category>(categoryDTO)).Returns(categoryEntity);
            _categoryRepository.Setup(x => x.Create(categoryEntity));

            var service = new CategoryService(_categoryRepository.Object, _mapper.Object);
            await service.Add(categoryDTO);

            _mapper.Verify(x => x.Map<Category>(categoryDTO), Times.Once);
            _categoryRepository.Verify(x => x.Create(categoryEntity), Times.Once);
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
        public Category CategoryEntityFactory()
        {
            return new Category(1, "Salada");
        }

        public IEnumerable<Category> CategoryListEntityFactory()
        {
            return new List<Category>
            {
                new Category(1, "Salada"),
                new Category(2, "Massas")

            };
        }
    }
}
