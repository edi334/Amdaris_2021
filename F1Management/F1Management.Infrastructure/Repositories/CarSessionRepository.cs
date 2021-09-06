using F1Management.Core.Models;
using F1Management.Core.Models.Abstractions.Repositories;
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
        public void AddPitStop(PitStop pitStop)
        {
            _dbContext.PitStops.Add(pitStop);
            _dbContext.SaveChanges();
        }

        public TimeSpan GetFastestLapFromAllCarsInSession(CarSession carSession)
        {
            TimeSpan fastestLap = _dbContext.Sessions
                .Where(s => s.GrandPrix == carSession.GrandPrix && s.SessionType == carSession.SessionType)
                .Select(s => s.FastestLap)
                .Max();

            return fastestLap;
        }

        public void UpdateSession(CarSession carSession)
        {
            _dbContext.Sessions.Update(carSession);
            _dbContext.SaveChanges();
        }
    }
}
