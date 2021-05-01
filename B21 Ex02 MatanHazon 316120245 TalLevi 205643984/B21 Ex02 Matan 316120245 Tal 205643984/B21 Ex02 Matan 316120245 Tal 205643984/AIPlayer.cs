namespace B21_Ex02_Matan_316120245_Tal_205643984
{
    using System;
    class AIPlayer : Player
    {


        public AIPlayer(string _playerName, string _mark)
        {
            this.PlayerName = _playerName;
            this.Mark = _mark;
            this.Wins = 0;
        }

        public override void Move(GameBoard board)
        {
            Random rnd = new Random();
            bool validCellFlag = true;
            while (validCellFlag == true)
            {
                Console.WriteLine(string.Format("{0}'s turn, MARK is{1}", this.PlayerName, this.Mark));
                int row = rnd.Next(0, (int)(board.MatrixBoard.Length / Math.Sqrt(board.MatrixBoard.Length)));
                int col = rnd.Next(0, (int)(board.MatrixBoard.Length / Math.Sqrt(board.MatrixBoard.Length)));
                if (board.MatrixBoard[row, col] == null)
                {
                    board.MatrixBoard[row, col] = this.Mark;
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
