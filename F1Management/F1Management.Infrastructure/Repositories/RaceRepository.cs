using F1Management.Core;
using F1Management.Core.Models.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Infrastructure.Repositories
{
    public class RaceRepository : IGenericRepository<GrandPrix>
    {
        private readonly AppDbContext _dbContext;

        public RaceRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(GrandPrix race)
        {
            _dbContext.Races.Add(race);
            _dbContext.SaveChanges();
        }

        public void Delete(GrandPrix race)
        {
            _dbContext.Races.Remove(race);
            _dbContext.SaveChanges();
        }

        public List<GrandPrix> GetAll()
        {
            return _dbContext.Races.ToList();
        }

        public GrandPrix GetById(Guid id)
        {
            return _dbContext.Races.FirstOrDefault(r => r.Id == id);
        }

        public void Update(GrandPrix race)
        {
            _dbContext.Races.Update(race);
            _dbContext.SaveChanges();
        }
    }
}
