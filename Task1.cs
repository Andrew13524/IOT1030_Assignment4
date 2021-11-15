using System;
using System.Collections.Generic;

namespace A4
{
	enum Values
	{
		Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King
	}

	enum Suits
	{
		Clubs, Diamonds, Hearts, Spades
	}

	class Card
	{
		public Values Value { get; private set; }
		public Suits Suit { get; private set; }

		public Card(Values value, Suits suit)
		{
			Value = value;
			Suit = suit;
		}

		public override string ToString()
		{
			return $"{Value} of {Suit}";
		}
	}

	class CardComparerByValue : IComparer<Card>
	{
		/// <summary>
		/// Value order is intuitive going in ascending order from A,2,...,Q,K
		/// Suit should be ordered as follows: Clubs, Diamonds, Hearts, Spades (same as enum ordering)
		/// </summary>
		public int Compare(Card a, Card b)
		{
			if (CompareSuit(a.Suit, b.Suit) == 1)
				return 1; 
			else if (CompareSuit(a.Suit,b.Suit) == 0)
            {
				if (a.Value > b.Value)
					return 1;
				else if (a.Value < b.Value)
					return -1;
				else
					return 0;
			}
			else
				return -1;
		}
		private int CompareSuit(Suits a, Suits b)
        {
			if (a > b)
				return 1;
			else if (a < b)
				return -1;
			else
				return 0;
        }
	}
}
