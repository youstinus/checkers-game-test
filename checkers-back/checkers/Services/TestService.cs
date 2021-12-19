using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using checkers.Infrastructure.DataBase;
using checkers.Infrastructure.DataBase.Models;
using checkers.Infrastructure.Repositories.Interfaces;
using checkers.Models;

namespace checkers.Services
{
    public class TestService : ServiceBase<SquareDto, Square>
    {
        public TestService(IMapper mapper, IRepository<Square> repositoryBase) : base(mapper, repositoryBase)
        {
        }
    }
}
