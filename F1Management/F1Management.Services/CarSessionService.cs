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
        public CarSessionService(ITeamRepository teamRepository, ICarSessionRepository carSessionRepository)
        {
            _teamRepository = teamRepository;
            _carSessionRepository = carSessionRepository;
        }
        public async Task StartSessionAsync(CarSessionStartSpec carSessionStartSpec,
            CarMechanic carMechanic, RaceEngineer engineer, string strategy)
        {
            var carSession = carSessionStartSpec.CarSession;

            if (carMechanic != null)
            {
                carSession.RaceCar.Chassis = carSessionStartSpec.Chassis;
                carSession.RaceCar.Engine = carSessionStartSpec.Engine;
                carSession.RaceCar.Gearbox = carSessionStartSpec.Gearbox;
            }

            if (engineer != null && carSession.SessionType == SessionType.Race)
            {
                carSession.Strategy = strategy;
            }

            carSession.StartDate = DateTime.Now;

            await _carSessionRepository.UpdateSessionAsync(carSession);
        }
        public async Task PitStopAsync(CarSession carSession, TimeSpan stationaryTime, TireSet tireSet, PitStopCrew pitStopCrew)
        {
            var pitStop = new PitStop
            {
                Session = carSession,
                CarSessionId = carSession.Id,
                StationaryTime = stationaryTime,
                OldTires = carSession.RaceCar.TireSet,
                NewTires = tireSet
            };

            if (pitStopCrew != null)
            {
                pitStopCrew.ChangeTires(carSession.RaceCar, tireSet);
            }

            await _carSessionRepository.AddPitStopAsync(pitStop);
        }
        public async Task ChangeStrategyAsync(CarSession carSession, RaceEngineer engineer, string strategy)
        {
            if (engineer != null)
            {
                carSession.Strategy = strategy;
            }

            await _carSessionRepository.UpdateSessionAsync(carSession);
        }
        public async Task ChangePositionAsync(CarSession carSession, Admin admin, int position)
        {
            if (admin != null)
            {
                carSession.Position = position;
            }

            await _carSessionRepository.UpdateSessionAsync(carSession);
        }
        public async Task SetFastestLapAsync(CarSession carSession, Admin admin, TimeSpan fastestLap)
        {
            if (admin != null)
            {
                carSession.FastestLap = fastestLap;
            }

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
