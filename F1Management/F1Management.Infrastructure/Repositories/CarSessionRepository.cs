using F1Management.Core.Models;
using F1Management.Core.Models.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Infrastructure.Repositories
{
    public class CarSessionRepository : ICarSessionRepository
    {
        private readonly AppDbContext _dbContext;
        public CarSessionRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddPitStopAsync(PitStop pitStop)
        {
            if (pitStop == null)
            {
                throw new Exception("PitStop is null");
            }

            _dbContext.PitStops.Add(pitStop);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<CarSession>> GetByGrandPrixAndRaceCarAsync(Guid grandPrixId, Guid raceCarId)
        {
            return await _dbContext.Sessions
                .Include(s => s.RaceCar)
                .Where(s => s.GrandPrixId == grandPrixId && s.RaceCarId == raceCarId)
                .ToListAsync();
        }

        public async Task<CarSession> GetByIdAsync(Guid id)
        {
            return await _dbContext.Sessions.Include(s => s.RaceCar).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<TimeSpan> GetFastestLapFromAllCarsInSessionAsync(CarSession carSession)
        {
            TimeSpan fastestLap = await  _dbContext.Sessions
                .Where(s => s.GrandPrix == carSession.GrandPrix && s.SessionType == carSession.SessionType)
                .Select(s => s.FastestLap)
                .MaxAsync();

            return fastestLap;
        }

        public async Task UpdateSessionAsync(CarSession carSession)
        {
            if (carSession == null)
            {
                throw new Exception("Car Session is null");
            }

            _dbContext.Sessions.Update(carSession);
            await _dbContext.SaveChangesAsync();
        }
    }
}
