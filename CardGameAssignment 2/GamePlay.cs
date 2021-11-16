using System;
using System.Collections.Generic;
using System.Threading;

namespace CardGameAssignment
{
    public class GamePlay
    {
        private List<Card> PlayerHand; // properties only accesible through this class and methods in the class
        private List<Card> CompHand;
        private Deck PlayDeck;
        private string playername;
        private Random randNum;
        private int playerScore;
        private int compScore;

        public GamePlay(string name)
        {
            PlayerHand = new List<Card>(10); // instance of an list object of type card that represents the hand
            CompHand = new List<Card>(10);
            PlayDeck = new Deck(); // instance of a deck object
            PlayDeck.Shuffle();
            playername = name;
            randNum = new Random();
            playerScore = 0;
            compScore = 0;
        }

        

        public void PlayGame(string name) // takes argument 
        {
            Console.WriteLine("Hello {0}, how many rounds in this game? (1-5): ", GetName()); // method called to return players name 
            int rounds = Int32.Parse(Console.ReadLine()); // number of rounds assigned to variable 
            Console.WriteLine("We will now begin the game!.");
            int game = 1; // variable initialzed witha a value of 1
            do
            {
                Console.Clear();
                Console.WriteLine("\nRound {0}...", game);
                Console.WriteLine();
                Thread.Sleep(1000);
                Console.WriteLine("I will now deal you 10 cards.."); // displays string indicating dealing
                Thread.Sleep(3000); // pauses for 3 seconds to simulate dealing 

                for (int i = 0; i < 10; i++) // for loop iterating from 0-9 
                {
                    PlayDeck.Shuffle(); // shuffles deck being used to deal
                    PlayerHand.Add(PlayDeck.Deal()); // deals 10 cards to player
                    CompHand.Add(PlayDeck.Deal());
                    Console.WriteLine($"{i + 1}: {PlayerHand[i]}"); // displays players hand from 1-10
                }

                Thread.Sleep(500); // paused for 0.5 seconds 
                int pcard1 = Points.RecieveIndexOne() - 1; // calls method to ask player which card first and assigns to int variable 
                Thread.Sleep(500);
                int pcard2 = Points.RecieveIndexTwo(pcard1 + 1) - 1; // asks player which card second and assigns to int varibale 
                Console.WriteLine(); // new line
                int ccard1 = CompCardOne();
                
                int ccard2 = CompCardTwo(ccard1);
                Console.WriteLine($"Player plays {PlayerHand[pcard1]} and {PlayerHand[pcard2]}"); // displays which cards player plays
                Thread.Sleep(2000);

                Console.WriteLine($"Computer plays {CompHand[ccard1]} and {CompHand[ccard2]}"); // displays which card comp plays 

                Thread.Sleep(3000);
                int points1 = Points.Point(PlayerHand[pcard1].ToString()); // assigns point value of first player card to int variable using Point() method
                int points2 = Points.Point(PlayerHand[pcard2].ToString()); // assigns point value of second player card to in variable using Point() method 
                int cpoint1 = Points.Point(CompHand[ccard1].ToString()); // assigns point value of first comp card to int variable using Point() method
                int cpoint2 = Points.Point(CompHand[ccard2].ToString()); // assigns point value of second comp card to int variable using Point() method
                int winner = Points.WinChecker(points1, points2, cpoint1, cpoint2); // assigns 0,1 or 2 value to integer using WinChecker() method 
                int ptotal = points1 + points2; // adds player points together
                int ctotal = cpoint1 + cpoint2; // adds computer points together 
                Console.WriteLine("\nPlayer has a total of {0} points", ptotal); // displays player points total
                Thread.Sleep(1000);
                Console.WriteLine("Computer has a total of {0} points.", ctotal); // displays computer points total
                Thread.Sleep(1000);
                if (winner == 1) // checks if player won
                {
                    Console.WriteLine("\nPlayer wins this round!"); // returns string
                    playerScore += 1;                                                
                }
                else if (winner == 0) // checks if draw
                {
                    Console.WriteLine("\nThis round is a draw."); // returns string
                }
                else // checks if computer won
                {
                    Console.WriteLine("\nComputer wins this round!"); // returns string
                    compScore += 1;                                                  
                }
                
                Console.WriteLine("\nPlayer Score: " + playerScore);
                Console.WriteLine("Computer Score: " + compScore);
                Thread.Sleep(3000);
                
                //PlayerHand[pcard1] = PlayDeck.Deal(); // deals two more cards to the hand to replace 
                //PlayerHand[pcard2] = PlayDeck.Deal(); // the cards that were played 
                // PlayDeck.Shuffle();
                game++; // value of game variable increases by one each iteration of loop (each round)
                PlayDeck = new Deck();
            }
            while (game <= rounds); // loop continues until game value is equal to one (one round) or less than or equal to number of rounds
            if (playerScore > compScore)
            {
                Console.WriteLine("Player wins overall!");
            }
            else if (compScore > playerScore)
            {
                Console.WriteLine("Computer wins overall!");
            }
            else
            {
                Console.WriteLine("It is a draw overall!");
            }
            playerScore = 0;
            compScore = 0;

            
        }

        private string GetName()
        {
            return playername; // returns name parameter used in GameLoop method
        }
        
        private int CompCardOne()
        {
            int num1 = randNum.Next(1, 10);
            return num1;

        }

        private int CompCardTwo(int num)
        {
            int num2 = randNum.Next(1, 10);
            while (num == num2)
            {
                num2 = randNum.Next(1,10);
            }
            return num2;
        }

        public void InvalidInput(string check)
        {
            if (check != "yes" || check != "no") throw new InvalidInputException("Please enter yes or no.");
        }
        
    }
}
