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

        [HttpGet("{id}")]
        public async Task<ActionResult<RaceCarDto>> GetById([FromRoute] Guid id)
        {
            var raceCar = await _raceCarRepository.GetRaceCarAsync(id);
            var response = _mapper.Map<RaceCarDto>(raceCar);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddRaceCar([FromBody] string name)
        {
            try
            {
                await _raceCarRepository.AddRaceCarAsync(name);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(true);
        }

        [HttpPost("{carId}/chassis")]
        public async Task<ActionResult<bool>> AddChassis([FromRoute] Guid carId, ChassisDto chassisDto)
        {
            var chassis = _mapper.Map<Chassis>(chassisDto);
            chassis.RaceCarId = carId;

            try
            {
                await _raceCarRepository.AddChassisAsync(chassis);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(true);
        }

        [HttpPost("{carId}/engine")]
        public async Task<ActionResult<bool>> AddEngine([FromRoute] Guid carId, EngineDto engineDto)
        {
            var engine = _mapper.Map<Engine>(engineDto);
            engine.RaceCarId = carId;

            try
            {
                await _raceCarRepository.AddEngineAsync(engine);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(true);
        }

        [HttpPost("{carId}/gearbox")]
        public async Task<ActionResult<bool>> AddGearbox([FromRoute] Guid carId, GearboxDto gearboxDto)
        {
            var gearbox = _mapper.Map<Gearbox>(gearboxDto);
            gearbox.RaceCarId = carId;

            try
            {
                await _raceCarRepository.AddGearboxAsync(gearbox);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(true);
        }

        [HttpPost("{carId}/tire-set")]
        public async Task<ActionResult<bool>> AddTireSet([FromRoute] Guid carId, TireSetDto tireSetDto)
        {
            var tireSet = _mapper.Map<TireSet>(tireSetDto);
            tireSet.RaceCarId = carId;

            try
            {
                await _raceCarRepository.AddTireSetAsync(tireSet);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(true);
        }

        [HttpPatch("fix")]
        public async Task<ActionResult<bool>> FixRaceCar(RaceCarDto raceCarDto)
        {
            var raceCar = _mapper.Map<RaceCar>(raceCarDto);

            try
            {
                await _carMaintenanceService.FixCar(raceCar);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(true);
        }

        [HttpPatch("fix-chassis")]
        public async Task<ActionResult<bool>> FixRaceCarChassis(RaceCarDto raceCarDto)
        {
            var raceCar = _mapper.Map<RaceCar>(raceCarDto);

            try
            {
                await _carMaintenanceService.FixChassis(raceCar);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(true);
        }

        [HttpPatch("fix-engine")]
        public async Task<ActionResult<bool>> FixRaceCarEngine(RaceCarDto raceCarDto)
        {
            var raceCar = _mapper.Map<RaceCar>(raceCarDto);

            try
            {
                await _carMaintenanceService.FixEngine(raceCar);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(true);
        }

        [HttpPatch("fix-gearbox")]
        public async Task<ActionResult<bool>> FixRaceCarGearbox(RaceCarDto raceCarDto)
        {
            var raceCar = _mapper.Map<RaceCar>(raceCarDto);

            try
            {
                await _carMaintenanceService.FixGearbox(raceCar);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(true);
        }
    }
}
