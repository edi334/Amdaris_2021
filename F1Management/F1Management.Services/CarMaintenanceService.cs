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
        private readonly ITeamRepository _teamRepository;

        public CarMaintenanceService(IRaceCarRepository raceCarRepository)
        {
            _raceCarRepository = raceCarRepository;
        }

        public async Task FixCar(RaceCar raceCar)
        {
            var carMechanic = await _teamRepository
                .GetFirstAvailableCarMechanicAsync(raceCar.Driver.TeamId);
            if (carMechanic == null)
            {
                throw new Exception("Car Mechanic Not Found");
            }

            carMechanic.isAvailable = false;
           
            await _teamRepository.UpdateCarMechanicAsync(carMechanic);
          
            raceCar.Chassis.Wear = 0;
            raceCar.Engine.Wear = 0;
            raceCar.Gearbox.Wear = 0;

            carMechanic.isAvailable = true;
           
            await _teamRepository.UpdateCarMechanicAsync(carMechanic);
           
            await _raceCarRepository.UpdateRaceCarAsync(raceCar);
        }

        public async Task FixChassis(RaceCar raceCar)
        {
            var carMechanic = await _teamRepository
                .GetFirstAvailableCarMechanicAsync(raceCar.Driver.TeamId);
            if (carMechanic == null)
            {
                throw new Exception("Car Mechanic Not Found");
            }

            carMechanic.isAvailable = false;
            
            await _teamRepository.UpdateCarMechanicAsync(carMechanic);
            
            raceCar.Chassis.Wear = 0;

            carMechanic.isAvailable = true;
           
            await _teamRepository.UpdateCarMechanicAsync(carMechanic);
           
            await _raceCarRepository.UpdateRaceCarAsync(raceCar);
        }

        public async Task FixEngine(RaceCar raceCar)
        {
            var carMechanic = await _teamRepository
                .GetFirstAvailableCarMechanicAsync(raceCar.Driver.TeamId);
            if (carMechanic == null)
            {
                throw new Exception("Car Mechanic Not Found");
            }

            carMechanic.isAvailable = false;
          
            await _teamRepository.UpdateCarMechanicAsync(carMechanic);
            
            raceCar.Engine.Wear = 0;

            carMechanic.isAvailable = true;
           
            await _teamRepository.UpdateCarMechanicAsync(carMechanic);

            await _raceCarRepository.UpdateRaceCarAsync(raceCar);
        }

        public async Task FixGearbox(RaceCar raceCar)
        {
            var carMechanic = await _teamRepository
                .GetFirstAvailableCarMechanicAsync(raceCar.Driver.TeamId);
            if (carMechanic == null)
            {
                throw new Exception("Car Mechanic Not Found");
            }

            carMechanic.isAvailable = false;
           
            await _teamRepository.UpdateCarMechanicAsync(carMechanic);
           
            raceCar.Gearbox.Wear = 0;

            carMechanic.isAvailable = true;
            
            await _teamRepository.UpdateCarMechanicAsync(carMechanic);
           
            await _raceCarRepository.UpdateRaceCarAsync(raceCar);
        }
    }
}
