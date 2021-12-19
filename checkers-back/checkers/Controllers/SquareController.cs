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
    [Route("api/squares")]
    public class SquareController : ControllerBase
    {
        private readonly IService<SquareDto> _squareService;
        public SquareController(IService<SquareDto> service)
        {
            _squareService = service;
        }

        [HttpGet(Name = nameof(RoutingEnum.GetSquares))]
        [Produces(typeof(SquareDto[]))]
        public async Task<IActionResult> Get()
        {
            var squares = await _squareService.GetAll();
            return Ok(squares);
        }
        
        [HttpGet("{id}", Name = nameof(RoutingEnum.GetSquare))]
        [Produces(typeof(SquareDto))]
        public async Task<IActionResult> GetById(int id)
        {
            var match = await _squareService.GetById(id);
            return Ok(match);
        }
        
        [HttpPost]
        [Produces(typeof(SquareDto))]
        public async Task<IActionResult> Post([FromBody] SquareDto newSquare)
        {
            var square = await _squareService.Create(newSquare);
            var uri = CreateResourceUri(square.Id);
            return Created(uri, square);
        }
        
        [HttpPut]
        public async Task<bool> Put([FromBody] SquareDto newMatch)
        {
            return await _squareService.Update(newMatch);
        }

        /*[HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument<SquareDto> patch)
        {
            _squareService.PartialUpdate(id, patch);
            return NoContent();
        }*/

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _squareService.Delete(id);
        }

        private Uri CreateResourceUri(int id)
        {
            return new Uri(Url.Link(nameof(RoutingEnum.GetSquares), new { id }));
        }
    }
}
