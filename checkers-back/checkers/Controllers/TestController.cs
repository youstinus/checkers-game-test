using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkers.Constants;
using checkers.Infrastructure.DataBase.Models;
using checkers.Models;
using checkers.Services;
using checkers.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace checkers.Controllers
{
    [Route("api/tests")]
    public class TestController : ControllerBase
    {
        private readonly TestService _service;
        public TestController(TestService service)
        {
            _service = service;
        }

        [HttpGet]
        [Produces(typeof(SquareDto[]))]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]//, Name = nameof(RoutingEnum.GetSquare))]
        [Produces(typeof(SquareDto))]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpPost]
        [Produces(typeof(SquareDto))]
        public async Task<IActionResult> Create(int id)
        {
            //var newBoardDto = Populate(new BoardDto());
            var squareDto = new SquareDto();
            //squareDto.Checker = new CheckerDto();
            //squareDto.Checker.Color = 1;
            //squareDto.Checker.Queen = false;
            squareDto.BoardId = id;
            var success = await _service.Create(squareDto);

            var uri = CreateResourceUri(success.Id);
            return Created(uri, success);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] SquareDto newSquare)
        {
            var success = await _service.Update(newSquare);
            return Ok(success);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.Delete(id);
            return Ok(success);
        }

        private Uri CreateResourceUri(int id)
        {
            // ReSharper disable once RedundantAnonymousTypePropertyName
            return new Uri(Url.Link(nameof(RoutingEnum.GetSquare), new { id })); // id = id
        }
    }
}
