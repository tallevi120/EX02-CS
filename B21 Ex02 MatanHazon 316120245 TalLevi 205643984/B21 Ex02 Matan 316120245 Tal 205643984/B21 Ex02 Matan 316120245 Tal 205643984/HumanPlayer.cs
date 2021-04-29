using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex02_Matan_316120245_Tal_205643984
{
    struct HumanPlayer
    {
        private string m_PlayerName;
        private string m_Mark;
        private int m_Wins;



        HumanPlayer(string _playerName , string _mark)
        {
            m_PlayerName = _playerName;
            m_Mark = _mark;
            m_Wins = 0;
        }


    }
}
