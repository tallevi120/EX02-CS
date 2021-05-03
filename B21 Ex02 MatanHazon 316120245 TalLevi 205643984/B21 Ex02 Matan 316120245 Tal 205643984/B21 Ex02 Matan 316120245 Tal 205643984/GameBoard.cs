namespace B21_Ex02_Matan_316120245_Tal_205643984
{
    using System;
    using System.Collections.Generic;

    public class GameBoard
    {
        private string[,] m_MatrixBoard;
        private List<Player> m_Players = new List<Player>();
        private GameBoardUI m_BoardUI = new GameBoardUI();

        public string[,] MatrixBoard
        {
            get 
            { 
                return m_MatrixBoard; 
            }

            set 
            { 
                m_MatrixBoard = value; 
            }
        }

        public List<Player> Players
        {
            get 
            { 
                return m_Players; 
            }

            set 
            { 
                m_Players = value; 
            }
        }

        public void SetupBoard(short i_BoardSize)
        {
            m_MatrixBoard = new string[i_BoardSize, i_BoardSize];
        }

        public void SetupPlayers(short i_Oponent)
        {
            this.m_Players.Add(new HumanPlayer("Player 1", " X"));
            if(i_Oponent == 1)
            {
                this.m_Players.Add(new HumanPlayer("Player 2", " O"));
            }
            else if(i_Oponent == 2)
            {
                this.m_Players.Add(new AIPlayer("AIPlayer 2", " O"));
            }
        }

        public void GameLoop()
        {
            bool keepPlaying = true;
            Player player;

            while (keepPlaying == true)
            {
                for(int p = 0 ; p < this.m_Players.Count ; p++)
                {
                    player = this.m_Players[p];
                    player.Move(this);
                    Ex02.ConsoleUtils.Screen.Clear();
                    m_BoardUI.PrintBoard(this.m_MatrixBoard);
                    this.checkIfGameOver(out keepPlaying);
                    if(keepPlaying == false)
                    {
                        m_BoardUI.PrintRecord(this.m_Players);
                        ///some way to exit the game other than closing window.
                        if(m_BoardUI.IfContinue())
                        {
                            keepPlaying = true;
                            this.cleanBoard();
                            Ex02.ConsoleUtils.Screen.Clear();
                            m_BoardUI.PrintBoard(this.m_MatrixBoard); 
                        }

                        break;
                    }
                }
            }
        }

        private void cleanBoard()
        {
            Array.Clear(m_MatrixBoard, 0, m_MatrixBoard.Length);
        }

        private void checkIfGameOver(out bool io_KeepPlaying)
        {
            io_KeepPlaying = true;
            int boardSize = this.m_MatrixBoard.GetLength(0);

            checkIfLoseRow(boardSize, out io_KeepPlaying);
            if(io_KeepPlaying == true)
            {
                checkIfLoseCol(boardSize, out io_KeepPlaying);
            }

            if(io_KeepPlaying == true)
            {
                checkIfLoseDiagonal(boardSize, out io_KeepPlaying);
            }

            if(io_KeepPlaying == true)
            {
                checkIfFull(out io_KeepPlaying);
            }
        }

        private void checkIfLoseRow(int size, out bool o_KeepPlaying)
        {
            o_KeepPlaying = true;
            bool foundLose = true;

            for(int i = 0 ; i < size ; i++)
            {
                foundLose = true;
                for(int j = 0 ; j < size - 1 ; j++)
                {
                    if(this.m_MatrixBoard[i, j] != this.m_MatrixBoard[i, j + 1] || this.m_MatrixBoard[i, j] == null)
                    {
                        foundLose = false;
                        break;
                    }
                }

                if(foundLose == true)
                {
                    o_KeepPlaying = false;
                    if(this.m_Players[0].Mark == this.m_MatrixBoard[i, 0])
                    {
                        Console.WriteLine("Game reuslt is - Player 2 WINS");
                        this.m_Players[1].Wins++;                       
                    }
                    else
                    {
                        Console.WriteLine("Game reuslt is - Player 1 WINS");
                        this.m_Players[0].Wins++;
                    }

                    break;
                }
            }
        }

        private void checkIfLoseCol(int size, out bool o_KeepPlaying)
        {
            o_KeepPlaying = true;
            bool foundLose = true;

            for(int i = 0 ; i < size ; i++)
            {
                foundLose = true;
                for(int j = 0 ; j < size - 1 ; j++)
                {
                    if(this.m_MatrixBoard[j, i] != this.m_MatrixBoard[j + 1, i] || this.m_MatrixBoard[j, i] == null)
                    {
                        foundLose = false;
                        break;
                    }
                }

                if(foundLose == true)
                {
                    o_KeepPlaying = false;
                    if(this.m_Players[0].Mark == this.m_MatrixBoard[i, 0])
                    {
                        Console.WriteLine("Game reuslt is - Player 2 WINS");
                        this.m_Players[1].Wins++;
                    }
                    else
                    {
                        Console.WriteLine("Game reuslt is - Player 1 WINS");
                        this.m_Players[0].Wins++;
                    }

                    break;
                }
            }
        }

        private void checkIfLoseDiagonal(int size, out bool o_KeepPlaying)
        {
            o_KeepPlaying = true;
            bool foundLoseDiagonal1 = true;
            bool foundLoseDiagonal2 = true;

            for(int i = 0 ; i < size - 1 ; i++)
            {
                if(this.m_MatrixBoard[i, i] != this.m_MatrixBoard[i + 1, i + 1] || this.m_MatrixBoard[i, i] == null)
                {
                    foundLoseDiagonal1 = false;
                }

                if(this.m_MatrixBoard[size - 1 - i, i] != this.m_MatrixBoard[size - 2 - i, i + 1] || 
                    this.m_MatrixBoard[size - 1 - i, i] == null)
                {
                    foundLoseDiagonal2 = false;
                }
            }

            if(foundLoseDiagonal1 == true)
            {
                o_KeepPlaying = false;
                if(this.m_Players[0].Mark == this.m_MatrixBoard[0, 0])
                {
                    Console.WriteLine("Game reuslt is - Player 2 WINS");
                    this.m_Players[1].Wins++;
                }
                else
                {
                    Console.WriteLine("Game reuslt is - Player 1 WINS");
                    this.m_Players[0].Wins++;
                }
            }
            else if(foundLoseDiagonal2 == true)
            {
                o_KeepPlaying = false;

                if(this.m_Players[0].Mark == this.m_MatrixBoard[size - 1, 0])
                {
                    Console.WriteLine("Game reuslt is - Player 2 WINS");
                    this.m_Players[1].Wins++;
                }
                else
                {
                    Console.WriteLine("Game reuslt is - Player 1 WINS");
                    this.m_Players[0].Wins++;
                }
            }
        }

        private void checkIfFull(out bool o_KeepPlaying)
        {
            o_KeepPlaying = true;

            foreach(string i in this.m_MatrixBoard)
            {
                if(i == null)
                {
                    return;
                }
            }

            Console.WriteLine("Game reuslt is EVEN");
            o_KeepPlaying = false;
        }
        
        internal void CheckIfQuit(string i_Input)
        {
            if(i_Input == "Q")
            {
                Environment.Exit(0);
            }

            return;
        }
    }
}
