using System.Collections.Generic;

namespace Uno
{
    public class TableDeck
    {
        public List<Card> CardsOnTable;

        public TableDeck()
        {
            CardsOnTable = new List<Card>();
        }

        public void PutCard(Card card)
        {
            CardsOnTable.Add(card);
        }

        public Card TopCard()
        {
            return CardsOnTable[CardsOnTable.Count-1];
        }
    }
}