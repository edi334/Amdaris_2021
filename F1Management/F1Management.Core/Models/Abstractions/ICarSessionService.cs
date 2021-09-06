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
        public void StartSession(CarSession carSession, Chassis chassis, Engine engine,
            Gearbox gearbox, CarMechanic carMechanic, RaceEngineer engineer, string strategy);
        public void PitStop(CarSession carSession, DateTime start, DateTime end, TireSet tireSet, PitStopCrew pitStopCrew);
        public void ChangeStrategy(RaceCar raceCar, RaceEngineer engineer, string strategy);
        public void ChangePosition(CarSession carSession, Admin admin, int position);
        public void SetFastestLap(CarSession carSession, Admin admin, TimeSpan fastestLap);
        public void EndSession(CarSession carSession);
    }
}
