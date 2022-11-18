using ProductCatalog.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Application.Interfaces
{
    public interface ISubCategoryService
    {
        Task<IEnumerable<SubCategoryDTO>> GetSubCategories();
        Task<SubCategoryDTO> GetById(int? id);
        Task Add(SubCategoryDTO subCategoryDTO);
        Task Update(SubCategoryDTO subCategoryDTO);
        Task Remove(int? id);
    }
}
