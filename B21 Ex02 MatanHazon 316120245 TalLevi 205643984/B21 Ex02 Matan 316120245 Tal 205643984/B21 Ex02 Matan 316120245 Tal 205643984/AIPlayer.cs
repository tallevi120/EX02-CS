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
            bool validCellFlag = true;
            bool ifExist = false;
            short timerForAI = 0;

            while(validCellFlag == true)
            {
                int row = rnd.Next(0, (int)(i_Board.MatrixBoard.Length / Math.Sqrt(i_Board.MatrixBoard.Length)));
                int col = rnd.Next(0, (int)(i_Board.MatrixBoard.Length / Math.Sqrt(i_Board.MatrixBoard.Length)));

                if(i_Board.MatrixBoard[row, col] == null)
                {
                    timerForAI++;
                    if(timerForAI <= 100)
                    {
                        FindInRow(i_Board, row, " O", out ifExist);
                        if(ifExist == true)
                        {
                            continue;
                        }

                        FindInCol(i_Board, col, " O", out ifExist);
                        if(ifExist == true)
                        {
                            continue;
                        }

                        i_Board.MatrixBoard[row, col] = this.Mark;
                        validCellFlag = false;
                    }
                    else
                    {
                        i_Board.MatrixBoard[row, col] = this.Mark;
                        validCellFlag = false;
                    }
                }
                else
                {
                    continue;
                }
            }            
        }

        public void FindInRow(GameBoard i_Board, int row, string i_Input, out bool ifExist)
        {
            ifExist = false;
            for(int i = 0 ; i < i_Board.MatrixBoard.GetLength(0) ; i++)
            {
                if(i_Board.MatrixBoard[row,i] == i_Input)
                {
                    ifExist = true;
                    break;
                }
            }
        }

        public void FindInCol(GameBoard i_Board, int col, string i_Input, out bool ifExist)
        {
            ifExist = false;
            for(int i = 0 ; i < i_Board.MatrixBoard.GetLength(0) ; i++)
            {
                if(i_Board.MatrixBoard[i, col] == i_Input)
                {
                    ifExist = true;
                    break;
                }
            }
        }
    }
}
