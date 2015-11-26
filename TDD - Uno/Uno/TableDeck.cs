using System.Collections.Generic;

namespace Uno
{
    public interface ITableDeck
    {
        void PutCard(Card card);
        Card TopCard();
    }

    public class TableDeck : ITableDeck
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