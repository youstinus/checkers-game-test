using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using checkers.Infrastructure.DataBase;
using checkers.Infrastructure.DataBase.Models;
using checkers.Infrastructure.Repositories;
using checkers.Infrastructure.Repositories.Interfaces;
using checkers.Models;
using checkers.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses;

namespace checkers.Services
{
    public class BaseService<TDto, TEntity> : RepositoryBase<TEntity>, IService<TDto> where TEntity : BaseEntity where TDto : BaseDto
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TEntity> _repositoryBase;
        protected override DbSet<TEntity> ItemSet { get; }
        public BaseService(IMapper mapper, IRepository<TEntity> repositoryBase, CheckersDbContext context) : base(context)
        {
            _repositoryBase = repositoryBase;
            _mapper = mapper;
            ItemSet = (DbSet<TEntity>)context.GetSome(context);
            //ItemSet = context.Items;
        }
        async Task<ICollection<TDto>> IService<TDto>.GetAll()
        {
            var boards = await _repositoryBase.GetAll();
            var boardsDto = _mapper.Map<TDto[]>(boards);
            return boardsDto;
        }
        public async Task<TDto> Create(TDto newItem)
        {
            var checker = CreatePoco(newItem);
            var id = await _repositoryBase.Create(checker);
            var item = await _repositoryBase.GetById(id);
            var itemDto = CreateDto(item); 
            return itemDto;
        }
        public new async Task<TDto> GetById(int id) // wtf is this
        {
            var item = await _repositoryBase.GetById(id);
            var itemDto = CreateDto(item);
            return itemDto;
        }
        public async Task<bool> Update(TDto updateData)
        {
            var updateBoard = CreatePoco(updateData);
            return await _repositoryBase.Update(updateBoard);
        }

        public Task<bool> PartialUpdate(int id, TDto patch)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            var getBoardToDelete = _repositoryBase.GetById(id).Result;
            return await _repositoryBase.Delete(getBoardToDelete);
        }
        private TEntity CreatePoco(TDto item)
        {
            return _mapper.Map<TEntity>(item);
        }
        private TDto CreateDto(TEntity item)
        {
            return _mapper.Map<TDto>(item);
        }
    }
}
