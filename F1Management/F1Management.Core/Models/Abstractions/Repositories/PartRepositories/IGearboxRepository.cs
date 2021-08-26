using F1Management.Core.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Abstractions.Repositories.PartRepositories
{
    public interface IGearboxRepository
    {
        public List<Gearbox> GetAll();
        public List<Gearbox> GetByCar(RaceCar raceCar);
        public void Add(Gearbox gearbox);
        public void Delete(Gearbox gearbox);
    }
}
