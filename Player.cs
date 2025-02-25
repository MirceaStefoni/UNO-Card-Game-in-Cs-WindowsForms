using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectCFLP
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Hand { get; set; } = new List<Card>();

        public void DrawCard(Card card)
        {
            Hand.Add(card);
        }

        public void PlayCard(Card card)
        {
            Hand.Remove(card);
        }
    }
}
