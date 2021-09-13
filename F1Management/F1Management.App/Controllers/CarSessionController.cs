using AutoMapper;
using F1Management.App.DtoModels;
using F1Management.App.DtoModels.CarDtos;
using F1Management.Core.Models;
using F1Management.Core.Models.Abstractions.Repositories;
using F1Management.Core.Models.Car;
using F1Management.Core.Models.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Management.App.Controllers
{
    [ApiController]
    [Route("api/car-session")]
    public class CarSessionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICarSessionRepository _carSessionRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly ICarSessionService _carSessionService;

        public CarSessionController(IMapper mapper, ICarSessionService carSessionService,
            ICarSessionRepository carSessionRepository, ITeamRepository teamRepository)
        {
            _mapper = mapper;
            _carSessionService = carSessionService;
            _carSessionRepository = carSessionRepository;
            _teamRepository = teamRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarSessionDto>>> GetByRaceCarAndGrandPrix(Guid raceCarId, Guid grandPrixId)
        {
            var carSessions = await _carSessionRepository.GetByGrandPrixAndRaceCarAsync(grandPrixId, raceCarId);
            var response = _mapper.Map<List<CarSessionDto>>(carSessions);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarSessionDto>> GetById([FromRoute] Guid id)
        {
            var carSession = await _carSessionRepository.GetByIdAsync(id);
            var response = _mapper.Map<CarSessionDto>(carSession);

            return Ok(response);
        }

        [HttpPatch("start-session")]
        public async Task<ActionResult<CarSession>> StartSession(CarSessionStartSpecDto carSessionStartSpecDto,
            string strategy)
        {
            var carSessionStartSpec = _mapper.Map<CarSessionStartSpec>(carSessionStartSpecDto);
            var carMechanic = await _teamRepository.GetFirstCarMechanicAsync();
            var raceEngineer = await _teamRepository.GetRaceEngineerAsync(carSessionStartSpec.CarSession.RaceCar);

            await _carSessionService.StartSessionAsync(carSessionStartSpec, carMechanic, raceEngineer, strategy);

            return Ok(carSessionStartSpec.CarSession);
        }

        [HttpPatch("strategy")]
        public async Task<ActionResult<CarSession>> ChangeStrategy(CarSessionDto carSessionDto, string strategy)
        {
            var carSession = _mapper.Map<CarSession>(carSessionDto);
            var raceEngineer = await _teamRepository.GetRaceEngineerAsync(carSession.RaceCar);

            await _carSessionService.ChangeStrategyAsync(carSession, raceEngineer, strategy);

            return Ok(carSession);
        }


        [HttpPatch("position")]
        public async Task<ActionResult<CarSession>> ChangePosition(CarSessionDto carSessionDto, int position)
        {
            var carSession = _mapper.Map<CarSession>(carSessionDto);
            //TODO: change
            var admin = new Admin();
            await _carSessionService.ChangePositionAsync(carSession, admin, position);

            return Ok(carSession);
        }

        [HttpPatch("fastest-lap")]
        public async Task<ActionResult<CarSession>> SetFastestLap(CarSessionDto carSessionDto, TimeSpan fastestLap)
        {
            var carSession = _mapper.Map<CarSession>(carSessionDto);
            //TODO: change
            var admin = new Admin();
            await _carSessionService.SetFastestLapAsync(carSession, admin, fastestLap);

            return Ok(carSession);
        }

        [HttpPatch("end-session")]
        public async Task<ActionResult<CarSession>> EndSession(CarSessionDto carSessionDto)
        {
            var carSession = _mapper.Map<CarSession>(carSessionDto);

            await _carSessionService.EndSessionAsync(carSession);

            return Ok(carSession);
        }
    }
}
