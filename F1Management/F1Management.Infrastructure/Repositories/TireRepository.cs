using F1Management.Core.Models.Abstractions.Repositories.PartRepositories;
using F1Management.Core.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Infrastructure.Repositories
{
    public class TireRepository : ITireRepository
    {
        private readonly AppDbContext _dbContext;

        public TireRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(List<Tire> tires)
        {
            tires.ForEach(t => _dbContext.Tires.Add(t));
            _dbContext.SaveChanges();
        }

        public void Delete(List<Tire> tires)
        {
            tires.ForEach(t => _dbContext.Tires.Remove(t));
            _dbContext.SaveChanges();
        }

        public List<Tire> GetAll()
        {
            return _dbContext.Tires.ToList();
        }

        public List<Tire> GetByCar(RaceCar raceCar)
        {
            return _dbContext.Tires
                .Where(t => t.RaceCar == raceCar)
                .ToList();
        }

        public List<Tire> GetByCar(RaceCar raceCar, TireType tireType)
        {
            return _dbContext.Tires
                .Where(t => t.RaceCar == raceCar && t.Type == tireType)
                .ToList();
        }

        public List<Tire> GetByType(TireType tireType)
        {
            return _dbContext.Tires
                .Where(t => t.Type == tireType)
                .ToList();
        }
    }
}
