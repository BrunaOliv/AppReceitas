using AppReceitas.Application.DTOs;
using AppReceitas.Application.Interfaces;
using AppReceitas.Domain.Entities;
using AppReceitas.Domain.Filters;
using AppReceitas.Domain.Interfaces;
using AutoMapper;

namespace AppReceitas.Application.Services
{
    public class EvaluationService : IEvaluationService
    {
        private readonly IEvaluationRepository _evaluationRepository;
        private readonly IMapper _mapper;

        public EvaluationService(IEvaluationRepository evaluationRepository, IMapper mapper)
        {
            _evaluationRepository = evaluationRepository;
            _mapper = mapper;
        }
        public async Task Add(EvaluationDTO evaluationDTO)
        {
            var evaluationEntity = _mapper.Map<Evaluation>(evaluationDTO);
            await _evaluationRepository.Create(evaluationEntity);
        }

        public async Task<EvaluationDTO> GetById(int? id)
        {
            var evaluationEntity = await _evaluationRepository.GetById(id);
            return _mapper.Map<EvaluationDTO>(evaluationEntity);
        }

        public async Task<IEnumerable<EvaluationDTO>> GetEvaluation()
        {
            var evaluationEntity = await _evaluationRepository.GetEvaluations();
            return _mapper.Map<IEnumerable<EvaluationDTO>>(evaluationEntity);
        }

        public async Task<PaginationFilterEvaluationResult<EvaluationDTO>> GetEvaluationByIdRecipe(PaginationFilterEvaluationRequest? paginationFilterEvaluationRequest)
        {
            var paginationFilter = _mapper.Map<PaginationEvaluationFilter<Evaluation>>(paginationFilterEvaluationRequest);
            var evaluationEntity = await _evaluationRepository.GeyByIdRecipe(paginationFilter);
            return _mapper.Map<PaginationFilterEvaluationResult<EvaluationDTO>>(evaluationEntity);
        }

        public async Task Remove(int? id)
        {
            var evaluationId = _evaluationRepository.GetById(id).Result;
            await _evaluationRepository.Remove(evaluationId);
        }

        public async Task Update(EvaluationDTO evaluationDTO)
        {
            var evaluationEntity = _mapper.Map<Evaluation>(evaluationDTO);
            await _evaluationRepository.Update(evaluationEntity);
        }
    }
}
