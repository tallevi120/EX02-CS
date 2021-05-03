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
            short timerForAI = 0;
            short countHowManyOInRow;
            short countHowManyOInCol;
            short countHowManyOInDiagonal;
            short countHowManyXInRow;
            short countHowManyXInCol;
            short countHowManyXInDiagonal;
            int sizeOfMatrix = i_Board.MatrixBoard.GetLength(0);

            while(validCellFlag == true)
            {
                int row = rnd.Next(0, (int)(i_Board.MatrixBoard.Length / Math.Sqrt(i_Board.MatrixBoard.Length)));
                int col = rnd.Next(0, (int)(i_Board.MatrixBoard.Length / Math.Sqrt(i_Board.MatrixBoard.Length)));

                if(i_Board.MatrixBoard[row, col] == null)
                {
                    timerForAI++;
                    ///The number of options that the AI has to solve in a smart way and if not then it works randomly.
                    if (timerForAI <= 1000)
                    {
                        countHowManyXInDiagonal = 0; ///deafult value for the "if" in the method.
                        countHowManyOInDiagonal = 1; ///deafult value for the "if" in the method.
                        if(row == col)
                        {
                            countHowManyOInDiagonal = findInDiagonal(i_Board, " O", out countHowManyXInDiagonal);
                        }

                        countHowManyOInRow = findInRow(i_Board, row, " O", out countHowManyXInRow);
                        countHowManyOInCol = findInCol(i_Board, col, " O", out countHowManyXInCol);
                        if(countHowManyOInRow < sizeOfMatrix - 1)
                        {
                            if(countHowManyOInCol < sizeOfMatrix - 1)
                            {
                                if(countHowManyXInRow >= sizeOfMatrix / 2 || countHowManyXInCol >= sizeOfMatrix / 2 ||
                                    countHowManyXInDiagonal >= sizeOfMatrix / 2)
                                {
                                    if(countHowManyOInRow == 0 || countHowManyOInCol == 0 || countHowManyOInDiagonal == 0)
                                    {
                                        continue;
                                    }
                                }

                                if(countHowManyXInRow >= countHowManyOInRow || countHowManyXInCol >= countHowManyOInCol ||
                                    countHowManyXInDiagonal >= countHowManyOInDiagonal)
                                {
                                    if (countHowManyOInRow == 0 || countHowManyOInCol == 0 || countHowManyOInDiagonal == 0)
                                    {
                                        continue;
                                    }
                                }

                                i_Board.MatrixBoard[row, col] = this.Mark;
                                validCellFlag = false;
                            }
                        }
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

        private short findInRow(GameBoard i_Board, int row, string i_Input, out short countHowManyX)
        {
            countHowManyX = 0;
            short countHowManyO = 0;

            for(int i = 0 ; i < i_Board.MatrixBoard.GetLength(0) ; i++)
            {
                if(i_Board.MatrixBoard[row, i] == i_Input)
                {
                    countHowManyO++;
                }

                if(i_Board.MatrixBoard[row, i] == " X")
                {
                    countHowManyX++;
                }
            }

            return countHowManyO;
        }

        private short findInCol(GameBoard i_Board, int col, string i_Input, out short countHowManyX)
        {
            countHowManyX = 0;
            short countHowManyO = 0;

            for(int i = 0 ; i < i_Board.MatrixBoard.GetLength(0) ; i++)
            {
                if(i_Board.MatrixBoard[i, col] == i_Input)
                {
                    countHowManyO++;
                }

                if(i_Board.MatrixBoard[i, col] == " X")
                {
                    countHowManyX++;
                }
            }

            return countHowManyO;
        }

        private short findInDiagonal(GameBoard i_Board, string i_Input, out short countHowManyX)
        {
            countHowManyX = 0;
            short countHowManyO = 0;

            for(int i = 0 ; i < i_Board.MatrixBoard.GetLength(0) ; i++)
            {
                if(i_Board.MatrixBoard[i, i] == i_Input)
                {
                    countHowManyO++;
                }

                if(i_Board.MatrixBoard[i, i] == " X")
                {
                    countHowManyX++;
                }
            }

            return countHowManyO;
        }
    }
}
