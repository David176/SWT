using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno
{
    public class Player
    {
        string Name { get; set; }
        public List<Card> Hand;

        public Player()
        {
            Hand = new List<Card>();
        }

        public void ReceiveCard(Card card)
        {
            Hand.Add(card);
        }

        public void UseCard()
        {
            Hand.RemoveAt(0);
        }
    }
}
