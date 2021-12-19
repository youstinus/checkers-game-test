using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkers.Constants;
using checkers.Infrastructure.DataBase.Models;
using checkers.Models;
using checkers.Services;
using checkers.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace checkers.Controllers
{
    [Route("api/checkers")]
    public class CheckerController : ControllerBase
    {
        private readonly IService<CheckerDto> _checkerService;
        public CheckerController(IService<CheckerDto> checkerService)
        {
            _checkerService = checkerService;
        }

        [HttpGet(Name = nameof(RoutingEnum.GetCheckers))]
        [Produces(typeof(CheckerDto[]))]
        public async Task<IActionResult> Get()
        {
            return Ok(await _checkerService.GetAll());
        }

        [HttpGet("{id}", Name = nameof(RoutingEnum.GetChecker))]
        [Produces(typeof(CheckerDto))]
        public async Task<IActionResult> GetById(int id)
        {
            var checker = await _checkerService.GetById(id);
            return Ok(checker);
        }

        [HttpPost]
        [Produces(typeof(CheckerDto))]
        public async Task<IActionResult> Create([FromBody] CheckerDto newChecker)
        {
            var checker = await _checkerService.Create(newChecker);
            var uri = CreateResourceUri(checker.Id);
            return Created(uri, checker);
        }

        [HttpPut]
        public async Task<bool> Put([FromBody] CheckerDto newMatch)
        {
            return await _checkerService.Update(newMatch);
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {           
            return await _checkerService.Delete(id);
        }

        private Uri CreateResourceUri(int id)
        {
            return new Uri(Url.Link(nameof(RoutingEnum.GetCheckers), new { id }));
        }
    }
}
