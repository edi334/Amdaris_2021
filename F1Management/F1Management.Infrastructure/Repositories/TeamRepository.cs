using F1Management.Core;
using F1Management.Core.Models.Abstractions.Repositories;
using F1Management.Core.Models.Car;
using F1Management.Core.Models.TeamMembers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Infrastructure.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly AppDbContext _dbContext;
        public TeamRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CarMechanic> GetFirstAvailableCarMechanicAsync(Guid teamId)
        {
            return await _dbContext.CarMechanics
                .FirstOrDefaultAsync(c => c.isAvailable == true && c.TeamId == teamId);
        }

        public async Task<PitStopCrew> GetPitStopCrew(Guid teamId)
        {
            return await _dbContext.PitStopCrews
                .FirstOrDefaultAsync(c => c.TeamId == teamId);
        }

        public async Task<RaceEngineer> GetRaceEngineerAsync(RaceCar raceCar)
        {
            return await _dbContext.RaceEngineers.FirstOrDefaultAsync(r => r.Driver == raceCar.Driver);
        }

        public async Task UpdateCarMechanicAsync(CarMechanic carMechanic)
        {
            if (carMechanic == null)
            {
                throw new Exception("Car Mechanic is null");
            }

            _dbContext.CarMechanics.Update(carMechanic);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateDriverAsync(Driver driver)
        {
            if (driver == null)
            {
                throw new Exception("Driver is null");
            }

            _dbContext.Drivers.Update(driver);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdatePitStopCrew(PitStopCrew pitStopCrew)
        {
            if (pitStopCrew == null)
            {
                throw new Exception("PitStop Crew is null");
            }

            _dbContext.PitStopCrews.Update(pitStopCrew);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRaceEngineerAsync(RaceEngineer raceEngineer)
        {
            if (raceEngineer == null)
            {
                throw new Exception("Race Engineer is null");
            }

            _dbContext.RaceEngineers.Update(raceEngineer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateTeamAsync(Team team)
        {
            if (team == null)
            {
                throw new Exception("Team is null");
            }

            _dbContext.Teams.Update(team);
            await _dbContext.SaveChangesAsync();
        }
    }
}
