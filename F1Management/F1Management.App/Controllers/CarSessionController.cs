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

        [HttpPatch("start-session")]
        public async Task<ActionResult<bool>> StartSession(CarSessionStartSpecDto carSessionStartSpecDto,
            string strategy)
        {
            var carSessionStartSpec = _mapper.Map<CarSessionStartSpec>(carSessionStartSpecDto);

            try
            {
                await _carSessionService.StartSessionAsync(carSessionStartSpec, strategy);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(true);
        }

        [HttpPatch("strategy")]
        public async Task<ActionResult<bool>> ChangeStrategy(CarSessionDto carSessionDto, string strategy)
        {
            var carSession = _mapper.Map<CarSession>(carSessionDto);

            try
            {
                await _carSessionService.ChangeStrategyAsync(carSession, strategy);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(true);
        }

        [HttpPatch("position")]
        public async Task<ActionResult<bool>> ChangePosition(CarSessionDto carSessionDto, Guid userId, int position)
        {
            var carSession = _mapper.Map<CarSession>(carSessionDto);
           
            try
            {
                await _carSessionService.ChangePositionAsync(carSession, userId, position);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(true);
        }

        [HttpPatch("fastest-lap")]
        public async Task<ActionResult<bool>> SetFastestLap(CarSessionDto carSessionDto, Guid userId, TimeSpan fastestLap)
        {
            var carSession = _mapper.Map<CarSession>(carSessionDto);
          
            try
            {
                await _carSessionService.SetFastestLapAsync(carSession, userId, fastestLap);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(true);
        }

        [HttpPatch("end-session")]
        public async Task<ActionResult<bool>> EndSession(CarSessionDto carSessionDto)
        {
            var carSession = _mapper.Map<CarSession>(carSessionDto);

            try
            {
                await _carSessionService.EndSessionAsync(carSession);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(carSession);
        }
    }
}
