using AppReceitas.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppReceitas.Application.Interfaces
{
    public interface ILevelService
    {
        Task<IEnumerable<LevelDTO>> GetLevels();
    }
}
