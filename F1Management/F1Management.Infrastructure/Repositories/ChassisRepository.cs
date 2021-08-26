using F1Management.Core.Models.Abstractions.Repositories.PartRepositories;
using F1Management.Core.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Infrastructure
{
    public class ChassisRepository : IChassisRepository
    {
        private readonly AppDbContext _dbContext;

        public ChassisRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Chassis chassis)
        {
            _dbContext.Chassis.Add(chassis);
            _dbContext.SaveChanges();
        }

        public void Delete(Chassis chassis)
        {
            _dbContext.Chassis.Remove(chassis);
            _dbContext.SaveChanges();
        }

        public List<Chassis> GetAll()
        {
            return _dbContext.Chassis.ToList();
        }

        public List<Chassis> GetByCar(RaceCar raceCar)
        {
            return _dbContext.Chassis
                .Where(c => c.RaceCar == raceCar)
                .ToList();
        }
    }
}
