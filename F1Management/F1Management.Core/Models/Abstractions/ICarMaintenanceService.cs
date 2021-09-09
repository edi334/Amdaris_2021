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
        public Task FixCar(RaceCar raceCar, CarMechanic carMechanic);
        public Task FixChassis(RaceCar raceCar, CarMechanic carMechanic);
        public Task FixEngine(RaceCar raceCar, CarMechanic carMechanic);
        public Task FixGearbox(RaceCar raceCar, CarMechanic carMechanic);
    }
}
