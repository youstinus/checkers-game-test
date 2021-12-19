using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkers.Infrastructure.DataBase.Models;

namespace checkers.Models
{
    public class SquareDto : BaseDto
    {
        public int Color { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public CheckerDto Checker { get; set; } // need?
        public int? CheckerId { get; set; }
        public int BoardId { get; set; }
    }
}
