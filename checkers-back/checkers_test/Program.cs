using System;
using System.Collections.Generic;

namespace checkers_test
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new Square[8, 8]; // white square - 0, black - 1
            List<Square> playableSquares = new List<Square>();
            PopulateBoard(board);
            //AddStartingCheckers(board);
            board[5,4].Checker = new Checker(0);
            board[3, 4].Checker = new Checker(1);
            board[1,4].Checker = new Checker(1);
            board[1,2].Checker=new Checker(1);

            GetLines(board, new Square(0, 0, 7), playableSquares);

            foreach (var playableSquare in playableSquares)
            {
                //Console.WriteLine("{0,-2} {1,-2}", playableSquare.Y, playableSquare.X);
            }
            if (playableSquares.Count == 0)
            {
                Console.WriteLine("Tuscias");
            }


            List<Move> moves = new List<Move>();
            moves.AddRange(FreeMoves(board, new Square(1,3,4)));
            moves.AddRange(Enemy(board, new Square(1, 3, 4)));
            foreach (var move in moves)
            {
                Console.WriteLine("{0,-2} {1,-2}", move.DestY, move.DestX);
            }

            Console.ReadKey();
        }

        static void SquaresToGoForWhites(Square[,] board)
        {

        }

        static void GetMoves(Square[,] board, Square source, List<Square> moves)
        {

        }

        static List<Move> FreeMoves(Square[,] board, Square source)
        {
            List<Move> movys = new List<Move>();
            for (int i = -1; i < 2; i += 2)
            {
                for (int j = -1; j < 2; j += 2)
                {
                    if (source.X + i >= 0 && source.X + i <= 7 && source.Y + j >= 0 && source.Y + j <= 7)
                    {
                        if (board[source.Y + j, source.X + i].Checker == null)
                        {
                            if ((source.Color == 0 && j < 0)
                                || source.Color == 1 && j > 0)
                            {
                                var move = new Move
                                {
                                    SourceX = source.X,
                                    SourceY = source.Y,
                                    DestX = source.X + i,
                                    DestY = source.Y + j,
                                    Free = true
                                };
                                movys.Add(move);
                            }
                        }
                    }
                }
            }

            return movys;
            
        }

        private static IEnumerable<Move> Enemy(Square[,] board, Square source)
        {
            //board[source.Y, source.X].Been = true;
            var movys = new List<Move>();
            for (var i = -1; i < 2; i += 2)
            {
                for (var j = -1; j < 2; j += 2)
                {
                    if (source.X + i < 0 || source.X + i > 7 || source.Y + j < 0 || source.Y + j > 7) continue;
                    if (board[source.Y + j, source.X + i].Checker == null ||
                        board[source.Y + j, source.X + i].Checker.Color == source.Color || source.Y + j * 2 > 7 ||
                        source.X + i * 2 > 7 || source.Y + j * 2 < 0 || source.X + i * 2 < 0 ||
                        board[source.Y + j * 2, source.X + i * 2].Checker != null) continue;
                    var move = new Move
                    {
                        SourceX = source.X,
                        SourceY = source.Y,
                        DestX = source.X + i * 2,
                        DestY = source.Y + j * 2,
                        Free = false,
                        KnockX = source.X + i,
                        KnockY = source.Y + j
                    };
                    movys.Add(move);
                    //movys.Add(board[source.Y + j*2, source.X + i*2]);
                    //movys.AddRange(Enemy(board, new Square(source.Color, source.X + i * 2, source.Y + j * 2)));
                }
            }

            return movys;
        }

        private static void GetLines(Square[,] board, Square source, List<Square> lines)
        {          
            /*for (int i = 0; i < Math.Min(source.X, source.Y); i++)
            {
                lines.Add(board[source.Y - i - 1, source.X - i - 1]);
            }
            for (int i = 0; i < Math.Min(7 - source.X, source.Y); i++)
            {
                lines.Add(board[source.Y - i - 1, source.X + i + 1]);
            }
            for (int i = 0; i < Math.Min(source.X, 7 - source.Y); i++)
            {
                lines.Add(board[source.Y + i + 1, source.X - i - 1]);
            }
            for (int i = 0; i < Math.Min(7 - source.X, 7 - source.Y); i++)
            {
                lines.Add(board[source.Y + i + 1, source.X + i + 1]);
            }*/

            for (var i = -1; i < 2; i += 2)
            {
                for (var j = -1; j < 2; j += 2)
                {
                    GetLine(board, source, lines, i, j);
                }
            }
        }

        private static void GetLine(Square[,] board, Square source, List<Square> lines, int directionX, int directionY)
        {
            for (var i = 0; i < Convert.ToInt32(Math.Min((1+directionX)*3.5 - source.X*directionX, (1 + directionY) * 3.5 - source.Y * directionY)); i++)
            {
                if (i == 0 && ((board[source.Y + (i + 1) * directionY, source.X + (i + 1) * directionX].Checker != null
                                && board[source.Y + (i + 1) * directionY, source.X + (i + 1) * directionX].Checker.Color == source.Color)
                    || (directionY == -1 && source.Color == 1)
                    || (directionY == 1 && source.Color == 0)))
                {
                    break;
                }

                if (i == 0 && board[source.Y + (i + 1) * directionY, source.X + (i + 1) * directionX].Checker != null
                           && board[source.Y + (i + 1) * directionY, source.X + (i + 1) * directionX].Checker.Color != source.Color)
                {

                }

                lines.Add(board[source.Y + (i + 1) * directionY, source.X + (i + 1) * directionX]);
            }
        }

        static void GetPlayableSquares(Square[,] board, List<Square> playableSquares)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j].Color == 1)
                    {
                        playableSquares.Add(board[i,j]);
                    }
                }
            }
        }
        static void PopulateBoard(Square[,] board)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    board[i,j] = new Square((i+j)%2, j, i);
                }
            }
        }

        static void AddStartingCheckers(Square[,] board)
        {
            Checker checker;
            // to top black ones
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((i + j) % 2 == 1)
                    {
                        checker = new Checker(1);
                        board[i,j].SetChecker(checker);
                    }
                }
            }

            // to bottom white ones
            for (int i = 5; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((i + j) % 2 == 1)
                    {
                        checker = new Checker(0);
                        board[i, j].SetChecker(checker);
                    }
                }
            }
        }
    }
}
