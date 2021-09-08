﻿using F1Management.Core.Models;
using F1Management.Core.Models.Abstractions.Repositories;
using F1Management.Core.Models.Car;
using F1Management.Core.Models.Identity;
using F1Management.Core.Models.TeamMembers;
using F1Management.Infrastructure.Repositories;
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
        public CarSessionService(RaceCarRepository raceCarRepository, 
            TeamRepository teamRepository, CarSessionRepository carSessionRepository)
        {
            _raceCarRepository = raceCarRepository;
            _teamRepository = teamRepository;
            _carSessionRepository = carSessionRepository;
        }
        public async Task StartSessionAsync(CarSession carSession, Chassis chassis, Engine engine,
            Gearbox gearbox, CarMechanic carMechanic, RaceEngineer engineer, string strategy)
        {
            if (carMechanic != null)
            {
                carSession.RaceCar.Chassis = chassis;
                carSession.RaceCar.Engine = engine;
                carSession.RaceCar.Gearbox = gearbox;
            }

            if (engineer != null && carSession.SessionType == SessionType.Race)
            {
                carSession.RaceCar.Strategy = strategy;
            }

            carSession.StartDate = DateTime.Now;

            await _carSessionRepository.UpdateSessionAsync(carSession);
        }
        public async Task PitStopAsync(CarSession carSession, DateTime start, DateTime end, TireSet tireSet, PitStopCrew pitStopCrew)
        {
            var pitStop = new PitStop
            {
                Session = carSession,
                CarSessionId = carSession.Id,
                StationaryTime = end - start,
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

                switch (carSession.Position)
                {
                    case 1: points += 25; break;
                    case 2: points += 18; break;
                    case 3: points += 15; break;
                    case 4: points += 12; break;
                    case 5: points += 10; break;
                    case 6: points += 8; break;
                    case 7: points += 6; break;
                    case 8: points += 4; break;
                    case 9: points += 2; break;
                    case 10: points += 1; break;
                    default: break;
                }

                driver.Points += points;
                team.Points += points;

                await _teamRepository.UpdateDriverAsync(driver);
                await _teamRepository.UpdateTeamAsync(team);
            }
        }
    }
}
