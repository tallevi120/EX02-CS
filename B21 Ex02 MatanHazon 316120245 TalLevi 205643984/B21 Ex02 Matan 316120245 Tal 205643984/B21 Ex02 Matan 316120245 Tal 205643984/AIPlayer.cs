using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex02_Matan_316120245_Tal_205643984
{
    class AIPlayer : Player
    {


        public AIPlayer(string _playerName, string _mark)
        {
            m_PlayerName = _playerName;
            m_Mark = _mark;
            m_Wins = 0;
        }

        public override void Move(GameBoard board)
        {
            Random rnd = new Random();
            bool validCellFlag = true;
            while (validCellFlag == true)
            {
                Console.WriteLine(string.Format("{0}'s turn", this.m_PlayerName));
                int row = rnd.Next(0, (int)(board.matrix1.Length / Math.Sqrt(board.matrix1.Length)));
                int col = rnd.Next(0, (int)(board.matrix1.Length / Math.Sqrt(board.matrix1.Length)));
                if (board.matrix1[row, col] == null)
                {
                    board.matrix1[row, col] = this.m_Mark;
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
