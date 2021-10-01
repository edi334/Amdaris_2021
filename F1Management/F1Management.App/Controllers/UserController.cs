using AutoMapper;
using F1Management.App.DtoModels.IdentityDtos;
using F1Management.App.Identity;
using F1Management.Core.Models.Abstractions.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Management.App.Controllers
{
    [ApiController]
    [Route("auth")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IUserService userService,
            IMapper mapper, ITeamRepository teamRepository)
        {
            _userRepository = userRepository;
            _userService = userService;
            _mapper = mapper;
            _teamRepository = teamRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById([FromRoute] Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            var response = _mapper.Map<UserDto>(user);

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResultDto>> Login(LoginDto login)
        {
            var user = await _userRepository.FindUser(login.Email, login.Password);

            if (user == null)
            {
                return BadRequest();
            }
            else
            {
                var teamId = await _teamRepository.GetTeamIdByUser(user);
                var response = new LoginResultDto
                {
                    TeamId = teamId,
                    UserId = user.Id
                };

                return Ok(response);
            }
        }

        [HttpPost("{id}/register-team")]
        public async Task<ActionResult<string>> RegisterTeam([FromRoute] Guid id, string name)
        {
            if (name == null)
            {
                return BadRequest();
            }

            await _userService.RegisterTeamAsync(name, id);

            return Ok("Team created!");
        }

        [HttpPost("register-car-mechanic")]
        public async Task<ActionResult<string>> RegisterCarMechanic(RegisterDto registerDto)
        {
            if (registerDto == null)
            {
                return BadRequest();
            }

            await _userService.RegisterCarMechanicAsync(registerDto);

            return Ok("Register was succesful!");
        }

        [HttpPost("register-driver")]
        public async Task<ActionResult<string>> RegisterDriver(RegisterDto registerDto, int number, Guid raceCarId)
        {
            if (registerDto == null)
            {
                return BadRequest();
            }

            await _userService.RegisterDriverAsync(registerDto, number, raceCarId);

            return Ok("Register was succesful!");
        }

        [HttpPost("register-pit-stop-mechanic")]
        public async Task<ActionResult<string>> RegisterPitStopMechanic(RegisterDto registerDto)
        {
            if (registerDto == null)
            {
                return BadRequest();
            }

            await _userService.RegisterPitStopMechanicAsync(registerDto);

            return Ok("Register was succesful!");
        }

        [HttpPost("register-race-engineer")]
        public async Task<ActionResult<string>> RegisterRaceEngineer(RegisterDto registerDto, Guid driverId)
        {
            if (registerDto == null)
            {
                return BadRequest();
            }

            await _userService.RegisterRaceEngineerAsync(registerDto, driverId);

            return Ok("Register was succesful!");
        }
    }
}
