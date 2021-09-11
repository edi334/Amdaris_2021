using AutoMapper;
using F1Management.App.DtoModels;
using F1Management.App.DtoModels.CarDtos;
using F1Management.Core.Models;
using F1Management.Core.Models.Abstractions.Repositories;
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
        private readonly ICarSessionService _carSessionService;

        public CarSessionController(IMapper mapper, ICarSessionService carSessionService,
            ICarSessionRepository carSessionRepository)
        {
            _mapper = mapper;
            _carSessionService = carSessionService;
            _carSessionRepository = carSessionRepository;
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

        [HttpPatch]
        public async Task<ActionResult<CarSession>> StartSession(CarSessionDto carSession, ChassisDto chassis, 
            EngineDto engine, GearboxDto gearbox, string strategy)
        {

        }
    }
}
