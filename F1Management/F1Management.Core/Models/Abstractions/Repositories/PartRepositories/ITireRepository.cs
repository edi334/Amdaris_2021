using F1Management.Core.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Abstractions.Repositories.PartRepositories
{
    interface ITireRepository
    {
        public List<Tire> GetAll();
        public List<Tire> GetByType(TireType tireType);
        public List<Tire> GetByCar();
        public List<Tire> GetByCar(TireType tireType);
        public void Add(List<Tire> tires);
        public void Delete(List<Tire> tires);
    }
}
