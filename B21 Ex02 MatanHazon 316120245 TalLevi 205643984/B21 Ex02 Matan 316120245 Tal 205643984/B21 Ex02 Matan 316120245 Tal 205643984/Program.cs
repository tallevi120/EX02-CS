using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex02_Matan_316120245_Tal_205643984
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Tic Tac Toe Game");
            //HumanPlayer playerOne = new
            //HumanPlayer("Player 1", "X");
            GameBoard board = new GameBoard();
            board.SetupPlayers();
            board.SetupBoard();
            board.Print();
            board.GameLoop();


        }
    }
}
