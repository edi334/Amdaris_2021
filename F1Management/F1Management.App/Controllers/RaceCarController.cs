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
    [Route("api/race-car")]
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

        [HttpGet("{id}")]
        public async Task<ActionResult<RaceCarDto>> GetById([FromRoute] Guid id)
        {
            var raceCar = await _raceCarRepository.GetRaceCarAsync(id);
            var response = _mapper.Map<RaceCarDto>(raceCar);

            return Ok(response);
        }

        [HttpGet("team/{teamId}")]
        public async Task<ActionResult<List<RaceCarDto>>> GetByTeamId([FromRoute] Guid teamId)
        {
            var raceCars = await _raceCarRepository.GetByTeamAsync(teamId);
            var response = _mapper.Map<List<RaceCarDto>>(raceCars);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddRaceCar([FromBody] string name)
        {
            if (name == null)
            {
                return BadRequest();
            }

            await _raceCarRepository.AddRaceCarAsync(name);
            return Ok(true);
        }

        [HttpPost("{carId}/chassis")]
        public async Task<ActionResult<bool>> AddChassis([FromRoute] Guid carId, ChassisDto chassisDto)
        {
            if (chassisDto == null)
            {
                return BadRequest();
            }

            var chassis = _mapper.Map<Chassis>(chassisDto);
            chassis.RaceCarId = carId;

            await _raceCarRepository.AddChassisAsync(chassis);
           
            return Ok(true);
        }

        [HttpPost("{carId}/engine")]
        public async Task<ActionResult<bool>> AddEngine([FromRoute] Guid carId, EngineDto engineDto)
        {
            if (engineDto == null)
            {
                return BadRequest();
            }

            var engine = _mapper.Map<Engine>(engineDto);
            engine.RaceCarId = carId;

            await _raceCarRepository.AddEngineAsync(engine);
           
            return Ok(true);
        }

        [HttpPost("{carId}/gearbox")]
        public async Task<ActionResult<bool>> AddGearbox([FromRoute] Guid carId, GearboxDto gearboxDto)
        {
            if (gearboxDto == null)
            {
                return BadRequest();
            }

            var gearbox = _mapper.Map<Gearbox>(gearboxDto);
            gearbox.RaceCarId = carId;

            await _raceCarRepository.AddGearboxAsync(gearbox);

            return Ok(true);
        }

        [HttpPost("{carId}/tire-set")]
        public async Task<ActionResult<bool>> AddTireSet([FromRoute] Guid carId, TireSetDto tireSetDto)
        {
            if (tireSetDto == null)
            {
                return BadRequest();
            }

            var tireSet = _mapper.Map<TireSet>(tireSetDto);
            tireSet.RaceCarId = carId;

            await _raceCarRepository.AddTireSetAsync(tireSet);

            return Ok(true);
        }

        [HttpPatch("fix")]
        public async Task<ActionResult<bool>> FixRaceCar(RaceCarDto raceCarDto)
        {
            if (raceCarDto == null)
            {
                return BadRequest();
            }

            var raceCar = _mapper.Map<RaceCar>(raceCarDto);

            await _carMaintenanceService.FixCar(raceCar);

            return Ok(true);
        }

        [HttpPatch("fix-chassis")]
        public async Task<ActionResult<bool>> FixRaceCarChassis(RaceCarDto raceCarDto)
        {
            if (raceCarDto == null)
            {
                return BadRequest();
            }

            var raceCar = _mapper.Map<RaceCar>(raceCarDto);

            await _carMaintenanceService.FixChassis(raceCar);

            return Ok(true);
        }

        [HttpPatch("fix-engine")]
        public async Task<ActionResult<bool>> FixRaceCarEngine(RaceCarDto raceCarDto)
        {
            if (raceCarDto == null)
            {
                return BadRequest();
            }

            var raceCar = _mapper.Map<RaceCar>(raceCarDto);

            await _carMaintenanceService.FixEngine(raceCar);
            
            return Ok(true);
        }

        [HttpPatch("fix-gearbox")]
        public async Task<ActionResult<bool>> FixRaceCarGearbox(RaceCarDto raceCarDto)
        {
            if (raceCarDto == null)
            {
                return BadRequest();
            }

            var raceCar = _mapper.Map<RaceCar>(raceCarDto);

            await _carMaintenanceService.FixGearbox(raceCar);

            return Ok(true);
        }
    }
}
