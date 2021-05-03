namespace B21_Ex02_Matan_316120245_Tal_205643984
{
    using System;

    public class HumanPlayer : Player
    {
        public HumanPlayer(string i_PlayerName, string i_Mark)
        {
            this.PlayerName = i_PlayerName;
            this.Mark = i_Mark;
            this.Wins = 0;
        }
        
        public override void Move(GameBoard i_Board)
        {
            bool validCellFlag = true;
            short boardSize = (short)i_Board.MatrixBoard.GetLength(0);
            short row;
            short col;
            string input;

            while(validCellFlag == true)
            {
                Console.WriteLine(string.Format("{0}'s turn, MARK is{1}", this.PlayerName, this.Mark));
                Console.WriteLine("You can press 'Q' to quit the game");
                Console.WriteLine("Please enter row");
                input = Console.ReadLine();
                i_Board.CheckIfQuit(input);
                if(short.TryParse(input, out row)) 
                {
                    row--;
                }
                else
                {
                    row = -1;
                }

                Console.WriteLine("Please enter column");
                input = Console.ReadLine();
                i_Board.CheckIfQuit(input);
                if(short.TryParse(input, out col))
                {
                    col--;
                }
                else
                {
                    col = -1; 
                }

                if(row == -1 || col == -1)
                {
                    Console.WriteLine("WRONG INPUT ! please put numbers inside the range !");
                    continue;
                }
                else if(row >= boardSize || col >= boardSize || row < 0 || col < 0)
                {
                    Console.WriteLine("Out of bounds of the board please put numbers inside the range !");
                    continue;
                }

                if(i_Board.MatrixBoard[row, col] == null)
                {
                    i_Board.MatrixBoard[row, col] = this.Mark;
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
