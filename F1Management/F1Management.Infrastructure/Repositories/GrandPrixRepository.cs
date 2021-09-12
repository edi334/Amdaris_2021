using F1Management.Core;
using F1Management.Core.Models.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Infrastructure.Repositories
{
    public class GrandPrixRepository : IGrandPrixRepository
    {
        private readonly AppDbContext _dbContext;

        public GrandPrixRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<GrandPrix>> GetAllAsync()
        {
            return await _dbContext.GrandPrix.ToListAsync();
        }

        public async Task<GrandPrix> GetByIdAsync(Guid id)
        {
            return await _dbContext.GrandPrix.FirstOrDefaultAsync(g => g.Id == id);
        }
    }
}
