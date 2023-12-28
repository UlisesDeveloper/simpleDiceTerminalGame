using System;
using System.Threading;
using System.Drawing;
using System.Runtime.Serialization;

internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("TYPE EITHER \"DICE\" OR \"COIN\" TO CHOOSE WHICH GAME TO PLAY (OR \"EXIT\" IF YOU WANT TO LEAVE):");
            string userInput = Console.ReadLine().ToUpper(); // Read user input and convert to uppercase

            if (userInput == "EXIT")
            {
                Environment.Exit(1);
            }
            else if (userInput == "COIN")
            {
                bool repeat = true;
                string coinGuess = "";

                while (repeat)
                {
                    Random coin = new Random();
                    int flip = coin.Next(1, 3);

                    Console.WriteLine("CHOOSE BETWEEN \"HEADS\" OR \"TAILS\" (OR \"BACK\" TO GO BACK): ");
                    coinGuess = Console.ReadLine().ToUpper();

                    if (coinGuess == "BACK")
                    {
                        repeat = false;
                    }
                    else if (coinGuess == "HEADS" || coinGuess == "TAILS")
                    {
                        Console.WriteLine($"And it is...");
                        Thread.Sleep(1000); // 1 second pause
                        Console.WriteLine("...");
                        Thread.Sleep(1000); // 1 second pause

                        if ((coinGuess == "HEADS" && flip == 1) || (coinGuess == "TAILS" && flip == 2))
                        {
                            Console.WriteLine((flip == 1) ? "HEADS!!!" : "TAILS!!!");
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Thread.Sleep(333); 
                            Console.WriteLine("You won :D");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine((flip == 1) ? "HEADS!!!" : "TAILS!!!");
                            Console.BackgroundColor = ConsoleColor.Red;
                            Thread.Sleep(333);
                            Console.WriteLine("You lost D:");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        Console.WriteLine("INPUT NOT RECOGNIZED, TRY TYPING \"HEADS\", \"TAILS\" OR \"EXIT\" IN UPPERCASE");
                    }

                    Console.WriteLine();
                }
            }
            else if (userInput == "DICE")
            {
                Random dice = new Random();
                int dice1 = dice.Next(1, 7);
                int dice2 = dice.Next(1, 7);
                int dice3 = dice.Next(1, 7);

                Console.Write($"First die: {dice1} / Second die: {dice2} / Third die: {dice3}\n");

                int total = dice1 + dice2 + dice3;
                Console.WriteLine($"The result of the sum of all dice without bonuses is {total}");

                if (dice1 == dice2 || dice1 == dice3 || dice2 == dice3)
                {
                    total += 2;
                }

                if (dice1 == dice2 && dice2 == dice3)
                {
                    total += 6;
                }

                Console.WriteLine($"The result of the sum of all dice with bonuses is {total}");
                if (dice1 == dice2 || dice1 == dice3 || dice2 == dice3)
                {
                    total += 2;
                }
                //sum of 2 points if either of those 3 conditions are met


                if (dice1 == dice2 && dice2 == dice3)
                {
                    total += 6;
                }
                //sum of 6 points if both conditions are met

                Console.WriteLine($" and with bonuses is {total}");

                if (total >= 15)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("You won");

                    if (total - 15 == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"You won without any extra points, :)");

                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"You won with {total - 15} extra points, :)");
                    }
                    Console.ResetColor();

                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("You lost");
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"You were {15 - total} points away, :("); Console.ResetColor();

                }

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ResetColor();
                Console.WriteLine();  //console color reset, sometimes it's buggy and it doesn't reset fully
            }
            else
            {
                Console.WriteLine("INPUT NOT RECOGNIZED, TRY TYPING IN UPPERCASE");
            }

            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
