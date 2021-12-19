using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkers.Infrastructure.DataBase.Models;
using checkers.Models;

namespace checkers.Algorithms
{
    public static class Methods
    {
        public static void SomeMethod()
        {

        }

        public static void GetAllPossibleMoves(Board board, Square square)
        {

        }

        public static List<Square> GetNearFreeSquares(Board board, Square square)
        {
            /*List<Square> nearSquares;
            if(square.Checker.Color)
                board.Squares[]*/
            return new List<Square>();
        }

        public static BoardDto Populate(BoardDto board)
        {
            board.Squares = new List<SquareDto>();
            for (int i = 0; i < 8; i++)
            {            
                for (int j = 0; j < 8; j++)
                {
                    // do need to put board id?
                    SquareDto square = new SquareDto(){Color = (i + j) % 2, X = j, Y = i}; // without x y ?
                    if ((i + j) % 2 != 0 && (i < 3 || i > 4)) // puts checker
                    {
                        CheckerDto checker = new CheckerDto {Color = 1 - i / 4};
                        square.Checker = checker;
                    }
                    board.Squares.Add(square);
                }
            }
            return board;
        }
    }
}
