using F1Management.Core.Models.Abstractions.Repositories;
using F1Management.Core.Models.Abstractions.Repositories.PartRepositories;
using F1Management.Core.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Infrastructure.Repositories
{
    public class EngineRepository : IGenericRepository<Engine>, IPartRepository<Engine>
    {
        private readonly AppDbContext _dbContext;

        public EngineRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Engine engine)
        {
            _dbContext.Engines.Add(engine);
            _dbContext.SaveChanges();
        }

        public void Delete(Engine engine)
        {
            _dbContext.Engines.Remove(engine);
            _dbContext.SaveChanges();
        }

        public List<Engine> GetAll()
        {
            return _dbContext.Engines.ToList();
        }

        public List<Engine> GetByCar(RaceCar raceCar)
        {
            return _dbContext.Engines
                .Where(e => e.RaceCar == raceCar)
                .ToList();
        }

        public Engine GetById(Guid id)
        {
            return _dbContext.Engines.FirstOrDefault(e => e.Id == id);
        }

        public void Update(Engine engine)
        {
            _dbContext.Engines.Update(engine);
            _dbContext.SaveChanges();
        }
    }
}
