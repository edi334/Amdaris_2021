using F1Management.Core.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Abstractions.Repositories.PartRepositories
{
    public interface IChassisRepository
    {
        public List<Chassis> GetAll();
        public List<Chassis> GetByCar(RaceCar raceCar);
        public Chassis GetCurrentChassisOnCar(RaceCar raceCar);
        public void Add(Chassis chassis);
        public void Delete(Chassis chassis);
    }
}
