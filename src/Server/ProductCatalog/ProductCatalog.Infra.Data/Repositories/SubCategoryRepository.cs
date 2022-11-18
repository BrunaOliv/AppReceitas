using Microsoft.EntityFrameworkCore;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Domain.Intefaces;
using ProductCatalog.Infra.Data.Context;

namespace ProductCatalog.Infra.Data.Repositories
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public SubCategoryRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
        }

        public async Task<SubCategory> Create(SubCategory subCategory)
        {
            _applicationDbContext.Add(subCategory);
            await _applicationDbContext.SaveChangesAsync();
            return subCategory;
        }

        public async Task<SubCategory> GetById(int? id)
        {
            return await _applicationDbContext.ProductsSubCategories.FindAsync(id);
        }

        public async Task<IEnumerable<SubCategory>> GetSubCategories()
        {
            return await _applicationDbContext.ProductsSubCategories.ToListAsync();
        }

        public async Task<SubCategory> Remove(SubCategory subCategory)
        {
            _applicationDbContext.Remove(subCategory);
            await _applicationDbContext.SaveChangesAsync();
            return subCategory;
        }

        public async Task<SubCategory> Update(SubCategory subCategory)
        {
            _applicationDbContext.Update(subCategory);
            await _applicationDbContext.SaveChangesAsync();
            return subCategory;
        }
    }
}
