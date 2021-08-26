using F1Management.Core;
using F1Management.Core.Models.Abstractions.Repositories;
using F1Management.Core.Models.Car;
using F1Management.Core.Models.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Infrastructure.Repositories
{
    public class RaceCarRepository : IRaceCarRepository
    {
        private readonly AppDbContext _dbContext;

        public RaceCarRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(RaceCar raceCar)
        {
            _dbContext.RaceCars.Add(raceCar);
            _dbContext.SaveChanges();
        }

        public void Delete(RaceCar raceCar)
        {
            _dbContext.RaceCars.Remove(raceCar);
            _dbContext.SaveChanges();
        }

        public List<RaceCar> GetAll()
        {
            return _dbContext.RaceCars.ToList();
        }

        public RaceCar GetByDriver(Driver driver)
        {
            return _dbContext.RaceCars.FirstOrDefault(r => r.Driver == driver);
        }

        public RaceCar GetById(Guid id)
        {
            return _dbContext.RaceCars.FirstOrDefault(r => r.Id == id);
        }

        public List<RaceCar> GetByTeam(Team team)
        {
            return _dbContext.RaceCars
                .Where(r => r.Driver.TeamMember.Team == team)
                .ToList();
        }
    }
}
