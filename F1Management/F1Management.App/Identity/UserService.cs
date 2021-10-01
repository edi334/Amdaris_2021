using AutoMapper;
using F1Management.App.DtoModels;
using F1Management.App.DtoModels.IdentityDtos;
using F1Management.Core;
using F1Management.Core.Models.Abstractions.Repositories;
using F1Management.Core.Models.Identity;
using F1Management.Core.Models.TeamMembers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Management.App.Identity
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly ITeamRepository _teamRepository;

        public UserService(IMapper mapper, IUserRepository userRepository, ITeamRepository teamRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _teamRepository = teamRepository;
        }

        public async Task RegisterCarMechanicAsync(RegisterDto registerDto)
        {
            var newUser = await registerUserAsync(registerDto.User);

            var carMechanic = new CarMechanic
            {
                UserId = newUser.Id,
                TeamId = registerDto.TeamId
            };

            await _teamRepository.AddCarMechanicAsync(carMechanic);
        }

        public async Task RegisterDriverAsync(RegisterDto registerDto, int number, Guid raceCarId)
        {
            var newUser = await registerUserAsync(registerDto.User);

            var driver = new Driver
            {
                UserId = newUser.Id,
                TeamId = registerDto.TeamId,
                Number = number,
                RaceCarId = raceCarId
            };

            await _teamRepository.AddDriverAsync(driver);
        }

        public async Task RegisterPitStopMechanicAsync(RegisterDto registerDto)
        {
            var pitStopCrew = await _teamRepository.GetPitStopCrewAsync(registerDto.TeamId);

            if (pitStopCrew == null)
            {
                pitStopCrew = new PitStopCrew
                {
                    TeamId = registerDto.TeamId
                };

                await _teamRepository.AddPitStopCrewAsync(pitStopCrew);
            }

            if (pitStopCrew.PitStopMechanics.Count > 12)
            {
                throw new Exception("PitStop Crew is full");
            }

            var newUser = await registerUserAsync(registerDto.User);

            var pitStopMechanic = new PitStopMechanic
            {
                UserId = newUser.Id,
                PitStopCrewId = pitStopCrew.Id
            };

            await _teamRepository.AddPitStopMechanicAsync(pitStopMechanic);
        }

        public async Task RegisterRaceEngineerAsync(RegisterDto registerDto, Guid driverId)
        {
            var newUser = await registerUserAsync(registerDto.User);

            var raceEngineer = new RaceEngineer
            {
                UserId = newUser.Id,
                TeamId = registerDto.TeamId,
                DriverId = driverId
            };

            await _teamRepository.AddRaceEngineerAsync(raceEngineer);
        }

        public async Task RegisterTeamAsync(string name)
        {
            var team = new Team
            {
                Name = name
            };

            await _teamRepository.AddTeamAsync(team);
        }

        private async Task<User> registerUserAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userRepository.AddUserAsync(user);

            return user;
        }
    }
}
