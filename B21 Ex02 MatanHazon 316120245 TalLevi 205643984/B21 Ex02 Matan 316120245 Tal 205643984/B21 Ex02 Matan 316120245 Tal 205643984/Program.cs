namespace B21_Ex02_Matan_316120245_Tal_205643984
{
    using System;

    public class Program
    {
        public static void Main()
        {
            GameBoard board = new GameBoard();

            Console.WriteLine("Tic Tac Toe Game");
            board.SetupBoard();
            board.SetupPlayers();
            board.PrintBoard();
            board.GameLoop();
        }
    }
}
