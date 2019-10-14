using System;
using board;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);
            Console.WriteLine();

            Screen.printScreen(board);
        }
    }
}
