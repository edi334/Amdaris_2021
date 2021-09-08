using F1Management.Core.Models.Abstractions.Repositories;
using F1Management.Core.Models.Car;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Infrastructure.Repositories
{
    public class RaceCarRepository : IRaceCarRepository
    {
        private readonly AppDbContext _dbContext;
        public RaceCarRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<RaceCar> GetRaceCarAsync(Guid id)
        {
            return await _dbContext.RaceCars
                .FirstOrDefaultAsync(r => r.Id == id);
        }
        public async Task UpdateRaceCarAsync(RaceCar raceCar)
        {
            _dbContext.RaceCars.Update(raceCar);
            await _dbContext.SaveChangesAsync();
        }
    }
}
