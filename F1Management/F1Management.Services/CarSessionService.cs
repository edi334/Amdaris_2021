using F1Management.Core.Models;
using F1Management.Core.Models.Abstractions.Repositories;
using F1Management.Core.Models.Car;
using F1Management.Core.Models.Identity;
using F1Management.Core.Models.TeamMembers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Services
{
    public class CarSessionService : ICarSessionService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly ICarSessionRepository _carSessionRepository;
        private readonly IUserRepository _userRepository;
        public CarSessionService(ITeamRepository teamRepository, ICarSessionRepository carSessionRepository,
            IUserRepository userRepository)
        {
            _teamRepository = teamRepository;
            _carSessionRepository = carSessionRepository;
            _userRepository = userRepository;
        }
        public async Task StartSessionAsync(CarSessionStartSpec carSessionStartSpec, string strategy)
        {
            var carSession = carSessionStartSpec.CarSession;
            var carMechanic = await _teamRepository
                .GetFirstAvailableCarMechanicAsync(carSession.RaceCar.Driver.TeamId);

            if (carMechanic == null)
            {
                throw new Exception("Car Mechanic Not Found");
            }

            carMechanic.isAvailable = false;
           
            await _teamRepository.UpdateCarMechanicAsync(carMechanic);
            
            carSession.RaceCar.Chassis = carSessionStartSpec.Chassis;
            carSession.RaceCar.Engine = carSessionStartSpec.Engine;
            carSession.RaceCar.Gearbox = carSessionStartSpec.Gearbox;
            
            carMechanic.isAvailable = true;
            
            await _teamRepository.UpdateCarMechanicAsync(carMechanic);
            
            var engineer = await _teamRepository.GetRaceEngineerAsync(carSession.RaceCar);
            if (engineer == null)
            {
                throw new Exception("Engineer Not Found");
            }

            if (carSession.SessionType == SessionType.Race)
            {
                carSession.Strategy = strategy;
            }

            carSession.StartDate = DateTime.Now;

            await _carSessionRepository.UpdateSessionAsync(carSession);
        }
        public async Task PitStopAsync(CarSession carSession, TimeSpan stationaryTime, TireSet tireSet)
        {
            var pitStopCrew = await _teamRepository
                .GetPitStopCrewAsync(carSession.RaceCar.Driver.TeamId);
            if (pitStopCrew == null)
            {
                throw new Exception("PitStop Crew Not Found");
            }

            if (!pitStopCrew.isAvailable)
            {
                throw new Exception("PitStop Crew Not Avaiable");
            }
            pitStopCrew.isAvailable = false;

            await _teamRepository.UpdatePitStopCrewAsync(pitStopCrew);
            
            var pitStop = new PitStop
            {
                Session = carSession,
                CarSessionId = carSession.Id,
                StationaryTime = stationaryTime,
                OldTires = carSession.RaceCar.TireSet,
                NewTires = tireSet
            };

            pitStopCrew.ChangeTires(carSession.RaceCar, tireSet);
            pitStopCrew.isAvailable = true;
            
            await _teamRepository.UpdatePitStopCrewAsync(pitStopCrew);
            
            await _carSessionRepository.AddPitStopAsync(pitStop);
        }
        public async Task ChangeStrategyAsync(CarSession carSession, string strategy)
        {
            var engineer = await _teamRepository.GetRaceEngineerAsync(carSession.RaceCar);

            if (engineer == null)
            {
                throw new Exception("Engineer Not Found");
            }

            carSession.Strategy = strategy;

            await _carSessionRepository.UpdateSessionAsync(carSession);
        }
        public async Task ChangePositionAsync(CarSession carSession, Guid userId, int position)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            if (user == null)
            {
                throw new Exception("User Not Found");
            }

            carSession.Position = position;

            await _carSessionRepository.UpdateSessionAsync(carSession);
        }
        public async Task SetFastestLapAsync(CarSession carSession, Guid userId, TimeSpan fastestLap)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            if (user == null)
            {
                throw new Exception("User Not Found");
            }

            carSession.FastestLap = fastestLap;

            await _carSessionRepository.UpdateSessionAsync(carSession);
        }
        public async Task EndSessionAsync(CarSession carSession)
        {
            if (carSession.SessionType == SessionType.Race)
            {
                var points = 0;
                var driver = carSession.RaceCar.Driver;
                var team = driver.Team;

                if (await _carSessionRepository.GetFastestLapFromAllCarsInSessionAsync(carSession) == carSession.FastestLap
                    && carSession.Position >= 10)
                {
                    points += 1;
                }

                points += PointsMapper.positionPointsDict[carSession.Position];

                driver.Points += points;
                team.Points += points;

                await _teamRepository.UpdateDriverAsync(driver);
                await _teamRepository.UpdateTeamAsync(team);
            }
        }
    }
}
