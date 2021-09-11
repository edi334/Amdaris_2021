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

        public async Task<CarMechanic> GetFirstCarMechanicAsync()
        {
            return await _dbContext.CarMechanics.FirstOrDefaultAsync();
        }

        public async Task<RaceEngineer> GetRaceEngineerAsync(RaceCar raceCar)
        {
            return await _dbContext.RaceEngineers.FirstOrDefaultAsync(r => r.Driver == raceCar.Driver);
        }

        public async Task UpdateDriverAsync(Driver driver)
        {
            _dbContext.Drivers.Update(driver);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateTeamAsync(Team team)
        {
            _dbContext.Teams.Update(team);
            await _dbContext.SaveChangesAsync();
        }
    }
}
