using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkers.Infrastructure.DataBase;
using checkers.Infrastructure.DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace checkers.Infrastructure.Repositories
{
    public class SquareRepository : RepositoryBase<Square>
    {
        protected override DbSet<Square> ItemSet { get; }
        public SquareRepository(CheckersDbContext context) : base(context)
        {
            ItemSet = context.Squares;
        }
        public override async Task<Square> GetById(int id)
        {
            return await IncludeDependencies(ItemSet)
                .Where(x => x.Id == id)
                .Include(a => a.Checker)
                .FirstOrDefaultAsync();
        }
        public override async Task<ICollection<Square>> GetAll()
        {
            return await IncludeDependencies(ItemSet)
                .Include(a => a.Checker)
                .ToArrayAsync();
        }
    }
}
