using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex02_Matan_316120245_Tal_205643984
{
    class HumanPlayer : Player
    {



        public HumanPlayer(string _playerName , string _mark)
        {
            m_PlayerName = _playerName;
            m_Mark = _mark;
            m_Wins = 0;
        }
        public string Name
        {
            get { return m_PlayerName; }
            set { m_PlayerName = value; }
        }
        public string Mark
        {
            get { return m_Mark; }
            set { m_PlayerName = value; }
        }
        public int Wins
        {
            get { return m_Wins; }
            set { m_Wins = value; }
        }
        
        public override void Move(GameBoard board)
        {
            bool validCellFlag = true;
            while (validCellFlag == true)
            {
                Console.WriteLine(string.Format("{0}'s turn", this.m_PlayerName));

                Console.WriteLine("Please enter row");
                int row = (Convert.ToInt16(Console.ReadLine())) -1  ;
                Console.WriteLine("Please enter column");
                int col = (Convert.ToInt16(Console.ReadLine())) -1;


                if (board.matrix1[row, col] == null)
                {
                    board.matrix1[row, col] = this.m_Mark;
                    validCellFlag = false;
                }
                else
                {
                    Console.WriteLine("Cell already taken, choose again");
                    continue;
                }
            }

        }


    }
}
