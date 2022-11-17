using AppReceitas.Application.DTOs;

namespace AppReceitas.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<CategoryDTO> GetById(int? id);
        Task Update(CategoryDTO categoryDTO);
        Task Remove(int? id);
        Task Add(CategoryDTO categoryDTO);
    }
}
