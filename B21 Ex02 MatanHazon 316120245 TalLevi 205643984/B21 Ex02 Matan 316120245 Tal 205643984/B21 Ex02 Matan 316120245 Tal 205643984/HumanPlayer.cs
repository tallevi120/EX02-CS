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
            short row;
            short col;

            row = GameBoardUI.GetRowAndCol(i_Board, this, out col);
            i_Board.MatrixBoard[row, col] = this.Mark;  
        }
    }
}
