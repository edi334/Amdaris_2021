using F1Management.App.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.App.Identity
{
    interface IUserService
    {
        public Task RegisterDriverAsync(RegisterDto registerDto, int number, Guid raceCarId);
        public Task RegisterCarMechanicAsync(RegisterDto registerDto);
        public Task RegisterPitStopMechanicAsync(RegisterDto registerDto);
        public Task RegisterRaceEngineerAsync(RegisterDto registerDto, Guid driverId);
        public Task RegisterTeamAsync(TeamDto team, Guid guid);
    }
}
