using F1Management.Core.Models.Abstractions;
using F1Management.Core.Models.Abstractions.Repositories;
using F1Management.Core.Models.Car;
using F1Management.Core.Models.TeamMembers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Services
{
    public class CarMaintenanceService : ICarMaintenanceService
    {
        private readonly IRaceCarRepository _raceCarRepository;

        public CarMaintenanceService(IRaceCarRepository raceCarRepository)
        {
            _raceCarRepository = raceCarRepository;
        }

        public async Task FixCar(RaceCar raceCar, CarMechanic carMechanic)
        {
            if (carMechanic != null)
            {
                raceCar.Chassis.Wear = 0;
                raceCar.Engine.Wear = 0;
                raceCar.Gearbox.Wear = 0;
            }

            await _raceCarRepository.UpdateRaceCarAsync(raceCar);
        }

        public async Task FixChassis(RaceCar raceCar, CarMechanic carMechanic)
        {
            if (carMechanic != null)
            {
                raceCar.Chassis.Wear = 0;
            }

            await _raceCarRepository.UpdateRaceCarAsync(raceCar);
        }

        public async Task FixEngine(RaceCar raceCar, CarMechanic carMechanic)
        {
            if (carMechanic != null)
            {
                raceCar.Engine.Wear = 0;
            }

            await _raceCarRepository.UpdateRaceCarAsync(raceCar);
        }

        public async Task FixGearbox(RaceCar raceCar, CarMechanic carMechanic)
        {
            if (carMechanic != null)
            {
                raceCar.Gearbox.Wear = 0;
            }

            await _raceCarRepository.UpdateRaceCarAsync(raceCar);
        }
    }
}
