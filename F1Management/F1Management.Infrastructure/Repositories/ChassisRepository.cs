using F1Management.Core.Models.Abstractions.Repositories;
using F1Management.Core.Models.Abstractions.Repositories.PartRepositories;
using F1Management.Core.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Infrastructure
{
    public class ChassisRepository : IGenericRepository<Chassis>, IPartRepository<Chassis>
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

        public Chassis GetById(Guid id)
        {
            return _dbContext.Chassis.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Chassis chassis)
        {
            _dbContext.Chassis.Update(chassis);
            _dbContext.SaveChanges();
        }
    }
}
