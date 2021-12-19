using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace checkers.Infrastructure.DataBase.Models
{
    public class Board : BaseEntity
    {
        public ICollection<Square> Squares { get; set; }
        //public Square[][] Squares { get; set; }
    }
}
