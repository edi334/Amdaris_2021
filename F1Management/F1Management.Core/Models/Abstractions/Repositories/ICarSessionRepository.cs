using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Abstractions.Repositories
{
    public interface ICarSessionRepository
    {
        public Task<CarSession> GetByIdAsync(Guid id);
        public Task<List<CarSession>> GetByGrandPrixAndRaceCarAsync(Guid grandPrixId, Guid raceCarId);
        public Task AddPitStopAsync(PitStop pitStop);
        public Task UpdateSessionAsync(CarSession carSession);
        public Task<TimeSpan> GetFastestLapFromAllCarsInSessionAsync(CarSession carSession);
    }
}
