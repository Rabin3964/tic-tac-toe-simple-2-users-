using System;
using System.Threading;

namespace Tic_Tac_Toe
{
    class Program
    {
        static char[] arr = { '0','1','2','3','4','5','6','7','8','9'};
        static int player = 1; // By default player 1 is set
        static int choice;//holds the choice at which position user wants to mark

        // flag varibale to check who has won/draw/running.1 for wining,-1 for draw and 0 for running condition.
        static int flag = 0;

        static void Main(string[] args)
        {
            do
            {
                Console.Clear(); //whenever loop will be stated again then screen will be clear
                Console.WriteLine("Player:X and Player2:0");
                Console.WriteLine("\n");

                if (player%2 == 0)
                {
                    Console.WriteLine("Player 2 Chance");
                }
                else
                {
                    Console.WriteLine("Player 1 Chance");
                }
                Console.WriteLine("\n");

                Board(); //calling the board function
                choice = int.Parse(Console.ReadLine());//Taking the users choice

                if (arr[choice]!='X' && arr[choice]!='0')
                {
                    if (player%2 ==0)//if chance is of player 2 then mark 0 else mark X
                    {
                        arr[choice] = '0';
                        player++;
                    }
                    else
                    {
                        arr[choice] = 'X';
                        player++;
                    }
                }
                else//if there is any position where users want to run and that is already marked then show message and load board again
                {
                    Console.WriteLine("Sorry the row {0} is already marked with {1}",choice,arr[choice]);
                    Console.WriteLine("\n");
                    Console.WriteLine("Please wait the board is loading again...");
                    Thread.Sleep(2000);
                }
                flag = CheckWin();
            } while (flag!=1 && flag!=-1);//This loop will run untill all the cell of the grid is not marked with X and 0 or some player has not win

            Console.Clear();//clearing the console
            Board();//Getting filled board again

            if (flag == 1)
            {
                Console.WriteLine("Player {0} has won",(player%2)+1);
            }
            else//if flag is 0 then match is draw
            {
                Console.WriteLine("Draw");
            }         
            Console.ReadLine();
        }

        //Board method to create board
        private static void Board()
        {
            Console.WriteLine("  |   |");
            Console.WriteLine("{0} | {1} | {2}", arr[1],arr[2],arr[3]);
            Console.WriteLine("__|___|__");
            Console.WriteLine("{0} | {1} | {2}", arr[4], arr[5], arr[6]);
            Console.WriteLine("__|___|__");
            Console.WriteLine("{0} | {1} | {2}", arr[7], arr[8], arr[9]);
            Console.WriteLine("  |   |");
        }

        //Checking that any player has won or not
        private static int CheckWin()
        {
            #region  Horzontal Winning Condtion
            //Wining condition for first row
            if (arr[1]==arr[2] && arr[2]==arr[3])
            {
                return 1;
            }
            //wining condition for second row
            else if(arr[4]==arr[5] && arr[5]==arr[6])
            {
                return 1;
            }
            //wining condition for third row
            else if (arr[6]==arr[7] && arr[7]==arr[8])
            {
                return 1;
            }
            #endregion

            #region vertical Winning Condtion
            //winning Condition for first column
            else if (arr[1]==arr[4] && arr[4]==arr[7])
            {
                return 1;
            }
            //wining condition for second column
            else if (arr[2]==arr[5] && arr[5]==arr[8])
            {
                return 1;
            }
            //winning condition for third column
            else if (arr[3]==arr[6] && arr[6]==arr[9])
            {
                return 1;
            }
            #endregion

            #region  Diagonal Winning Condition
            else if (arr[1]==arr[5] && arr[5]==arr[9])
            {
                return 1;
            }
            else if (arr[3]==arr[5] && arr[5]==arr[7])
            {
                return 1;
            }
            #endregion

            #region Checking for Draw
            else if (arr[1]!='1' && arr[2]!='2' && arr[3]!='3' && arr[4]!='4' &&
                arr[5]!='5' && arr[6]!='6' && arr[7]!='7' && arr[8]!='8' && arr[9]!='9')
            {
                return -1;
            }
            #endregion 
            else
            {
                return 0;
            }
        }
    }
}
