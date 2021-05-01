﻿namespace B21_Ex02_Matan_316120245_Tal_205643984
{
    using System;
    using System.Collections.Generic;
    class GameBoard
    {

        private string[,] m_MatrixBoard;
        private List<Player> m_Players = new List<Player>();

        public string[,] MatrixBoard
        {
            get { return m_MatrixBoard; }
            set { m_MatrixBoard = value; }
        }
        public List<Player> Players
        {
            get { return m_Players; }
            set { m_Players = value; }
        }


        public void SetupBoard()
        {
            bool validInputFlag = true;
            int boardSize = 0;
            Console.WriteLine("Hello Player One ! Please enter number of board size(range is 3-9) :");
            while (validInputFlag == true)
            {

                boardSize = Convert.ToInt16(Console.ReadLine());
                if (3<=boardSize && boardSize<=9)
                {
                    validInputFlag = false;
                }
                else
                {
                    Console.WriteLine("Board must be square, from 3x3 to 9x9, Please try again :");
                }
            }
            m_MatrixBoard = new string[boardSize, boardSize];
        }

        public void SetupPlayers()
        {
            bool validInput = true;
            this.m_Players.Add(new HumanPlayer("Player 1", " X"));
            Console.WriteLine("Please press 1 for play against Human Player, and 2 if you want to play agains the computer :");

            while (validInput == true)
            {
                int oponent = Convert.ToInt16(Console.ReadLine());
                if (oponent == 1)
                {
                    this.m_Players.Add(new HumanPlayer("Player 2", " O"));
                    Console.WriteLine("You choosed human player, GOOD LUCK !");
                    validInput = false;

                }
                else if (oponent == 2)
                {
                    this.m_Players.Add(new AIPlayer("AIPlayer 2", " O"));
                    Console.WriteLine("You choosed AI computer player, GOOD LUCK !");
                    validInput = false;
                }
                else
                {
                    Console.WriteLine("WRONG Input, please chose 1 for human player, 2 for comuter player !");
                }
            }
        }


        public void PrintBoard()
        {
            int rowLength = m_MatrixBoard.GetLength(0);
            for (int j = 0; j < rowLength; j++)
            {
                Console.Write(string.Format("{0,4}", j+1));
            }
            Console.Write(Environment.NewLine);
            for (int i = 0; i < rowLength; i++)
            {
                Console.Write(string.Format("{0}|", i+1));
                for (int j = 0; j < rowLength; j++)
                {
                    Console.Write(string.Format("{0,-3}|", m_MatrixBoard[i, j]));
                }
                Console.Write(Environment.NewLine);
                for (int j = 0; j < rowLength; j++)
                {
                    Console.Write(string.Format("{0}", "===="));
                }
                Console.Write(string.Format("{0}", "=="));
                Console.Write(Environment.NewLine);
            }
        }


        public void GameLoop()
        {
            bool keepPlaying = true;
            while (keepPlaying == true)
            {
                for (int p = 0; p < this.m_Players.Count; p++)
                {
                    Player player = this.m_Players[p];
                    player.Move(this);
                    Ex02.ConsoleUtils.Screen.Clear();
                    this.PrintBoard();
                    this.checkIfGameOver(out keepPlaying);
                    if(keepPlaying == false)
                    {
                        bool flagForInput = true;
                        this.PrintRecord();
                        Console.WriteLine("Do you want Keep Playing ? (y | n)");
                        while (flagForInput == true)
                        {
                            string key = Console.ReadLine();
                            if (key == "n")
                            {
                                flagForInput = false; ; //some way to exit the game other than closing window.
                            }
                            else if (key == "y")
                            {
                                keepPlaying = true;
                                flagForInput = false;
                                this.CleanBoard();
                                Ex02.ConsoleUtils.Screen.Clear();
                                this.PrintBoard();
                            }
                            else
                            {
                                Console.WriteLine("WRONG INPUT ! , Do you want Keep Playing ? (y | n)");
                            }


                        }
                        break;

                    }
                }
                
            }
            
        }

        public void PrintRecord()
        {
            Console.WriteLine(string.Format(@"Player 1 number of wins is {0} 
Player 2 number of wins is {1}", m_Players[0].Wins, m_Players[1].Wins));
        }

        public void CleanBoard()
        {
            Array.Clear(m_MatrixBoard, 0, m_MatrixBoard.Length);
            
        }

        public void checkIfGameOver(out bool keepPlaying)
        {
            keepPlaying = true;
            int boardSize = this.m_MatrixBoard.GetLength(0);
            checkIfLoseRow(boardSize, out keepPlaying);
            if(keepPlaying == true)
            {
                checkIfLoseCol(boardSize, out keepPlaying);
            }
            if (keepPlaying == true)
            {
                checkIfLoseDiagonal(boardSize, out keepPlaying);
            }
            if (keepPlaying == true)
            {
                checkIfFull(out keepPlaying);
            }

        }

        public void checkIfLoseRow(int size , out bool keepPlaying)
        {
            keepPlaying = true;
            bool foundLose = true;
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = 0; j < size - 1; j++)
                {
                    if (this.m_MatrixBoard[i, j] != this.m_MatrixBoard[i, j + 1] || this.m_MatrixBoard[i, j] == null)
                    {
                        foundLose = false;
                        break;
                    }
                }
                if (foundLose == true)
                {
                    keepPlaying = false;
                    if (this.m_Players[0].Mark == this.m_MatrixBoard[i, 0])
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
        public void checkIfLoseCol(int size, out bool keepPlaying)
        {
            keepPlaying = true;
            bool foundLose = true;
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = 0; j < size - 1; j++)
                {
                    if (this.m_MatrixBoard[j, i] != this.m_MatrixBoard[j + 1, i] || this.m_MatrixBoard[j, i] == null)
                    {
                        foundLose = false;
                        break;
                    }
                }
                if (foundLose == true)
                {
                    keepPlaying = false;
                    if (this.m_Players[0].Mark == this.m_MatrixBoard[i, 0])
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
        public void checkIfLoseDiagonal(int size, out bool keepPlaying)
        {
            keepPlaying = true;
            bool foundLoseDiagonal1 = true;
            bool foundLoseDiagonal2 = true;
            for (int i = 0; i < size - 1; i++)
            {
              
                if (this.m_MatrixBoard[i, i] != this.m_MatrixBoard[i + 1, i + 1] || this.m_MatrixBoard[i, i] == null)
                {
                    foundLoseDiagonal1 = false;
                }
                if (this.m_MatrixBoard[size - 1 - i, i] != this.m_MatrixBoard[size - 2 - i, i + 1] || this.m_MatrixBoard[size - 1 - i, i] == null)
                {
                    foundLoseDiagonal2 = false;
                }

            }

            if (foundLoseDiagonal1 == true)
            {
                keepPlaying = false;
                if (this.m_Players[0].Mark == this.m_MatrixBoard[0, 0])
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
                keepPlaying = false;
                if (this.m_Players[0].Mark == this.m_MatrixBoard[size - 1, 0])
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
        public void checkIfFull(out bool keepPlaying)
        {
            keepPlaying = true;
            foreach (string i in this.m_MatrixBoard)
            {
                if(i == null)
                {
                    return;
                }
            }

            Console.WriteLine("Game reuslt is EVEN");
            keepPlaying = false;
        }

        
        public void CheckIfQuit(string input)
        {
            if (input == "Q")
            {
                Environment.Exit(0);
            }
            return;
        }

    }
}
