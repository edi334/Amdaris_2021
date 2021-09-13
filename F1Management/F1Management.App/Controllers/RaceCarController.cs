using AutoMapper;
using F1Management.App.DtoModels.CarDtos;
using F1Management.Core.Models.Abstractions;
using F1Management.Core.Models.Abstractions.Repositories;
using F1Management.Core.Models.Car;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Management.App.Controllers
{
    [ApiController]
    [Route("race-car")]
    public class RaceCarController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRaceCarRepository _raceCarRepository;
        private readonly ICarMaintenanceService _carMaintenanceService;

        public RaceCarController(IMapper mapper, IRaceCarRepository raceCarRepository,
             ICarMaintenanceService carMaintenanceService)
        {
            _mapper = mapper;
            _raceCarRepository = raceCarRepository;
            _carMaintenanceService = carMaintenanceService;
        }

        [HttpGet("{teamId}")]
        public async Task<ActionResult<IEnumerable<RaceCarDto>>> GetByTeam([FromRoute] Guid teamId)
        {
            var raceCars = await _raceCarRepository.GetByTeamAsync(teamId);
            var response = _mapper.Map<List<RaceCarDto>>(raceCars);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RaceCarDto>> GetById([FromRoute] Guid id)
        {
            var raceCar = await _raceCarRepository.GetRaceCarAsync(id);
            var response = _mapper.Map<RaceCarDto>(raceCar);

            return Ok(response);
        }
    }
}
