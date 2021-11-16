using System;
using System.Collections.Generic;

namespace CardGameAssignment
{
	public class Card
	{

		private string value; // Card properties 
		private string suit;

		public Card(string cardValue, string cardSuit) // card constructor
		{
			
			value = cardValue;
			suit = cardSuit;
		}

		public override string ToString()
		{
			return value + " of " + suit; // card properties returned as string values 
		}
	}
}
