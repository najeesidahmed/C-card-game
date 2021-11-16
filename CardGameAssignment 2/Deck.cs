using System;
using System.Collections.Generic;

namespace CardGameAssignment
{
    public class Deck
    {
        protected List<Card> Cards { get; set; }
        private string[] Suits = { "Hearts", "Diamonds", "Spades", "Clubs" };
        private Random randNum = new Random();
        private int currentCard;

        public Deck() // deck constructor 
        {
            Cards = new List<Card>(52); // initiate deck
            

            for (int y = 2; y < 11; y++) // loop through card values 1-10
            {
                Cards.Add(new Card(y.ToString(), "Clubs")); // create card objects with number and suit values and populates deck
                Cards.Add(new Card(y.ToString(), "Hearts"));
                Cards.Add(new Card(y.ToString(), "Diamonds"));
                Cards.Add(new Card(y.ToString(), "Spades"));

            }
            foreach (string s in Suits) // loops through all suits in suits array
            {
                Cards.Add(new Card("Ace", s)); // create card objects with face values and populate deck 
                Cards.Add(new Card("Jack", s));
                Cards.Add(new Card("Queen", s));
                Cards.Add(new Card("King", s));
            }
        }

        public void Shuffle() // fisher yates shuffle method 
        {
            for (int n = Cards.Count - 1; n > 0; --n)
            {
                int k = randNum.Next(0, Cards.Count);
                Card temp = Cards[n];
                Cards[n] = Cards[k];
                Cards[k] = temp;
            }
        }

        public Card Deal()
        {
            if (currentCard < Cards.Count)
            {
                return Cards[currentCard++];
                
            }
            else
            {
                return null;
            }
        }

        public bool isEmpty()
        {
            if (Cards.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
                

        }
    }
}
