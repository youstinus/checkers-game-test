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
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace checkers.Services
{
    public class CheckerService : IService<CheckerDto> // BaseService<CheckerDto, Checker> //
    {
        private readonly IMapper _mapper;
        private readonly ITimeService _timeService;
        private readonly IRepository<Checker> _checkerRepository;
        public CheckerService(IRepository<Checker> checkerRepository, IMapper mapper, ITimeService timeService)
        {
            _checkerRepository = checkerRepository;
            _mapper = mapper;
            _timeService = timeService;
        }

        public async Task<ICollection<CheckerDto>> GetAll()
        {
            var checkers = await _checkerRepository.GetAll();
            var checkersDto = _mapper.Map<CheckerDto[]>(checkers);
            return checkersDto;
        }
        public async Task<CheckerDto> Create(CheckerDto newItem)
        {
            var checker = CreateCheckerPoco(newItem);            
            await _checkerRepository.Create(checker);
            var getSame = await _checkerRepository.GetById(checker.Id);
            var getSame2 = _mapper.Map<CheckerDto>(getSame);
            return getSame2;
        }

        /*Task<CheckerDto> IService<CheckerDto>.Create()
        {
            throw new NotImplementedException();
        }*/


        public async Task<CheckerDto> GetById(int id)
        {
            var checker = await _checkerRepository.GetById(id);
            var checkerDto = _mapper.Map<CheckerDto>(checker);
            return checkerDto;
        }
        public async Task<bool> Update(CheckerDto updateData)
        {
            var checker = CreateCheckerPoco(updateData);
            return await _checkerRepository.Update(checker);
        }
        public async Task<bool> Delete(int id)
        {
            var getCheckerToDelete = _checkerRepository.GetById(id).Result;
            return await _checkerRepository.Delete(getCheckerToDelete);
        }
        private Checker CreateCheckerPoco(CheckerDto newItem)
        {
            var creationDate = _timeService.GetCurrentTime();
            var checker = _mapper.Map<Checker>(newItem);
            checker.LastModified = creationDate;
            checker.Created = creationDate;
            return checker;
        }
    }
}
