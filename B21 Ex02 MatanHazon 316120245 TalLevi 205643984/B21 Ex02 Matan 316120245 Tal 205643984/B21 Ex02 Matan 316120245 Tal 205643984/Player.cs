namespace B21_Ex02_Matan_316120245_Tal_205643984
{
    abstract class Player
    {
        private string m_PlayerName;
        private string m_Mark;
        private int m_Wins;
        public string PlayerName
        {
            get { return m_PlayerName; }
            set { m_PlayerName = value; }
        }
        public string Mark
        {
            get { return m_Mark; }
            set { m_Mark = value; }
        }
        public int Wins
        {
            get { return m_Wins; }
            set { m_Wins = value; }
        }

        public virtual void Move(GameBoard gameBoard)
        {
        }
    }
}
