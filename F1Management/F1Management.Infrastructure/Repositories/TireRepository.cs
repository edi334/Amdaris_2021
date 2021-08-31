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
    public class TireRepository : IGenericRepository<Tire>, IPartRepository<Tire>, ITireRepository
    {
        private readonly AppDbContext _dbContext;

        public TireRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Tire tire)
        {
            _dbContext.Tires.Add(tire);
            _dbContext.SaveChanges();
        }

        public void Delete(Tire tire)
        {
            _dbContext.Tires.Remove(tire);
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

        public Tire GetById(Guid id)
        {
            return _dbContext.Tires.FirstOrDefault(t => t.Id == id);
        }

        public List<Tire> GetByType(TireType tireType)
        {
            return _dbContext.Tires
                .Where(t => t.Type == tireType)
                .ToList();
        }

        public void Update(Tire tire)
        {
            _dbContext.Tires.Update(tire);
            _dbContext.SaveChanges();
        }
    }
}
