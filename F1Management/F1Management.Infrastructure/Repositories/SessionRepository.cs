using F1Management.Core;
using F1Management.Core.Models;
using F1Management.Core.Models.Abstractions.Repositories;
using F1Management.Core.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Infrastructure.Repositories
{
    public class SessionRepository : IGenericRepository<Session>, ISessionRepository
    {
        private readonly AppDbContext _dbContext;
        public void Add(Session session)
        {
            _dbContext.Sessions.Add(session);
            _dbContext.SaveChanges();
        }

        public void Delete(Session session)
        {
            _dbContext.Sessions.Remove(session);
            _dbContext.SaveChanges();
        }

        public List<Session> GetAll()
        {
            return _dbContext.Sessions.ToList();
        }

        public List<Session> GetByCar(RaceCar raceCar)
        {
            return _dbContext.Sessions
                .Where(s => s.RaceCar == raceCar)
                .ToList();
        }

        public List<Session> GetByCarAndRace(RaceCar raceCar, GrandPrix race)
        {
            return _dbContext.Sessions
                .Where(s => s.RaceCar == raceCar && s.Race == race)
                .ToList();
        }

        public Session GetById(Guid id)
        {
            return _dbContext.Sessions.FirstOrDefault(s => s.Id == id);
        }

        public List<Session> GetByRace(GrandPrix race)
        {
            return _dbContext.Sessions
                .Where(s => s.Race == race)
                .ToList();
        }

        public void Update(Session session)
        {
            _dbContext.Sessions.Update(session);
            _dbContext.SaveChanges();
        }
    }
}
