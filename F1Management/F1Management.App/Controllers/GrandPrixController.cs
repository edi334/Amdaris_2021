using AutoMapper;
using F1Management.App.DtoModels;
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
    [Route("api/grand-prix")]
    public class GrandPrixController : ControllerBase
    {
        private readonly IGrandPrixRepository _grandPrixRepository;
        private readonly IMapper _mapper;

        public GrandPrixController(IMapper mapper, IGrandPrixRepository grandPrixRepository)
        {
            _grandPrixRepository = grandPrixRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GrandPrixDto>>> Get()
        {
            var grandPrix = await _grandPrixRepository.GetAllAsync();
            Console.WriteLine(grandPrix);
            var response = _mapper.Map<List<GrandPrixDto>>(grandPrix);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GrandPrix>> GetById([FromRoute] Guid id)
        {
            var grandPrix = await _grandPrixRepository.GetByIdAsync(id);
            var response = _mapper.Map<GrandPrixDto>(grandPrix);

            return Ok(response);
        }
    }
}
