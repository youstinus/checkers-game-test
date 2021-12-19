using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace checkers.Models
{
    public class CheckerDto : BaseDto
    {
        public int Color { get; set; } // white - 0, black - 1
        public bool Queen { get; set; }

    }
}
