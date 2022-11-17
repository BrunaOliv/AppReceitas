using AppReceitas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppReceitas.Domain.Interfaces
{
    public interface ILevelRepository
    {
        Task<IEnumerable<Level>> GetLevels();
    }
}
