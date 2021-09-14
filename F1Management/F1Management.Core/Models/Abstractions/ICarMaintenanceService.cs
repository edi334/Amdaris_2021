using F1Management.Core.Models.Car;
using F1Management.Core.Models.TeamMembers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Abstractions
{
    public interface ICarMaintenanceService
    {
        public Task FixCar(RaceCar raceCar);
        public Task FixChassis(RaceCar raceCar);
        public Task FixEngine(RaceCar raceCar);
        public Task FixGearbox(RaceCar raceCar);
    }
}
