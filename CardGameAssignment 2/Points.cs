using System;
namespace CardGameAssignment
{
    public class Points
    {

        public static int Point(string card) // method for assigning calues to cards
        {
            int point;
            string[] splitted = card.Split(" "); //  splits the Card object string and assigns value 
            if (splitted[0] == "Jack")
                point = 11;
            else if (splitted[0] == "Queen")
                point = 12;
            else if (splitted[0] == "King")
                point = 13;
            else if (splitted[0] == "Ace")
                point = 14;
            else
                point = Int32.Parse(splitted[0]); // converts string index into integer 

            return point; // returns integer value of card 
        }

        public static int WinChecker(int Pcard1, int Pcard2, int Ccard1, int Ccard2) // caclulates total value of each players cards, and compares them to decide who won the round 
        {
            int PlayerWin;
            int PlayerScore = Pcard1 + Pcard2; // sum of players cards
            int CompScore = Ccard1 + Ccard2; // sum of computers carfs 

            if (PlayerScore > CompScore) // if players total greater than computers
                PlayerWin = 1; // assign value of 1
            else if (PlayerScore == CompScore) // if totals are equal
                PlayerWin = 0; // assign value of 0
            else
                PlayerWin = 2; // else assign value of 2

            return PlayerWin; // returns either 0, 1 or 2 which covers win, lose or draw for both players 

        }

        public static int RecieveIndexOne()
        {
            while (true) // method loops until correct input is entered
            {
                try
                {
                    Console.WriteLine("Which card would you like to play first? (1-10): "); // takes user input for which card they want to play
                    int num1 = Int32.Parse(Console.ReadLine());
                    InputRangeCheck(num1);
                    return num1;

                }
                catch (FormatException) // error handling for an input that is not a number 
                {
                    Console.WriteLine("Please enter a number.");
                    continue;

                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }
        public static int RecieveIndexTwo(int num)
        {
            while (true) // method loops until correct input is entered 
            {
                try
                {
                    Console.WriteLine("What is the second card you wish to play? (1-10)");
                    int num1 = Int32.Parse(Console.ReadLine());
                    InputRangeCheck(num1);
                    SameNumberCheck(num, num1); // method called to check if same card played 
                    return num1; //breaks loop if valid by returning a value
                }
                catch (FormatException)
                {
                    Console.WriteLine("You need to enter a valid number."); // error handling for invalid input 
                    continue; // loop continues to ensure correct input
                }
                catch (SameNumberException e) // custom exception caught if same numbers entered
                {
                    Console.WriteLine(e.Message); // message property invoked
                    continue; // continues loop until valid input 
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                
            }
        }

        private static void SameNumberCheck(int num1, int num2) // encapsulated method takes 2 integers parameters as arguments  
        {
            if (num1 == num2) throw new SameNumberException("You cannot play the same card twice, please play another."); // throws custom exception if numbers are equal 

        }

        private static void InputRangeCheck(int num) // encapsulated method takes an integer parameter as argument 
        {
            if (num < 1 || num > 10) throw new IndexOutOfRangeException("Please enter a number between 1-10,"); // throws custom exception if input integer is out of range 
        }

    }
}
