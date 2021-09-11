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
        private readonly IRaceCarRepository _raceCarRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly ICarSessionRepository _carSessionRepository;
        public CarSessionService(IRaceCarRepository raceCarRepository, 
            ITeamRepository teamRepository, ICarSessionRepository carSessionRepository)
        {
            _raceCarRepository = raceCarRepository;
            _teamRepository = teamRepository;
            _carSessionRepository = carSessionRepository;
        }
        public async Task StartSessionAsync(CarSessionStartSpec carSessionStartSpec,
            CarMechanic carMechanic, RaceEngineer engineer, string strategy)
        {
            if (carMechanic != null)
            {
                carSessionStartSpec.CarSession.RaceCar.Chassis = carSessionStartSpec.Chassis;
                carSessionStartSpec.CarSession.RaceCar.Engine = carSessionStartSpec.Engine;
                carSessionStartSpec.CarSession.RaceCar.Gearbox = carSessionStartSpec.Gearbox;
            }

            if (engineer != null && carSessionStartSpec.CarSession.SessionType == SessionType.Race)
            {
                carSessionStartSpec.CarSession.RaceCar.Strategy = strategy;
            }

            carSessionStartSpec.CarSession.StartDate = DateTime.Now;

            await _carSessionRepository.UpdateSessionAsync(carSessionStartSpec.CarSession);
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
        public async Task ChangeStrategyAsync(RaceCar raceCar, RaceEngineer engineer, string strategy)
        {
            if (engineer != null)
            {
                raceCar.Strategy = strategy;
            }

            await _raceCarRepository.UpdateRaceCarAsync(raceCar);
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
