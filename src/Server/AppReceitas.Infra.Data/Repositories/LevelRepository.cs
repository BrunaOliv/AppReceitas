using AppReceitas.Domain.Entities;
using AppReceitas.Domain.Interfaces;
using AppReceitas.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppReceitas.Infra.Data.Repositories
{
    public class LevelRepository : ILevelRepository
    {
        ApplicationDbContext _levelContext;
        public LevelRepository(ApplicationDbContext context)
        {
            _levelContext = context;
        }
        public async Task<IEnumerable<Level>> GetLevels()
        {
            return await _levelContext.Level.ToListAsync();
        }
    }
}
