// See https://aka.ms/new-console-template for more information
using System.Drawing;
using System.Runtime.Serialization;

Random dice = new Random();
int dice1 = dice.Next(1,7);
int dice2 = dice.Next(1,7);
int dice3 = dice.Next(1,7);
Console.Write($"First die: {dice1} /");
Console.Write($" Second die: {dice2} /");
Console.WriteLine($" Third die: {dice3}"); //3 dice rolls and their output

int Total = dice1 + dice2 + dice3;
Console.Write($"The result of the sum of all dice without bonuses is {Total}");


if (dice1 == dice2 || dice1 == dice3 || dice2 == dice3)
{
    Total +=2; 
} 
//sum of 2 points if either of those 3 conditions are met


if ((dice1 == dice2) && (dice2 == dice3))
{
    Total +=6;
}
//sum of 6 points if both conditions are met

Console.WriteLine($" and with bonuses is {Total}");

if (Total >= 15)
{
    Console.BackgroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine("You won");
    
    if (Total-15 == 0)
    {
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"You won without any extra points, :)");

    }
    else
    {
        Console.BackgroundColor = ConsoleColor.DarkYellow;
         Console.WriteLine($"You won with {Total-15} extra points, :)");
    } Console.ResetColor();
      
}
else
{
    Console.BackgroundColor = ConsoleColor.Red;
    Console.WriteLine("You lost");
    Console.BackgroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine($"You were {15-Total} points away, :("); Console.ResetColor();
     
}

Console.BackgroundColor = ConsoleColor.Black;
Console.ResetColor();
Console.WriteLine();  //console color reset, sometimes it's buggy and it doesn't reset fully
