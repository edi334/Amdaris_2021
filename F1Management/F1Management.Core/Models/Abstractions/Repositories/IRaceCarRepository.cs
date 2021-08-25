using F1Management.Core.Models.Car;
using F1Management.Core.Models.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Abstractions.Repositories
{
    public interface IRaceCarRepository
    {
        public List<RaceCar> GetAll();
        public List<RaceCar> GetByTeam(Team team);
        public RaceCar GetByDriver(Driver driver);
        public RaceCar GetById(Guid id);
        public void Add(RaceCar raceCar);
        public void Delete(RaceCar raceCar);
    }
}
