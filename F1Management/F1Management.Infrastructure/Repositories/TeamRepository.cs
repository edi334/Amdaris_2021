using F1Management.Core;
using F1Management.Core.Models.Abstractions.Repositories;
using F1Management.Core.Models.TeamMembers;
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

        public void UpdateDriver(Driver driver)
        {
            _dbContext.Drivers.Update(driver);
            _dbContext.SaveChanges();
        }

        public void UpdateTeam(Team team)
        {
            _dbContext.Teams.Update(team);
            _dbContext.SaveChanges();
        }
    }
}
