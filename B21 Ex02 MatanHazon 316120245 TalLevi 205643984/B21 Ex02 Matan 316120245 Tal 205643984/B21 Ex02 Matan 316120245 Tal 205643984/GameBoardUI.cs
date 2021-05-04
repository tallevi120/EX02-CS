using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex02_Matan_316120245_Tal_205643984
{
    public class GameBoardUI
    {
        public static short GetRowAndCol(GameBoard i_Board, Player i_Player, out short io_Col)
        {
            io_Col = 0; ///deafult value
            bool validCellFlag = true;
            short boardSize = (short)i_Board.MatrixBoard.GetLength(0);
            short row = 0; ///deafult value
            string input;

            while (validCellFlag == true)
            {
                Console.WriteLine(string.Format("{0}'s turn, MARK is{1}", i_Player.PlayerName, i_Player.Mark));
                Console.WriteLine("You can press 'Q' to quit the game");
                Console.WriteLine("Please enter row");
                input = Console.ReadLine();
                i_Board.CheckIfQuit(input);
                if (short.TryParse(input, out row))
                {
                    row--;
                }
                else
                {
                    row = -1;
                }

                Console.WriteLine("Please enter column");
                input = Console.ReadLine();
                i_Board.CheckIfQuit(input);
                if (short.TryParse(input, out io_Col))
                {
                    io_Col--;
                }
                else
                {
                    io_Col = -1;
                }

                if (row == -1 || io_Col == -1)
                {
                    Console.WriteLine("WRONG INPUT ! please put numbers inside the range !");
                    continue;
                }
                else if (row >= boardSize || io_Col >= boardSize || row < 0 || io_Col < 0)
                {
                    Console.WriteLine("Out of bounds of the board please put numbers inside the range !");
                    continue;
                }

                if (i_Board.IfCellEmpty(row, io_Col))
                {
                    validCellFlag = false;
                }
                else
                {
                    Console.WriteLine("Cell already taken, choose again");
                }
            }

            return row;
        }

        public short GetBoardSize()
        {
            bool validInputFlag = true;
            short boardSize = 0;

            Console.WriteLine("Hello Player One ! Please enter number of board size(range is 3-9) :");
            while(validInputFlag == true)
            {
                short.TryParse(Console.ReadLine(), out boardSize);
                if(GameBoard.CheckIfInRange(boardSize, 3, 9))
                {
                    validInputFlag = false;
                }
                else
                {
                    Console.WriteLine("Board must be square, from 3x3 to 9x9, Please try again :");
                }
            }

            return boardSize;
        }

        public short SelectTheOpponent()
        {
            bool validInput = true;
            short oponent = 0;

            Console.WriteLine("Please press 1 for play against Human Player, and 2 if you want to play agains the computer :");
            while(validInput == true)
            {
                short.TryParse(Console.ReadLine(), out oponent);
                if(oponent == 1)
                {
                    Console.WriteLine("You choosed human player, GOOD LUCK !");
                    validInput = false;
                }
                else if(oponent == 2)
                {
                    Console.WriteLine("You choosed AI computer player, GOOD LUCK !");
                    validInput = false;
                }
                else
                {
                    Console.WriteLine("WRONG Input, please chose 1 for human player, 2 for comuter player !");
                }
            }

            return oponent;
        }

        public void PrintBoard(string[,] i_MatrixBoard)
        {
            int rowLength = i_MatrixBoard.GetLength(0);

            for(int j = 0 ; j < rowLength ; j++)
            {
                Console.Write(string.Format("{0,4}", j + 1));
            }

            Console.Write(Environment.NewLine);
            for(int i = 0 ; i < rowLength ; i++)
            {
                Console.Write(string.Format("{0}|", i + 1));
                for(int j = 0 ; j < rowLength ; j++)
                {
                    Console.Write(string.Format("{0,-3}|", i_MatrixBoard[i, j]));
                }

                Console.Write(Environment.NewLine);
                for(int j = 0 ; j < rowLength ; j++)
                {
                    Console.Write(string.Format("{0}", "===="));
                }

                Console.Write(string.Format("{0}", "=="));
                Console.Write(Environment.NewLine);
            }
        }

        public void PrintRecord(List<Player> i_Players)
        {
            Console.WriteLine(string.Format(@"Player 1 number of wins is {0} 
Player 2 number of wins is {1}", i_Players[0].Wins, i_Players[1].Wins));
        }

        public bool IfContinue()
        {
            bool flagForInput = true;
            string key;
            bool ifContinueFlag = true;

            Console.WriteLine("Do you want Keep Playing ? (y | n)");
            while(flagForInput == true)
            {
                key = Console.ReadLine();
                if(key == "n")
                {
                    flagForInput = false;
                    ifContinueFlag = false;
                }
                else if(key == "y")
                {
                    flagForInput = false;
                }
                else
                {
                    Console.WriteLine("WRONG INPUT ! , Do you want Keep Playing ? (y | n)");
                }
            }

            return ifContinueFlag;
        }
    }
}
