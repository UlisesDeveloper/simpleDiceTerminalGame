using System;
using System.Threading;
using System.Drawing;
using System.Runtime.Serialization;
using System.Data.Common;
using System.Media;
using NAudio.Wave;

internal class Program
{
    private static WaveOutEvent outputDevice;
    private static bool isPlaying = true;
    private static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine(@"
                         Program made by Ulises
                         MIT License Copyright (c) 2023 Ulises Romero López
                         website: https://ulises.tech
                         reddit: https:/reddit.com/user/ulisesdeveloper
                         twitter: https:/x.com/ulisesdev");
        Thread.Sleep(5000);
        Console.Clear();

        while (true)
        {
            Console.WriteLine("TYPE EITHER \"DICE\", \"COIN\" OR \"BLACKJACK\" TO CHOOSE WHICH GAME TO PLAY // OR \"OTHER\" TO EXIT OR VIEW OTHER OPTIONS");
            string userInput = Console.ReadLine().ToUpper(); // Read user input and convert to uppercase

            if (userInput == "OTHER")
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
            else if (userInput == "COIN")
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
            else if (userInput == "DICE")
            {
                Console.Clear();
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
            else if (userInput == "BLACKJACK")
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
                    pulledDealer();
                    Console.WriteLine($"Dealer's shown card is {dealerTotal}");
                    pulledDealer();
                    pulledPlayer();
                    pulledPlayer();
                    Console.WriteLine($"Your starting total is {playerTotal} \n");
                    while (playerTotal <= 21)
                    {
                        Console.WriteLine("Choose between \"HIT\" and \"STAND\"");
                        string? userDecision = Console.ReadLine().ToUpper();
                        if (userDecision == "HIT")
                        {
                            pulledPlayer();
                            Console.WriteLine($"Your total is {playerTotal}");
                        }
                        else if (userDecision == "STAND")
                        {
                            Console.Clear();
                            Console.WriteLine($"Balance: ${wallet} // Current Bet: ${bet} // Your Total: {playerTotal} \n");
                            Console.WriteLine($"DEALER SHOWS HIS SECOND CARD, his new total is... {dealerTotal}");
                            Thread.Sleep(1000);
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
                        resetValues();
                    }
                    else
                    {

                        while (dealerTotal <= 16)
                        {
                            pulledDealer();
                            Console.WriteLine($"Dealer get's a new card, and he's total is... {dealerTotal}");
                            if (playerTotal == dealerTotal)
                            {
                                Console.WriteLine("It's a Draw");
                                resetValues();
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
                            resetValues();
                        }
                        else if (dealerTotal > playerTotal)
                        {
                            Console.WriteLine("You lose!");
                            wallet -= bet;
                            resetValues();
                        }
                        resetValues();
                    }
                }

                void pulledDealer()
                {
                    number = cardGen();
                    if (number == 0)
                    {
                        dealerTotal = (dealerTotal <= 10) ? dealerTotal += 11 : dealerTotal += 1;
                    }
                    else
                    {
                        dealerTotal += number;
                    }

                }
                void pulledPlayer()
                {

                    number = cardGen();
                    if (number == 0)
                    {
                        playerTotal = (playerTotal <= 10) ? playerTotal += 11 : playerTotal += 1;
                    }
                    else
                    {
                        playerTotal += number;
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
            else if (userInput == "RPS")
            {
                Console.WriteLine("wip");

            }
            else
            {
                Console.WriteLine("INPUT NOT RECOGNIZED, TRY TYPING IN UPPERCASE");
            }

            Console.ResetColor();
            Console.WriteLine();
            //that's it
        }
    }
}