using System;
using System.Collections.Generic;
using System.Threading;

namespace CardGameAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your name to play Lincoln: "); // prompts user for input 
            string name = Console.ReadLine(); // assigns user input to string variable
            string PlayAgain = null; // variable initializes with a value of null
            GamePlay Begin = new GamePlay(name); // GamePlay object instantiated 

            do 
            {
                Begin.PlayGame(name); // PlayGame() method called from GamePlay class
                Console.WriteLine("Would you like to play again? (y/n): "); // prompts user if they want to play again
                PlayAgain = Console.ReadLine().ToLower(); // assigns user answer to string variable
                    
            } while (PlayAgain == "yes" || PlayAgain[0] == 'y'); // loop continues while user enters yes to playing again
            Console.WriteLine("\nThanks for playing!."); // returns string thanking user for playing
            Thread.Sleep(3000); // waits 3 seconds before exiting program
            Environment.Exit(0); // exits program 
            
        }

      
    }
}
