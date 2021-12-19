using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkers.Infrastructure.DataBase.Models;

namespace checkers.Algorithms
{
    public class Algo // update methods, patch, create and stuff
    {
        public ICollection<Square> Squares { get; set; }

        public Algo(int id) // get board with but not only id
        {
            Squares = new List<Square>();
            Populate(id);
        }

        private void Populate(int id)
        {
            for (var i = 0; i < 8; i++)
            {
                for (var j = 0; j < 8; j++)
                {
                    var square = new Square() {BoardId = id, Color = (i + j) % 2, X = j, Y = i };
                    if ((i + j) % 2 != 0 && (i < 3 || i > 4)) // puts checker
                    {
                        var checker = new Checker(1 - i/4);
                        square.Checker = checker;
                    }
                    Squares.Add(square);
                }
            }
        }
    }
}
