using F1Management.Core.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Abstractions.Repositories
{
    public interface IRaceCarRepository
    {
        public Task<RaceCar> GetRaceCarAsync(Guid id);
        public Task<List<RaceCar>> GetByTeamAsync(Guid teamId);
        public Task UpdateRaceCarAsync(RaceCar raceCar);
        public Task AddRaceCarAsync(string name);
        public Task AddChassisAsync(Chassis chassis);
        public Task AddEngineAsync(Engine engine);
        public Task AddGearboxAsync(Gearbox gearbox);
        public Task AddTireSetAsync(TireSet tireSet);
    }
}
