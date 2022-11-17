using AppReceitas.Application.DTOs;
using AppReceitas.Application.Interfaces;
using AppReceitas.Domain.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppReceitas.Application.Services
{
    public class LevelService : ILevelService
    {
        private ILevelRepository _levelRepository;
        private readonly IMapper _mapper;

        public LevelService(ILevelRepository levelRepository, IMapper mapper)
        {
            _levelRepository = levelRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<LevelDTO>> GetLevels()
        {
            var levelEntity = await _levelRepository.GetLevels();
            return _mapper.Map<IEnumerable<LevelDTO>>(levelEntity);
        }
    }
}
