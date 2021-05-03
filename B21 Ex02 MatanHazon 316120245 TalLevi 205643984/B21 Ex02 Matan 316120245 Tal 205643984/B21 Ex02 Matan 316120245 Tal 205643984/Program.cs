namespace B21_Ex02_Matan_316120245_Tal_205643984
{
    using System;

    public class Program
    {
        public static void Main()
        {
            GameBoard board = new GameBoard();
            GameBoardUI boardUI = new GameBoardUI();

            Console.WriteLine("Tic Tac Toe Game");
            board.SetupBoard(boardUI.GetBoardSize());
            board.SetupPlayers(boardUI.SelectTheOpponent());
            boardUI.PrintBoard(board.MatrixBoard);
            board.GameLoop();
        }
    }
}
