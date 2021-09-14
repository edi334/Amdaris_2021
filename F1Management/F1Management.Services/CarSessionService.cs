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
            try
            {
                await _teamRepository.UpdateCarMechanicAsync(carMechanic);
            }
            catch
            {
                throw;
            }

            carSession.RaceCar.Chassis = carSessionStartSpec.Chassis;
            carSession.RaceCar.Engine = carSessionStartSpec.Engine;
            carSession.RaceCar.Gearbox = carSessionStartSpec.Gearbox;
            
            carMechanic.isAvailable = true;
            try
            {
                await _teamRepository.UpdateCarMechanicAsync(carMechanic);
            }
            catch
            {
                throw;
            }

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

            try
            {
                await _carSessionRepository.UpdateSessionAsync(carSession);
            }
            catch
            {
                throw;
            }
        }
        public async Task PitStopAsync(CarSession carSession, TimeSpan stationaryTime, TireSet tireSet)
        {
            var pitStopCrew = await _teamRepository
                .GetPitStopCrew(carSession.RaceCar.Driver.TeamId);
            if (pitStopCrew == null)
            {
                throw new Exception("PitStop Crew Not Found");
            }

            if (!pitStopCrew.isAvailable)
            {
                throw new Exception("PitStop Crew Not Avaiable");
            }
            pitStopCrew.isAvailable = false;

            try
            {
                await _teamRepository.UpdatePitStopCrew(pitStopCrew);
            }
            catch
            {
                throw;
            }
            
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
            try
            {
                await _teamRepository.UpdatePitStopCrew(pitStopCrew);
            }
            catch
            {
                throw;
            }

            try
            {
                await _carSessionRepository.AddPitStopAsync(pitStop);
            }
            catch
            {
                throw;
            }
        }
        public async Task ChangeStrategyAsync(CarSession carSession, string strategy)
        {
            var engineer = await _teamRepository.GetRaceEngineerAsync(carSession.RaceCar);

            if (engineer == null)
            {
                throw new Exception("Engineer Not Found");
            }

            carSession.Strategy = strategy;

            try
            {
                await _carSessionRepository.UpdateSessionAsync(carSession);
            }
            catch
            {
                throw;
            }
        }
        public async Task ChangePositionAsync(CarSession carSession, Guid userId, int position)
        {
            var user = await _userRepository.GetById(userId);

            if (user == null)
            {
                throw new Exception("User Not Found");
            }

            if (!isAdmin(user))
            {
                throw new Exception("Not Admin");
            }

            carSession.Position = position;

            try
            {
                await _carSessionRepository.UpdateSessionAsync(carSession);
            }
            catch
            {
                throw;
            }
        }
        public async Task SetFastestLapAsync(CarSession carSession, Guid userId, TimeSpan fastestLap)
        {
            var user = await _userRepository.GetById(userId);

            if (user == null)
            {
                throw new Exception("User Not Found");
            }

            if (!isAdmin(user))
            {
                throw new Exception("Not Admin");
            }

            carSession.FastestLap = fastestLap;

            try
            {
                await _carSessionRepository.UpdateSessionAsync(carSession);
            }
            catch
            {
                throw;
            }
        }
        private bool isAdmin(User user)
        {
            bool isAdmin = false;

            user.UserRoles.ToList().ForEach(u =>
            {
                if (u.Role.Name == "admin")
                {
                    isAdmin = true;
                }
            });

            return isAdmin;
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

                try
                {
                    await _teamRepository.UpdateDriverAsync(driver);
                    await _teamRepository.UpdateTeamAsync(team);
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
