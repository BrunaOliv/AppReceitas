using ProductCatalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Domain.Intefaces
{
    public interface ISubCategoryRepository
    {
        Task<IEnumerable<SubCategory>> GetCategories();
        Task<SubCategory> GetById(int? id);
        Task<SubCategory> Create(SubCategory subCategory);
        Task<SubCategory> Update(SubCategory subCategory);
        Task<SubCategory> Remove(SubCategory subCategory);
    }
}
