using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex02_Matan_316120245_Tal_205643984
{
    class GameBoard
    {

        public string[,] matrix1;
        List<Player> Players = new List<Player>();


        public GameBoard()
        {
           
        }

        public void SetupBoard()
        {
            bool validInputFlag = true;
            int row = 0;
            int col = 0;
            while (validInputFlag == true)
            {
                Console.WriteLine("Hello Player One ! Please enter number of board rows :");
                row = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Hello Player One ! Please enter number of board columns :");
                col = Convert.ToInt16(Console.ReadLine());
                if (row == col && 3<=row && row<=9)
                {
                    validInputFlag = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Board must be square, from 3x3 to 9x9 :");
                    continue;
                }
            }
            matrix1 = new string[row, col];
        }

        public void SetupPlayers()
        {
            this.Players.Add(new HumanPlayer("Player 1", "X"));
            Console.WriteLine("Please press 1 for play against Human Player, and 2 if you want to play agains the computer :");
            int oponent = Convert.ToInt16(Console.ReadLine());
            if (oponent == 1)
            {
                this.Players.Add(new HumanPlayer("Player 2", "O"));
                Console.WriteLine("You choosed human player, GOOD LUCK !");

            }
            else if (oponent == 2)
            {
                this.Players.Add(new AIPlayer("AIPlayer 2", "O"));
                Console.WriteLine("You choosed AI computer player, GOOD LUCK !");
            }
        }


        public void Print()
        {
            int rowLength = matrix1.GetLength(0);
            for (int j = 0; j < rowLength; j++)
            {
                Console.Write(string.Format("{0,4}", j+1));
            }
            Console.Write(Environment.NewLine + Environment.NewLine);
            for (int i = 0; i < rowLength; i++)
            {
                Console.Write(string.Format("{0}|", i+1));
                for (int j = 0; j < rowLength; j++)
                {
                    Console.Write(string.Format("{0,-3}|", matrix1[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
                for (int j = 0; j < rowLength; j++)
                {
                    Console.Write(string.Format("{0}", "==="));
                }
                Console.Write(string.Format("{0}", "="));
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }


        public void GameLoop()
        {
            while (true)
            {
                for (var p = 0; p < this.Players.Count; p++)
                {
                    var player = this.Players[p];
                    player.Move(this);
                    Ex02.ConsoleUtils.Screen.Clear();
                    this.Print();
                    //PlayerMove(player);
                }
                

                //Console.WriteLine("Quit? (y | n)");
                //var key = Console.ReadKey();
                //if (key.KeyChar.ToString().ToLower() == "y")
                //    break; //some way to exit the game other than closing window.
            }
        }

        public void PlayerMove(Player player)
        {
            bool validCellFlag = true;
            while (validCellFlag == true)
            {
                Console.WriteLine(string.Format("{0}'s turn", player.m_PlayerName));

                Console.WriteLine("Please enter row");
                int row = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Please enter column");
                int col = Convert.ToInt16(Console.ReadLine());

                //if (board.Move(player, row, col))
                //    break;
                if(matrix1[row, col] == null)
                {
                    matrix1[row, col] = player.m_Mark;
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
