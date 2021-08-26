using F1Management.Core;
using F1Management.Core.Models.Abstractions.Repositories;
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

        public void Add(Team team)
        {
            _dbContext.Teams.Add(team);
            _dbContext.SaveChanges();
        }

        public void Delete(Team team)
        {
            _dbContext.Teams.Remove(team);
            _dbContext.SaveChanges();
        }

        public List<Team> GetAll()
        {
            return _dbContext.Teams.ToList();
        }

        public Team GetById(Guid id)
        {
            return _dbContext.Teams.FirstOrDefault(t => t.Id == id);
        }
    }
}
