using F1Management.App.DtoModels;
using F1Management.App.DtoModels.IdentityDtos;
using F1Management.Core.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.App.Identity
{
    public interface IUserService
    {
        public Task RegisterDriverAsync(RegisterDto registerDto, int number, Guid raceCarId);
        public Task RegisterCarMechanicAsync(RegisterDto registerDto);
        public Task RegisterPitStopMechanicAsync(RegisterDto registerDto);
        public Task RegisterRaceEngineerAsync(RegisterDto registerDto, Guid driverId);
        public Task RegisterTeamAsync(string name);
    }
}
