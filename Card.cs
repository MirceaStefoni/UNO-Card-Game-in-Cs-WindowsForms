using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectCFLP
{
    public enum CardColor { Red, Yellow, Green, Blue, Wild }
    public enum CardType { Number, Skip, Reverse, DrawTwo, DrawFour, Wild }

    public class Card
    {
        public CardColor Color { get; set; }
        public CardType Type { get; private set; }
        public int Number { get; private set; }

        // Constructor for action cards (Skip, Reverse, etc.)
        public Card(CardColor color, CardType type)
        {
            Color = color;
            Type = type;
            Number = -1; // No value for action cards
        }

        // Constructor for number cards
        public Card(CardColor color, int value)
        {
            Color = color;
            Type = CardType.Number;
            Number = value;
        }
        public override string ToString()
        {
            if (Type == CardType.Number)
            {
                return $"{Color} {Number}";
            }
            if (Type == CardType.Wild)
            {
                return $"{Color} Card";
            }
            else
            {
                return $"{Color} {Type}";
            }
        }

    }

}
