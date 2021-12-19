using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkers.Infrastructure.DataBase;
using checkers.Infrastructure.DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace checkers.Infrastructure.Repositories
{
    // not usable
    public class CheckerRepository : RepositoryBase<Checker>
    {
        protected override DbSet<Checker> ItemSet { get; }
        public CheckerRepository(CheckersDbContext context) : base(context)
        {
            ItemSet = context.Checkers;
        } 
    }
}
