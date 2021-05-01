using System;
namespace B21_Ex02_Matan_316120245_Tal_205643984
{
    class HumanPlayer : Player
    {

        public HumanPlayer(string _playerName , string _mark)
        {
            this.PlayerName = _playerName;
            this.Mark = _mark;
            this.Wins = 0;
        }
        
        public override void Move(GameBoard board)
        {
            bool validCellFlag = true;
            int boardSize = board.MatrixBoard.GetLength(0);
            while (validCellFlag == true)
            {
                Console.WriteLine(string.Format("{0}'s turn, MARK is{1}", this.PlayerName, this.Mark));
                short row;
                short col;
                Console.WriteLine("Please enter row");
                string input = Console.ReadLine();
                board.CheckIfQuit(input);
                if (Int16.TryParse(input, out row)) 
                {
                    row--;
                }
                else
                {
                    row = -1;
                }
                Console.WriteLine("Please enter column");
                input = Console.ReadLine();
                board.CheckIfQuit(input);
                if (Int16.TryParse(input, out col))
                {
                    col--;
                }
                else
                {
                    col = -1;
                }

                if (row == -1 || col == -1)
                {
                    Console.WriteLine("WRONG INPUT ! please put numbers inside the range !");
                    continue;
                }
                else if(row >= boardSize || col >= boardSize || row < 0 || col < 0)
                {
                    Console.WriteLine("Out of bounds of the board please put numbers inside the range !");
                    continue;
                }
                if (board.MatrixBoard[row, col] == null)
                {
                    board.MatrixBoard[row, col] = this.Mark;
                    validCellFlag = false;
                }
                else
                {
                    Console.WriteLine("Cell already taken, choose again");
                }
            }

        }


    }
}
