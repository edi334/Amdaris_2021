using F1Management.Core.Models.Car;
using F1Management.Core.Models.TeamMembers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Abstractions.Repositories
{
    public interface ITeamRepository
    {
        public Task UpdateTeamAsync(Team team);
        public Task UpdateDriverAsync(Driver driver);
        public Task UpdateCarMechanicAsync(CarMechanic carMechanic);
        public Task UpdateRaceEngineerAsync(RaceEngineer raceEngineer);
        public Task UpdatePitStopCrew(PitStopCrew pitStopCrew);
        public Task<CarMechanic> GetFirstAvailableCarMechanicAsync(Guid teamId);
        public Task<RaceEngineer> GetRaceEngineerAsync(RaceCar raceCar);
        public Task<PitStopCrew> GetPitStopCrew(Guid teamId);
    }
}
