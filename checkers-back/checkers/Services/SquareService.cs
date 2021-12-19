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
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace checkers.Services
{
    public class SquareService : IService<SquareDto>// BaseService<SquareDto, Square>

    {
        private readonly IMapper _mapper;
        private readonly ITimeService _timeService;
        private readonly IRepository<Square> _squareRepository;
        public SquareService(IRepository<Square> squareRepository, IMapper mapper, ITimeService timeService)
        {
            _squareRepository = squareRepository;
            _mapper = mapper;
            _timeService = timeService;
        }
        public async Task<ICollection<SquareDto>> GetAll()
        {
            var matches = await _squareRepository.GetAll();
            var matchesDto = _mapper.Map<SquareDto[]>(matches);
            return matchesDto;
        }
        public async Task<SquareDto> Create(SquareDto newItem)
        {
            if (newItem == null) throw new ArgumentNullException(nameof(newItem));

            var square = CreateSquarePoco(newItem);
            await _squareRepository.Create(square);

            var matchDto = _mapper.Map<SquareDto>(square);
            return matchDto;
        }
        public async Task<SquareDto> GetById(int id)
        {
            var square = await _squareRepository.GetById(id);
            var squareDto = _mapper.Map<SquareDto>(square);
            return squareDto;
        }
        public async Task<bool> Update(SquareDto updateData)
        {
            var square = CreateSquarePoco(updateData);
            return await _squareRepository.Update(square);
        }
        public async Task<bool> Delete(int id)
        {
            var getSquareToDelete = _squareRepository.GetById(id).Result;
            return await _squareRepository.Delete(getSquareToDelete);
        }
        private Square CreateSquarePoco(SquareDto newItem)
        {
            var creationDate = _timeService.GetCurrentTime();
            var square = _mapper.Map<Square>(newItem);
            square.LastModified = creationDate;
            square.Created = creationDate;
            return square;
        }
    }
}
