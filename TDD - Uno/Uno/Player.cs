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
        public TableDeck TableDeck;

        public Player(TableDeck tableDeck)
        {
            TableDeck = tableDeck;
            Hand = new List<Card>();
        }

        public void ReceiveCard(Card card)
        {
            Hand.Add(card);
        }

        public void PlayCard()
        {
            foreach (var PlayerCard in Hand)
            {
                if (TableDeck.TopCard().Color == PlayerCard.Color)
                {
                    TableDeck.PutCard(PlayerCard);
                    Hand.Remove(PlayerCard);
                }
            }
        }

    }
}
