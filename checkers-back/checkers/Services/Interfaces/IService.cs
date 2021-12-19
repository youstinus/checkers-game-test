using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkers.Infrastructure.DataBase.Models;
using checkers.Models;

namespace checkers.Services.Interfaces
{
    public interface IService<TDto> where TDto : BaseDto
    {
        Task<ICollection<TDto>> GetAll();
        Task<TDto> Create(TDto newItem);
        Task<TDto> GetById(int id);
        Task<bool> Update(TDto updateData);
        Task<bool> Delete(int id);

    }
}
