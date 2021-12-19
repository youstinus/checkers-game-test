using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace checkers.Infrastructure.DataBase.Models
{
    public class Checker : BaseEntity
    {
        public int Color { get; set; } // white - 0, black - 1
        public bool Queen { get; set; }
        public Checker(int color)
        {
            Color = color;
            Queen = false;
        }
    }
}
