using System;
using System.Threading;
using System.Drawing;
using System.Runtime.Serialization;
using System.Data.Common;
using System.Media;
using NAudio.Wave;
using NAudio.Wave.Asio;

internal class Program
{
    private static WaveOutEvent outputDevice;
    private static bool isPlaying = true;
    private static void Main(string[] args)
    {
        Console.WindowWidth = 120;
        Console.WindowHeight = 35;
        Console.Clear();
        Console.WriteLine(@"
                         Program made by Ulises
                         MIT License Copyright (c) 2023 Ulises Romero López
                         website: https://ulises.tech
                         reddit: https:/reddit.com/user/ulisesdeveloper
                         twitter: https:/x.com/ulisesdev");
        Thread.Sleep(3500);
        Console.Clear();

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("GAMES: \n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1) DICE                          Game where you try to achieve 15 with 3 dice, try getting bonuses");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("2) COIN                          The classic coinflip game!");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("3) BLACKJACK                     The greatest casino hit!");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("4) ROCK PAPER SCISSORS           Rock Paper Scissors, It doesn't get easier than that\n\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("EVERYTHING ELSE: \n");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("5) OTHER                         Submenu to EXIT and view the Credits or License\n\n\n");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Type in a NUMBER to travel to that option:");
            
            string userInput = Console.ReadLine().ToUpper(); // Read user input and convert to uppercase

            if (userInput == "5")
            {
                Console.Clear();
                bool otherOption = true;
                while (otherOption)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("What do you wish to do?,");
                    Console.WriteLine("- BACK (Go back to the main menu)");
                    Console.WriteLine("- LICENSE (View License)");
                    Console.WriteLine("- CREDITS (View Credits)");
                    Console.WriteLine("- EXIT (Exit the Program)");
                    Console.WriteLine("\nType in your option: ");

                    string innerInput = Console.ReadLine().ToUpper(); // Capture the user's choice inside the loop
                    if (innerInput == "BACK")
                    {
                        Thread.Sleep(200);
                        otherOption = false;
                    }
                    if (innerInput == "LICENSE")
                    {
                        bool licenseBack = true;
                        Console.Clear();
                        Console.WriteLine("\n\n");
                        Console.WriteLine(@"
                         
                         MIT License

                         Copyright (c) 2023 Ulises Romero López

                         Permission is hereby granted, free of charge, to any person obtaining a copy
                         of this software and associated documentation files (the ""Software""), to deal
                         in the Software without restriction, including without limitation the rights
                         to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
                         copies of the Software, and to permit persons to whom the Software is
                         furnished to do so, subject to the following conditions:

                         The above copyright notice and this permission notice shall be included in all
                         copies or substantial portions of the Software.

                         THE SOFTWARE IS PROVIDED ""AS IS"", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
                         IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
                         FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
                         AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
                         LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
                         OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
                         SOFTWARE. ");

                        Console.WriteLine("\n\n\n");
                        Thread.Sleep(500);
                        while (licenseBack)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Type in \"BACK\" to go back: ");
                            string input = Console.ReadLine();
                            if (input == "BACK")
                            {
                                Console.Clear();
                                licenseBack = false;
                            }
                            else
                            {

                                Console.WriteLine("\nINPUT NOT RECOGNIZED, TRY TYPING \"BACK\" AGAIN IN UPPERCASE");
                            }

                        }
                    }
                    if (innerInput == "CREDITS")
                    {
                        Console.Clear();
                        bool creditsBack = true;
                        Console.WriteLine("\n\n");

                        Console.WriteLine("Program made by Ulises");
                        Console.WriteLine("website: https://ulises.tech");
                        Console.WriteLine("reddit: https:/reddit.com/user/ulisesdeveloper");
                        Console.WriteLine($"twitter: https:/x.com/ulisesdev\n\n\nEVERYTHING USED IN THIS PROJECT:");
                        Console.WriteLine("Libraries:");
                        Console.WriteLine("NAudio for audio playback | https://github.com/naudio/NAudio");
                        Console.WriteLine("\n\nCasino Music:");
                        Console.WriteLine("Gotta Go by Tokyo Music Walker | https://soundcloud.com/user-356546060");
                        Console.WriteLine("Music promoted by https://www.free-stock-music.com");
                        Console.WriteLine("Creative Commons / Attribution 3.0 Unported License (CC BY 3.0)");
                        Console.WriteLine("https://creativecommons.org/licenses/by/3.0/deed.en_US");
                        Thread.Sleep(500);
                        while (creditsBack)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Type in \"BACK\" to go back: ");
                            if (Console.ReadLine() == "BACK")
                            {
                                Console.Clear();
                                creditsBack = false;
                            }
                            else
                            {

                                Console.WriteLine("\nINPUT NOT RECOGNIZED, TRY TYPING \"BACK\" AGAIN IN UPPERCASE");
                            }

                        }
                    }
                    if (innerInput == "EXIT")
                    {
                        Environment.Exit(1);
                    }

                    Console.Clear();

                }


            }
            else if (userInput == "2")
            {
                Console.Clear();
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
                        Console.Clear();
                        repeat = false;
                    }
                    else if (coinGuess == "HEADS" || coinGuess == "TAILS")
                    {
                        Console.WriteLine($"\n\nAnd it is...");
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
            else if (userInput == "1")
            {
                Console.Clear();
                Random dice = new Random();
                int dice1 = dice.Next(1, 7);
                int dice2 = dice.Next(1, 7);
                int dice3 = dice.Next(1, 7);
                Thread.Sleep(400);
                Console.Write($"First die: {dice1} / Second die: {dice2} / Third die: {dice3}\n");
                Thread.Sleep(1000);
                int total = dice1 + dice2 + dice3;
                Console.WriteLine($"The result of the sum of all dice without bonuses is {total}");
                Thread.Sleep(2500);

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
                Console.WriteLine("Type in anything to go back to the main menu:");
                string wait = Console.ReadLine();
                Console.WriteLine();  //console color reset, sometimes it's buggy and it doesn't reset fully
                Console.Clear();
            }
            else if (userInput == "3")
            {
                Thread audioThread = new Thread(PlayCasinoAudio);

                audioThread.Start();

                string[] cards = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
                int number = 0;
                int dealerTotal = 0;
                int playerTotal = 0;
                decimal bet = 0;
                decimal wallet = 100;
                string input = "";
                while (true)
                {

                    Console.Clear();
                    Console.WriteLine("Welcome to the Casino, It's BlackJack Time! Place your bets");
                    while (true)
                    {
                        if (wallet == 0)
                        {
                            Console.WriteLine("You've lost all your money, the house always wins.");
                            StopCasinoAudio();
                            break;
                        }
                        Console.WriteLine($"Balance: ${wallet}");
                        Console.WriteLine("\nType In \"N\" to go back or Input your bet: ");
                        input = Console.ReadLine().ToLower();
                        if (input == "n")
                        {
                            Console.Clear();
                            StopCasinoAudio();
                            break;
                        }
                        else
                        {

                            if (decimal.TryParse(input, out bet))
                            {
                                if (wallet >= bet)
                                {
                                    Console.WriteLine($"Inputted bet: ${bet}");
                                    game();
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Bet can't be bigger than ur wallet's balance");
                                    bet = 0;
                                    Console.WriteLine("Input a valid bet!");
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Input a valid value!");
                            }

                        }




                    }
                    break;



                }



                static void PlayCasinoAudio()
                {

                    using (var audioFile = new Mp3FileReader("tokyo-music-walker-gotta-go.mp3"))
                    using (var outputDevice = new WaveOutEvent())
                    {
                        outputDevice.Init(audioFile);

                        //Loop 
                        while (true)
                        {
                            outputDevice.Play();

                            //wait for playback to complete
                            while (isPlaying && outputDevice.PlaybackState == PlaybackState.Playing)
                            {
                                Thread.Sleep(100); // Sleep to reduce CPU usage
                            }

                            //If playback stopped, reset position and restart
                            audioFile.Position = 0;
                        }
                    }
                }

                static void StopCasinoAudio()
                {
                    isPlaying = false; //Stop playback loop
                    if (outputDevice != null)
                    {

                        outputDevice.Stop();
                        outputDevice.Dispose();
                    }
                }





                void game()
                {
                    Console.Clear();
                    Console.WriteLine($"Balance: ${wallet} // Current Bet: ${bet} \n");
                    pulledCard(ref dealerTotal);
                    Console.WriteLine($"Dealer's shown card is {dealerTotal}");
                    pulledCard(ref dealerTotal);
                    pulledCard(ref playerTotal);
                    pulledCard(ref playerTotal);
                    Console.WriteLine($"Your starting total is {playerTotal} \n");
                    while (playerTotal <= 21)
                    {
                        Console.WriteLine("Choose between \"HIT\" and \"STAND\"");
                        string? userDecision = Console.ReadLine().ToUpper();
                        if (userDecision == "HIT")
                        {
                            pulledCard(ref playerTotal);
                            Console.WriteLine($"Your total is {playerTotal}");
                        }
                        else if (userDecision == "STAND")
                        {
                            Console.Clear();
                            Console.WriteLine($"Balance: ${wallet} // Current Bet: ${bet} // Your Total: {playerTotal} \n");
                            Console.WriteLine($"DEALER SHOWS HIS SECOND CARD, his new total is... {dealerTotal}");
                            break;
                        }
                        else
                        {
                            while (true)
                            {
                                Console.WriteLine("Input not recognized, try again");
                                break;
                            }
                        }



                    }


                    if (playerTotal > 21)
                    {
                        Console.WriteLine("You lose!");
                        wallet -= bet;
                        Thread.Sleep(1500);
                        resetValues();
                    }
                    else
                    {

                        while (dealerTotal <= 16)
                        {
                            pulledCard(ref dealerTotal);
                            Console.WriteLine($"Dealer get's a new card, and he's total is... {dealerTotal}");
                            if (playerTotal == dealerTotal)
                            {
                                Console.WriteLine("It's a Draw!");
                                resetValues();
                                Thread.Sleep(1500);
                                Console.WriteLine("GOING BACK TO THE MENU IN 3");
                                Thread.Sleep(1500);
                                Console.WriteLine("GOING BACK TO THE MENU IN 2");
                                Thread.Sleep(1500);
                                Console.WriteLine("GOING BACK TO THE MENU IN 1");
                                Thread.Sleep(1500);
                                Console.Clear();
                                break;
                            }
                            else if (dealerTotal > 21)
                            {
                                Console.WriteLine("DEALER BUST, You Win! \n");
                                wallet += bet;
                                resetValues();
                                Thread.Sleep(4000);
                                Console.WriteLine("GOING BACK TO THE MENU IN 3");
                                Thread.Sleep(1500);
                                Console.WriteLine("GOING BACK TO THE MENU IN 2");
                                Thread.Sleep(1500);
                                Console.WriteLine("GOING BACK TO THE MENU IN 1");
                                Thread.Sleep(1500);
                                Console.Clear();
                                resetValues();
                                break;

                            }

                        }

                        if (dealerTotal > 21 || playerTotal > dealerTotal)
                        {
                            Console.WriteLine("You win!");
                            wallet += bet;
                            Thread.Sleep(1500);
                            resetValues();
                        }
                        else if (dealerTotal > playerTotal)
                        {
                            Console.WriteLine("You lose!");
                            wallet -= bet;
                            Thread.Sleep(1500);
                            resetValues();
                        }
                        resetValues();
                    }
                }

                void pulledCard(ref int total)
                {
                    number = cardGen();
                    if (number == 0)
                    {
                        total = (total <= 10) ? total += 11 : total += 1;
                    }
                    else
                    {
                        total += number;
                    }
                }
                int cardGen()
                {
                    Random random = new Random();
                    int numCardPulled = random.Next(cards.Length);
                    int cardPulled = 0;
                    switch (numCardPulled)
                    {
                        case 1:
                            {
                                cardPulled = 1;
                                break;
                            }
                        case 2:
                            {
                                cardPulled = 2;
                                break;
                            }
                        case 3:
                            {
                                cardPulled = 3;
                                break;
                            }
                        case 4:
                            {
                                cardPulled = 4;
                                break;
                            }
                        case 5:
                            {
                                cardPulled = 5;
                                break;
                            }
                        case 6:
                            {
                                cardPulled = 6;
                                break;
                            }
                        case 7:
                            {
                                cardPulled = 7;
                                break;
                            }
                        case 8:
                            {
                                cardPulled = 8;
                                break;
                            }
                        case 9:
                            {
                                cardPulled = 9;
                                break;
                            }
                        case 10:
                            {
                                cardPulled = 10;
                                break;
                            }
                        case 11:
                            {
                                cardPulled = 10;
                                break;
                            }
                        case 12:
                            {
                                cardPulled = 10;
                                break;
                            }
                        case 13:
                            {
                                cardPulled = 0;
                                break;
                            }

                    }
                    return cardPulled;

                }
                void resetValues()
                {
                    playerTotal = 0;
                    dealerTotal = 0;
                }

            }
            else if (userInput == "4")
            {
                int playerWon = 0;
                int cpuWon = 0;
                while (true)
                {
                    Console.Clear();
                    int elementGen = 33;

                    counter();
                    Console.WriteLine("Type \"BACK\" to go Back or");
                    Console.WriteLine("Choose between \"R\" for Rock \"P\" for Paper or \"S\" for Scissors:");
                    string input = Console.ReadLine().ToUpper();
                    if (input == "R")
                    {
                        Console.Clear();
                        counter();
                        Console.WriteLine("You chose ROCK");
                        gameResult();
                    }
                    else if (input == "P")
                    {
                        Console.Clear();
                        counter();
                        Console.WriteLine("You chose PAPER");
                        gameResult();
                    }
                    else if (input == "S")
                    {
                        Console.Clear();
                        counter();
                        Console.WriteLine("You chose SCISSORS");
                        gameResult();
                    }
                    else if (input == "B" || input == "BACK")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Input not recognized, Try Again!");
                        Thread.Sleep(1600);
                        Console.Clear();
                    }


                    void counter()
                    {
                        Console.WriteLine($"Matches Won {playerWon} / Matches Lost {cpuWon}\n");
                    }

                    void gameResult()
                    {
                        bool goBack = true;
                        Console.WriteLine("The results are in...");
                        Thread.Sleep(1000);
                        cpuPick();
                        Thread.Sleep(1500);
                        Console.WriteLine();
                        if (((input == "R") && (elementGen == 2)) || ((input == "P") && (elementGen == 0)) || ((input == "S") && (elementGen == 1)))
                        {
                            Console.WriteLine("You WIN! :D\n");
                            playerWon++;
                        }
                        else if (((input == "R") && (elementGen == 0)) || ((input == "P") && (elementGen == 1)) || ((input == "S") && (elementGen == 2)))
                        {
                            Console.WriteLine($"You both chose {input}, It's a DRAW!\n");
                        }
                        else if (((input == "R") && (elementGen == 1)) || ((input == "P") && (elementGen == 2)) || ((input == "S") && (elementGen == 0)))
                        {
                            Console.WriteLine("You LOST! :(\n");
                            cpuWon++;
                        }
                        while (goBack)
                        {
                            Console.WriteLine("Type in \"B\" to go back to the Rock Paper Scissors Menu: ");
                            string inputed = Console.ReadLine().ToUpper();
                            if (inputed == "B")
                            {
                                goBack = false;
                            }
                            else
                            {
                                Console.WriteLine("Input not recognized, Try Again!");
                            }
                        }
                        void cpuPick()
                        {
                            Random random = new Random();
                            elementGen = random.Next(0, 2);
                            if (elementGen == 0)
                            {
                                Console.WriteLine("The CPU chooses Rock!");
                            }
                            else if (elementGen == 1)
                            {
                                Console.WriteLine("The CPU chooses Paper!");
                            }
                            else if (elementGen == 2)
                            {
                                Console.WriteLine("The CPU chooses Scissors!");
                            }
                        }
                    }

                }
                Console.Clear();

            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("INPUT NOT RECOGNIZED, TRY TYPING IN UPPERCASE");
            }

            Console.ResetColor();
            Console.WriteLine();
            //that's it
        }
    }
}