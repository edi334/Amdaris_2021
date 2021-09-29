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

        public async Task AddCarMechanicAsync(CarMechanic carMechanic)
        {
            if (carMechanic == null)
            {
                throw new Exception("Car Mechanic is null");
            }

            await _dbContext.CarMechanics.AddAsync(carMechanic);
        }

        public async Task AddDriverAsync(Driver driver)
        {
            if (driver == null)
            {
                throw new Exception("Driver is null");
            }

            await _dbContext.Drivers.AddAsync(driver);
        }

        public async Task AddPitStopCrewAsync(PitStopCrew pitStopCrew)
        {
            if (pitStopCrew == null)
            {
                throw new Exception("PitStop Crew is null");
            }

            await _dbContext.PitStopCrews.AddAsync(pitStopCrew);
        }

        public async Task AddPitStopMechanicAsync(PitStopMechanic pitStopMechanic)
        {
            if (pitStopMechanic == null)
            {
                throw new Exception("PitStop Mechanic is null");
            }

            await _dbContext.PitStopMechanics.AddAsync(pitStopMechanic);
        }

        public async Task AddRaceEngineerAsync(RaceEngineer raceEngineer)
        {
            if (raceEngineer == null)
            {
                throw new Exception("Race Engineer is null");
            }

            await _dbContext.RaceEngineers.AddAsync(raceEngineer);
        }

        public async Task AddTeamAsync(Team team)
        {
            if (team == null)
            {
                throw new Exception("Team is null");
            }

            await _dbContext.Teams.AddAsync(team);
        }

        public async Task<ICollection<Team>> GetAllAsync()
        {
            return await _dbContext.Teams
                .OrderBy(t => t.Points)
                .ToListAsync();
        }

        public async Task<ICollection<Driver>> GetAllDriversAsync()
        {
            return await _dbContext.Drivers
                .OrderBy(d => d.Points)
                .Include(d => d.User)
                .ToListAsync();
        }

        public async Task<Team> GetByIdAsync(Guid teamId)
        {
            return await _dbContext.Teams.FirstOrDefaultAsync(t => t.Id == teamId);
        }

        public async Task<ICollection<CarMechanic>> GetCarMechanicsAsync(Guid teamId)
        {
            return await _dbContext.CarMechanics
                .Where(c => c.TeamId == teamId)
                .Include(c => c.User)
                .ToListAsync();
        }

        public async Task<ICollection<Driver>> GetDriversAsync(Guid teamId)
        {
            return await _dbContext.Drivers
                .Where(d => d.TeamId == teamId)
                .Include(d => d.User)
                .ToListAsync();
        }

        public async Task<CarMechanic> GetFirstAvailableCarMechanicAsync(Guid teamId)
        {
            return await _dbContext.CarMechanics
                .FirstOrDefaultAsync(c => c.isAvailable == true && c.TeamId == teamId);
        }

        public async Task<PitStopCrew> GetPitStopCrewAsync(Guid teamId)
        {
            return await _dbContext.PitStopCrews
                .FirstOrDefaultAsync(c => c.TeamId == teamId);
        }

        public async Task<ICollection<PitStopMechanic>> GetPitStopMechanicsAsync(Guid teamId)
        {
            return await _dbContext.PitStopMechanics
                 .Where(p => p.PitStopCrew.TeamId == teamId)
                 .Include(p => p.User)
                 .ToListAsync();
        }

        public async Task<RaceEngineer> GetRaceEngineerAsync(RaceCar raceCar)
        {
            return await _dbContext.RaceEngineers.FirstOrDefaultAsync(r => r.Driver == raceCar.Driver);
        }

        public async Task<ICollection<RaceEngineer>> GetRaceEngineersAsync(Guid teamId)
        {
            return await _dbContext.RaceEngineers
                .Where(r => r.TeamId == teamId)
                .Include(r => r.User)
                .ToListAsync();
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

        public async Task UpdatePitStopCrewAsync(PitStopCrew pitStopCrew)
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
