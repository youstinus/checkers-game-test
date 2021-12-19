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
    public class BoardRepository : RepositoryBase<Board>
    {
        protected override DbSet<Board> ItemSet { get; }
        public BoardRepository(CheckersDbContext context) : base(context)
        {
            ItemSet = context.Boards;
        }
        public override async Task<Board> GetById(int id)
        {
            return await IncludeDependencies(ItemSet)
                .Where(x => x.Id == id)
                .Include(x => x.Squares)
                .ThenInclude(x => x.Checker)
                .FirstOrDefaultAsync();
        }
    }
}
