using System;
using System.Collections;
using System.IO;
namespace catchBlock
{
    class Program
    {
        public static int score = 0;
        public static int lives = 3;
        public static int highscore;
        static void Main(string[] args)
        {
            try
            {
                highscore = Convert.ToInt32(System.IO.File.ReadAllText(@"D:\highScore"));
            }
            catch (Exception)
            {
                highscore = 0;

            }
            string[,] board = new string[,]
            {
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
                {" ", " ", " ", " ", "_", "_", " ", " ", " ", " "}
            };
            int startPos1 = 4;
            int startPos2 = 5;
            string space = "                    ";
            int numRows = 15;
            int numColms = 10;

            for (int i = 0; i < numRows; i++)
            {
                Console.Write(space);
                for (int j = 0; j < numColms; j++)
                {
                    Console.Write(board[i, j]);
                }
                Console.WriteLine();
            }

            int[] Pos = new int[2];
            bool exit = false;
            while (!exit)
            {

                int randomCol = RandomCol();
                Pos = updateScreen(board, randomCol, startPos1, startPos2);
                startPos1 = Pos[0];
                startPos2 = Pos[1];

            }



        }

        private static int RandomCol()
        {
            Random random = new Random();
            int randomCol = random.Next(0, 10);
            return randomCol;
        }
        private static string addRandomObj(string[,] board, int randomCol)
        {
            string[] obj = { "+", "-" };
            Random random = new Random();
            int randomPos = random.Next(0, 2);
            string randomObj = obj[randomPos];
            board[0, randomCol] = randomObj;
            return randomObj;
        }

        private static int[] updateScreen(string[,] board, int randomCol, int startPos1, int startPos2)
        {
            int[] Pos = new int[2];
            string randomObj = addRandomObj(board, randomCol);
            printBoard(board);
            Pos = fallSlow(board, randomCol, randomObj, startPos1, startPos2);
            return Pos;
        }



        private static void printBoard(string[,] board)
        {
            string space = "                              ";

            for (int i = 0; i < 15; i++)
            {

                if (i == 14)
                {
                    Console.WriteLine("Your HighScore is: {0}", highscore);
                    Console.WriteLine("Score: {0}", score);
                    Console.WriteLine("Lives: {0}", lives);
                }
                Console.Write(space);

                for (int j = 0; j < 10; j++)
                {
                    Console.Write(board[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n  ");
        }

        private static int[] fallSlow(string[,] board, int randomCol, string randomObj, int startPos1, int startPos2)
        {

            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            // 13 times
            for (int i = 1; i < 14; i++)
            {

                if (Console.KeyAvailable == false)
                {
                    board[i - 1, randomCol] = " ";
                    board[i, randomCol] = randomObj;
                    printBoard(board);
                    if (score < 50)
                    {
                        System.Threading.Thread.Sleep(200);
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(100);
                    }
                    if (i == 13)
                    {
                        if ((randomCol == startPos1 || randomCol == startPos2) && randomObj.Equals("+"))
                        {
                            score += 10;

                        }
                        else if ((randomCol == startPos1 || randomCol == startPos2) && randomObj.Equals("-") && score >= 10)
                        {
                            score -= 10;
                            lives--;
                            if (lives <= 0)
                            {
                                if (score > highscore)
                                {
                                    highscore = score;
                                }
                                Console.WriteLine("You lost with a score of: {0}", score);
                                System.IO.File.WriteAllText(@"D:\highScore", "" + highscore);
                                System.Environment.Exit(0);

                            }
                        }
                        else if ((randomCol == startPos1 || randomCol == startPos2) && randomObj.Equals("-"))
                        {
                            lives--;
                            if (lives <= 0)
                            {
                                if (score > highscore)
                                {
                                    highscore = score;
                                }
                                Console.WriteLine("You lost with a score of: {0}", score);
                                System.IO.File.WriteAllText(@"D:\highScore", "" + highscore);
                                System.Environment.Exit(0);
                            }
                        }
                        board[i, randomCol] = " ";
                    }
                }
                else
                {
                    board[i - 1, randomCol] = " ";
                    board[i, randomCol] = randomObj;
                    printBoard(board);

                    if (i == 13)
                    {
                        if ((randomCol == startPos1 || randomCol == startPos2) && randomObj.Equals("+"))
                        {
                            score += 10;

                        }
                        else if ((randomCol == startPos1 || randomCol == startPos2) && randomObj.Equals("-") && score >= 10)
                        {
                            score -= 10;

                        }
                        board[i, randomCol] = " ";
                    }
                    cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.RightArrow)
                    {
                        if (startPos2 != 9)
                        {
                            board[14, startPos1] = " ";
                            board[14, startPos2] = " ";
                            startPos1++;
                            startPos2++;
                            board[14, startPos1] = "_";
                            board[14, startPos2] = "_";
                        }



                    }
                    else if (cki.Key == ConsoleKey.LeftArrow)
                    {
                        if (startPos1 != 0)
                        {
                            board[14, startPos1] = " ";
                            board[14, startPos2] = " ";
                            startPos1--;
                            startPos2--;
                            board[14, startPos1] = "_";
                            board[14, startPos2] = "_";
                        }

                    }
                    else if (cki.Key == ConsoleKey.Escape)
                    {
                        System.Environment.Exit(0);
                    }

                }




            }

            int[] Pos = { startPos1, startPos2 };
            return Pos;


        }





    }
}
