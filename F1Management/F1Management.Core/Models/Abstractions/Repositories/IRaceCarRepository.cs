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
        public Task UpdateRaceCarAsync(RaceCar raceCar);
    }
}
