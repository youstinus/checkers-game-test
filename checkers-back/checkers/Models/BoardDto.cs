using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkers.Infrastructure.DataBase.Models;

namespace checkers.Models
{
    public class BoardDto : BaseDto
    {
        public ICollection<SquareDto> Squares { get; set; }
        //public Square[][] Squares { get; set; }
    }
}
