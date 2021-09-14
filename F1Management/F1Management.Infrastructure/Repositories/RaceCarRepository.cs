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

        public async Task AddChassisAsync(Chassis chassis)
        {
            if (chassis == null)
            {
                throw new Exception("Chassis is null");
            }

            _dbContext.Chassis.Add(chassis);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddEngineAsync(Engine engine)
        {
            if (engine == null)
            {
                throw new Exception("Engine is null");
            }

            _dbContext.Engines.Add(engine);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddGearboxAsync(Gearbox gearbox)
        {
            if (gearbox == null)
            {
                throw new Exception("Gearbox is null");
            }

            _dbContext.Gearboxes.Add(gearbox);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddRaceCarAsync(string name)
        {
            if (name == null)
            {
                throw new Exception("Race Car Name is null");
            }

            _dbContext.RaceCars.Add(new RaceCar { Name = name });
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddTireSetAsync(TireSet tireSet)
        {
            if (tireSet == null)
            {
                throw new Exception("TireSet is null");
            }

            _dbContext.TireSets.Add(tireSet);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<RaceCar>> GetByTeamAsync(Guid teamId)
        {
            return await _dbContext.RaceCars
                .Include(c => c.Chassis)
                .Include(c => c.Engine)
                .Include(c => c.Gearbox)
                .Include(c => c.TireSet)
                .Where(r => r.Driver.TeamId == teamId)
                .ToListAsync();
        }

        public async Task<RaceCar> GetRaceCarAsync(Guid id)
        {
            return await _dbContext.RaceCars
                .Include(c => c.Chassis)
                .Include(c => c.Engine)
                .Include(c => c.Gearbox)
                .Include(c => c.TireSet)
                .FirstOrDefaultAsync(r => r.Id == id);
        }
        public async Task UpdateRaceCarAsync(RaceCar raceCar)
        {
            if (raceCar == null)
            {
                throw new Exception("Race Car is null");
            }

            _dbContext.RaceCars.Update(raceCar);
            await _dbContext.SaveChangesAsync();
        }
    }
}
