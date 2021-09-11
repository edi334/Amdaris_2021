using F1Management.Core.Models.Car;
using F1Management.Core.Models.Identity;
using F1Management.Core.Models.TeamMembers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Abstractions.Repositories
{
    public interface ICarSessionService
    {
        public Task StartSessionAsync(CarSession carSession, Chassis chassis, Engine engine,
            Gearbox gearbox, CarMechanic carMechanic, RaceEngineer engineer, string strategy);
        public Task PitStopAsync(CarSession carSession, TimeSpan stationaryTime, TireSet tireSet, PitStopCrew pitStopCrew);
        public Task ChangeStrategyAsync(RaceCar raceCar, RaceEngineer engineer, string strategy);
        public Task ChangePositionAsync(CarSession carSession, Admin admin, int position);
        public Task SetFastestLapAsync(CarSession carSession, Admin admin, TimeSpan fastestLap);
        public Task EndSessionAsync(CarSession carSession);
    }
}
