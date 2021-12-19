using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using checkers.Infrastructure.DataBase;
using checkers.Infrastructure.DataBase.Models;
using checkers.Infrastructure.Repositories;
using checkers.Infrastructure.Repositories.Interfaces;
using checkers.Infrastructure.Utils;
using checkers.Models;
using checkers.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace checkers.Services
{
    public class BoardService : IService<BoardDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Board> _boardRepository;
        private readonly ITimeService _timeService;
        public BoardService(IMapper mapper, IRepository<Board> boardRepository, ITimeService timeService)
        {
            _boardRepository = boardRepository;
            _mapper = mapper;
            _timeService = timeService;
        }
        public async Task<BoardDto> Create(BoardDto newItemDto)
        {        
            var board = CreateBoardPoco(newItemDto);
            var boardResponce = await _boardRepository.Create(board);
            var boardDb = await _boardRepository.GetById(boardResponce); // do need responce?
            var boardDto = _mapper.Map<BoardDto>(boardDb);
            return boardDto;
        }
        public async Task<ICollection<BoardDto>> GetAll()
        {
            var boards = await _boardRepository.GetAll();
            var boardsDto = _mapper.Map<BoardDto[]>(boards);
            return boardsDto;
        }
        public async Task<BoardDto> GetById(int id)
        {
            var board = await _boardRepository.GetById(id);
            var boardDto = _mapper.Map<BoardDto>(board);
            return boardDto;
        }
        public async Task<bool> Update(BoardDto updateBoardDto)
        {
            var updateBoard = UpdateBoardPoco(updateBoardDto);      
            return await _boardRepository.Update(updateBoard);
        }
        public async Task<bool> Delete(int id)
        {
            var getBoardToDelete = _boardRepository.GetById(id).Result;
            return await _boardRepository.Delete(getBoardToDelete);
        }
        private Board CreateBoardPoco(BoardDto newItem)
        {
            var creationDate = _timeService.GetCurrentTime();
            var board = _mapper.Map<Board>(newItem);
            board.LastModified = creationDate;
            board.Created = creationDate;
            return board;
        }
        private Board UpdateBoardPoco(BoardDto newItem)
        {
            var updateDateTime = _timeService.GetCurrentTime();
            var board = _mapper.Map<Board>(newItem);
            board.LastModified = updateDateTime;
            return board;
        }
    }
}