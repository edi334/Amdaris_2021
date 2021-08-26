using F1Management.Core;
using F1Management.Core.Models.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Infrastructure.Repositories
{
    public class RaceRepository : IRaceRepository
    {
        private readonly AppDbContext _dbContext;

        public RaceRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Race race)
        {
            _dbContext.Races.Add(race);
            _dbContext.SaveChanges();
        }

        public void Delete(Race race)
        {
            _dbContext.Races.Remove(race);
            _dbContext.SaveChanges();
        }

        public List<Race> GetAll()
        {
            return _dbContext.Races.ToList();
        }

        public Race GetById(Guid id)
        {
            return _dbContext.Races.FirstOrDefault(r => r.Id == id);
        }
    }
}
