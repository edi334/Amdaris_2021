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
        public Task StartSessionAsync(CarSessionStartSpec carSessionStartSpec, string strategy);
        public Task PitStopAsync(CarSession carSession, TimeSpan stationaryTime, TireSet tireSet);
        public Task ChangeStrategyAsync(CarSession carSession, string strategy);
        public Task ChangePositionAsync(CarSession carSession, Guid userId, int position);
        public Task SetFastestLapAsync(CarSession carSession, Guid userId, TimeSpan fastestLap);
        public Task EndSessionAsync(CarSession carSession);
    }
}
