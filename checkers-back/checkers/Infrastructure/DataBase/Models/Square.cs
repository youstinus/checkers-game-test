using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace checkers.Infrastructure.DataBase.Models
{
    public class Square : BaseEntity
    {
        public int Color { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Checker Checker { get; set; }
        public int? CheckerId { get; set; }
        public int BoardId { get; set; }
    }
}
