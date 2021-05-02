namespace B21_Ex02_Matan_316120245_Tal_205643984
{
    using System;

    public class AIPlayer : Player
    {
        public AIPlayer(string i_PlayerName, string i_Mark)
        {
            this.PlayerName = i_PlayerName;
            this.Mark = i_Mark;
            this.Wins = 0;
        }

        public override void Move(GameBoard i_Board)
        {
            Random rnd = new Random();
            bool   validCellFlag = true;

            while(validCellFlag == true)
            {
                int row = rnd.Next(0, (int)(i_Board.MatrixBoard.Length / Math.Sqrt(i_Board.MatrixBoard.Length)));
                int col = rnd.Next(0, (int)(i_Board.MatrixBoard.Length / Math.Sqrt(i_Board.MatrixBoard.Length)));

                Console.WriteLine(string.Format("{0}'s turn, MARK is{1}", this.PlayerName, this.Mark));
                if(i_Board.MatrixBoard[row, col] == null)
                {
                    i_Board.MatrixBoard[row, col] = this.Mark;
                    validCellFlag = false;
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
