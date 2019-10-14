using System;
using board;
using chess;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch match = new ChessMatch();

                while (!match.finished)
                {
                    Console.Clear();
                    Screen.printBoard(match.board);

                    Console.WriteLine();
                    Console.Write("Origin: ");
                    Position origin = Screen.readChessPosition().toPosition();

                    bool[,] possiblePositions = match.board.piece(origin).possibleMovements();

                    Console.Clear();
                    Screen.printBoard(match.board, possiblePositions);

                    Console.Write("Destiny: ");
                    Position destiny = Screen.readChessPosition().toPosition();

                    match.executeMoviment(origin, destiny);
                }
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
