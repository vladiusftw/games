using System;

namespace tictactoe
{
    class Program
    {
        static void Main(string[] args)
        {
            string[][] board = new string[][]{ 
                new string[]{" ", "   |", " ", "   |", " " },
                new string[]{" 1", "  |", " 2", "  |", " 3" },
                new string[]{"____", "|", "____", "|", "____" },
                new string[]{" ", "   |", " ", "   |", " " },
                new string[]{" 4", "  |", " 5", "  |", " 6" },
                new string[]{"____", "|", "____", "|", "____" },
                new string[]{" ", "   |", " ", "   |", " " },
                new string[]{" 7", "  |", " 8", "  |", " 9" },
                new string[]{" ", "   |", " ", "   |", " " },

            };

            foreach (string[] row in board)
            {
                foreach (string column in row)
                {
                    Console.Write(column);
                }
                Console.WriteLine();
            }
            play(board);
        }

        public static int updateBoard(string [][] board, string symbol, int place, int turn)
        {
            
            switch (place)
            {
                case 1:
                    if(board[1][0] == " 1")
                    {
                        board[1][0] = symbol;
                    }
                    else
                    {
                        Console.WriteLine("Please Choose Another Area!");
                        turn--;
                    }
                    break;

                case 2:
                    if (board[1][2] == " 2")
                    {
                        board[1][2] = symbol;
                    }
                    else
                    {
                        Console.WriteLine("Please Choose Another Area!");
                        turn--;
                    }
                    break;

                case 3:
                    if (board[1][4] == " 3")
                    {
                        board[1][4] = symbol;
                    }
                    else
                    {
                        Console.WriteLine("Please Choose Another Area!");
                        turn--;
                    }
                    break;

                case 4:
                    if (board[4][0] == " 4")
                    {
                        board[4][0] = symbol;
                    }
                    else
                    {
                        Console.WriteLine("Please Choose Another Area!");
                        turn--;
                    }
                    break;

                case 5:
                    if (board[4][2] == " 5")
                    {
                        board[4][2] = symbol;
                    }
                    else
                    {
                        Console.WriteLine("Please Choose Another Area!");
                        turn--;
                    }
                    break;

                case 6:
                    if (board[4][4] == " 6")
                    {
                        board[4][4] = symbol;
                    }
                    else
                    {
                        Console.WriteLine("Please Choose Another Area!");
                        turn--;
                    }
                    break;

                case 7:
                    if (board[7][0] == " 7")
                    {
                        board[7][0] = symbol;
                    }
                    else
                    {
                        Console.WriteLine("Please Choose Another Area!");
                        turn--;
                    }
                    break;

                case 8:
                    if (board[7][2] == " 8")
                    {
                        board[7][2] = symbol;
                    }
                    else
                    {
                        Console.WriteLine("Please Choose Another Area!");
                        turn--;
                    }
                    break;

                case 9:
                    if (board[7][4] == " 9")
                    {
                        board[7][4] = symbol;
                    }
                    else
                    {
                        Console.WriteLine("Please Choose Another Area!");
                        turn--;
                    }
                    break;

                default:

                    break;
            }
            turn++;

            Console.WriteLine();
            Console.WriteLine();
            foreach (string[] row in board)
            {
                foreach (string column in row)
                {
                    Console.Write(column);
                }
                Console.WriteLine();
            }
            

            
            return turn;
        }

        public static void play(string[][] board)
        {

            Boolean exit = false;
            int turn = 0;
            int place = 0;
            int player;
            string a = "";
            string symbol = "";
            while (!exit)
            {
                if (turn % 2 == 0)
                {
                    symbol = " X";
                    player = 1;
                }
                else
                {
                    symbol = " O";
                    player = 2;
                }
                Console.WriteLine("Type 'EXIT' to leave the game \n");
                Console.WriteLine("Player " + player + " Turn: ");
                try
                {
                    a = Console.ReadLine();
                    if (a.Equals("EXIT"))
                    {
                        System.Environment.Exit(0);
                    }
                    place = Int32.Parse(a);
                    if (place<=0 || place>9)
                    {
                        throw new Exception();
                    }
                    
                }
                catch (Exception)
                {

                    Console.WriteLine("Please Enter a Number from 1-9");

                }
                turn = updateBoard(board,symbol,place,turn);
                Boolean win = Win(board);
                if (win)
                {
                    Console.WriteLine("Player " + player + " Has Won! Press Any Button To Play a New Game");
                    Console.ReadLine();

                    board = new string[][]{
                new string[]{" ", "   |", " ", "   |", " " },
                new string[]{" 1", "  |", " 2", "  |", " 3" },
                new string[]{"____", "|", "____", "|", "____" },
                new string[]{" ", "   |", " ", "   |", " " },
                new string[]{" 4", "  |", " 5", "  |", " 6" },
                new string[]{"____", "|", "____", "|", "____" },
                new string[]{" ", "   |", " ", "   |", " " },
                new string[]{" 7", "  |", " 8", "  |", " 9" },
                new string[]{" ", "   |", " ", "   |", " " },

            };

                    foreach (string[] row in board)
                    {
                        foreach (string column in row)
                        {
                            Console.Write(column);
                        }
                        Console.WriteLine();
                    }
                    turn = 0;
                }



                
            }

        }

        public static Boolean Win(string[][] board)
        {
            Boolean win = false;
            if (board[1][0]==board[1][2] && board[1][2]==board[1][4])
            {
                win = true;
            }
            else if (board[4][0]==board[4][2] && board[4][2]==board[4][4])
            {
                win = true;
            }
            else if (board[7][0]==board[7][2] && board[7][2]==board[7][4])
            {
                win = true;
            }
            else if (board[1][0]==board[4][0] && board[4][0]==board[7][0])
            {
                win = true;
            }
            else if (board[1][2] == board[4][2] && board[4][2] == board[7][2])
            {
                win = true;
            }
            else if (board[1][4] == board[4][4] && board[4][4] == board[7][4])
            {
                win = true;
            }
            else if (board[1][0]==board[4][2] && board[4][2]==board[7][4])
            {
                win = true;
            }
            else if (board[1][4]==board[4][2] && board[4][2]==board[7][0])
            {
                win = true;
            }

            return win;
        }


    }
}
