using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Domain.Intefaces
{
    public interface ISubCategoryRepository
    {
        Task<IEnumerable<SubCategory>> GetSubCategories();
        Task<SubCategory> GetById(int? id);
        Task<SubCategory> Create(SubCategory subCategory);
        Task<SubCategory> Update(SubCategory subCategory);
        Task<SubCategory> Remove(SubCategory subCategory);
    }
}
