using F1Management.Core.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Abstractions.Repositories
{
    public interface ISessionRepository
    {
        public List<Session> GetByRace(Race race);
        public List<Session> GetByCar(RaceCar raceCar);
        public List<Session> GetByCarAndRace(RaceCar raceCar, Race race);
    }
}
