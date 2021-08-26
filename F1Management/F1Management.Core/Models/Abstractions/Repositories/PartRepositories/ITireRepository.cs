using F1Management.Core.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Abstractions.Repositories.PartRepositories
{
    public interface ITireRepository
    {
        public List<Tire> GetAll();
        public List<Tire> GetByType(TireType tireType);
        public List<Tire> GetByCar(RaceCar raceCar);
        public List<Tire> GetByCar(RaceCar raceCar, TireType tireType);
        public void Add(List<Tire> tires);
        public void Delete(List<Tire> tires);
    }
}
