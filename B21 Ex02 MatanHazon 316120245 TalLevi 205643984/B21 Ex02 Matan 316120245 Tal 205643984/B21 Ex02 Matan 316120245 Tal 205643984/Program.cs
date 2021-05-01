namespace B21_Ex02_Matan_316120245_Tal_205643984
{
    using System;
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Tic Tac Toe Game");
            GameBoard board = new GameBoard();
            board.SetupBoard();
            board.SetupPlayers();
            board.PrintBoard();
            board.GameLoop();

        }
    }
}
