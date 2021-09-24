using AutoMapper;
using F1Management.App.DtoModels;
using F1Management.App.DtoModels.TeamMemberDtos;
using F1Management.Core;
using F1Management.Core.Models.Abstractions.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Management.App.Controllers
{
    [ApiController]
    [Route("team")]
    public class TeamController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITeamRepository _teamRepository;
        public TeamController(IMapper mapper, ITeamRepository teamRepository)
        {
            _mapper = mapper;
            _teamRepository = teamRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TeamDto>>> GetAll()
        {
            var teams = await _teamRepository.GetAllAsync();
            var response = _mapper.Map<List<TeamDto>>(teams);

            return Ok(response);
        }

        [HttpGet("drivers")]
        public async Task<ActionResult<List<DriverDto>>> GetAllDrivers()
        {
            var drivers = await _teamRepository.GetAllDriversAsync();
            var response = _mapper.Map<List<DriverDto>>(drivers);

            return Ok(response);
        }

        [HttpGet("{teamId}/drivers")]
        public async Task<ActionResult<List<DriverDto>>> GetDrivers([FromRoute] Guid teamId)
        {
            var drivers = await _teamRepository.GetDriversAsync(teamId);
            var response = _mapper.Map<List<DriverDto>>(drivers);

            return Ok(response);
        }

        [HttpGet("{teamId}/race-engineers")]
        public async Task<ActionResult<List<RaceEngineerDto>>> GetRaceEngineers([FromRoute] Guid teamId)
        {
            var raceEngineers = await _teamRepository.GetRaceEngineersAsync(teamId);
            var response = _mapper.Map<List<RaceEngineerDto>>(raceEngineers);

            return Ok(response);
        }

        [HttpGet("{teamId}/car-mechanics")]
        public async Task<ActionResult<List<CarMechanicDto>>> GetCarMechanics([FromRoute] Guid teamId)
        {
            var carMechanics = await _teamRepository.GetCarMechanicsAsync(teamId);
            var response = _mapper.Map<List<CarMechanicDto>>(carMechanics);

            return Ok(response);
        }

        [HttpGet("{teamId}/pitstop-mechanics")]
        public async Task<ActionResult<List<PitStopMechanicDto>>> GetPitStopMechanics([FromRoute] Guid teamId)
        {
            var pitStopMechanics = await _teamRepository.GetPitStopMechanicsAsync(teamId);
            var response = _mapper.Map<List<PitStopMechanicDto>>(pitStopMechanics);

            return Ok(response);
        }
    }
}
