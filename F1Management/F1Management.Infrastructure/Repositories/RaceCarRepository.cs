using F1Management.Core.Models.Abstractions.Repositories;
using F1Management.Core.Models.Car;
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
        public RaceCar GetRaceCar(Guid id)
        {
            return _dbContext.RaceCars
                .FirstOrDefault(r => r.Id == id);
        }
        public void UpdateRaceCar(RaceCar raceCar)
        {
            _dbContext.RaceCars.Update(raceCar);
            _dbContext.SaveChanges();
        }
    }
}
