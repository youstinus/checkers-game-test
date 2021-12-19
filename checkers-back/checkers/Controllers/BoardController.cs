using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using checkers.Algorithms;
using checkers.Constants;
using checkers.Infrastructure.DataBase.Models;
using checkers.Models;
using checkers.Services;
using checkers.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using static checkers.Algorithms.Methods;

namespace checkers.Controllers
{
    [Route("api/boards")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly IService<BoardDto> _boardService;
        public BoardController(IService<BoardDto> boardService)
        {
            _boardService = boardService;
        }

        [HttpGet(Name = nameof(RoutingEnum.GetBoards))]
        [Produces(typeof(BoardDto[]))]
        public async Task<IActionResult> Get()
        {
            return Ok(await _boardService.GetAll());
        }

        [HttpGet("{id}", Name = nameof(RoutingEnum.GetBoard))]
        [Produces(typeof(BoardDto))]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _boardService.GetById(id));
        }

        [HttpPost]
        [Produces(typeof(BoardDto))]
        public async Task<IActionResult> Create()
        {
            var newBoardDto = Populate(new BoardDto());
            var success = await _boardService.Create(newBoardDto);
            var uri = CreateResourceUri(success.Id);
            return Created(uri, success);
        }

        [HttpPut]
        public async Task<bool> Put([FromBody] BoardDto newMatch)
        {
            return await _boardService.Update(newMatch);
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _boardService.Delete(id);           
        }

        private Uri CreateResourceUri(int id)
        {
            const string name = nameof(RoutingEnum.GetBoard);
            var linkas = Url.Link(name, new {id});
            var naujas = new Uri(linkas);
            return naujas;
        }
    }
}
