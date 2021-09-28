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
        public Task<ICollection<Team>> GetAllAsync();
        public Task<Team> GetByIdAsync(Guid teamId);
        public Task UpdateTeamAsync(Team team);
        public Task UpdateDriverAsync(Driver driver);
        public Task UpdateCarMechanicAsync(CarMechanic carMechanic);
        public Task UpdateRaceEngineerAsync(RaceEngineer raceEngineer);
        public Task UpdatePitStopCrewAsync(PitStopCrew pitStopCrew);
        public Task<CarMechanic> GetFirstAvailableCarMechanicAsync(Guid teamId);
        public Task<RaceEngineer> GetRaceEngineerAsync(RaceCar raceCar);
        public Task<ICollection<Driver>> GetDriversAsync(Guid teamId);
        public Task<ICollection<Driver>> GetAllDriversAsync();
        public Task<ICollection<RaceEngineer>> GetRaceEngineersAsync(Guid teamId);
        public Task<ICollection<CarMechanic>> GetCarMechanicsAsync(Guid teamId);
        public Task<PitStopCrew> GetPitStopCrewAsync(Guid teamId);
        public Task<ICollection<PitStopMechanic>> GetPitStopMechanicsAsync(Guid teamId);
        public Task AddCarMechanicAsync(CarMechanic carMechanic);
        public Task AddDriverAsync(Driver driver);
        public Task AddPitStopMechanicAsync(PitStopMechanic pitStopMechanic);
        public Task AddRaceEngineerAsync(RaceEngineer raceEngineer);
        public Task AddPitStopCrewAsync(PitStopCrew pitStopCrew);

    }
}
