using F1Management.Core.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Abstractions.Repositories.PartRepositories
{
    public interface IPartRepository<T> where T : Part
    {
        public List<T> GetByCar(RaceCar raceCar);
    }
}
