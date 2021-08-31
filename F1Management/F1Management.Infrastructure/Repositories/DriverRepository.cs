using F1Management.Core.Models.Abstractions.Repositories;
using F1Management.Core.Models.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Infrastructure.Repositories
{
    public class DriverRepository : IGenericRepository<Driver>
    {
        private readonly AppDbContext _dbContext;

        public DriverRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Driver driver)
        {
            _dbContext.Drivers.Add(driver);
            _dbContext.SaveChanges();
        }

        public void Delete(Driver driver)
        {
            _dbContext.Drivers.Remove(driver);
            _dbContext.SaveChanges();
        }

        public List<Driver> GetAll()
        {
            return _dbContext.Drivers.ToList();
        }

        public Driver GetById(Guid id)
        {
            return _dbContext.Drivers.FirstOrDefault(d => d.Id == id);
        }

        public void Update(Driver driver)
        {
            _dbContext.Drivers.Update(driver);
            _dbContext.SaveChanges();
        }
    }
}
