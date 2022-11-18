using AutoMapper;
using ProductCatalog.Application.DTOs;
using ProductCatalog.Application.Interfaces;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Domain.Intefaces;

namespace ProductCatalog.Application.Service
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IMapper _mapper;

        public SubCategoryService(ISubCategoryRepository subCategoryRepository, IMapper mapper)
        {
            _subCategoryRepository = subCategoryRepository ?? throw new ArgumentNullException(nameof(subCategoryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task Add(SubCategoryDTO subCategoryDTO)
        {
            var subCategoryEntity = _mapper.Map<SubCategory>(subCategoryDTO);
            await _subCategoryRepository.Create(subCategoryEntity);
        }

        public async Task<SubCategoryDTO> GetById(int? id)
        {
            var subCategoryEntity = await _subCategoryRepository.GetById(id);
            return _mapper.Map<SubCategoryDTO>(subCategoryEntity);
        }

        public async Task<IEnumerable<SubCategoryDTO>> GetCategories()
        {
            var subCategoryEntity = await _subCategoryRepository.GetSubCategories();
            return _mapper.Map<IEnumerable<SubCategoryDTO>>(subCategoryEntity);
        }

        public async Task Remove(int? id)
        {
            var subCategoryEntity = _subCategoryRepository.GetById(id).Result;
            await _subCategoryRepository.Remove(subCategoryEntity);
        }

        public async Task Update(SubCategoryDTO subCategoryDTO)
        {
            var subCategoryEntity =  _mapper.Map<SubCategory>(subCategoryDTO);
            await _subCategoryRepository.Update(subCategoryEntity);
        }
    }
}
