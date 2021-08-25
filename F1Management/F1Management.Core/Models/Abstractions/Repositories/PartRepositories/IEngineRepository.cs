using F1Management.Core.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Abstractions.Repositories.PartRepositories
{
    public interface IEngineRepository
    {
        public List<Engine> GetAll();
        public List<Engine> GetByCar(RaceCar raceCar);
        public Engine GetCurrentEngineOnCar(RaceCar raceCar);
        public void Add(Engine engine);
        public void Delete(Engine engine);
    }
}
