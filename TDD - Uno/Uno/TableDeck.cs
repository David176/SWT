using System.Collections.Generic;

namespace Uno
{
    public interface ITableDeck
    {
        void PutCard(Card card);
        Card TopCard();
        List<Card> CurrentlyAllowedCards(CardRules cardRules);
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

        public List<Card> CurrentlyAllowedCards(CardRules cardRules)
        {
            var allowedCards = new List<Card>();

            for (var i = cardRules.LowestNumber; i <= cardRules.HighestNumber; i++) // add all numbers of top card color
            {
                allowedCards.Add(new Card(i, (int)TopCard().Color, cardRules));
            }
            for (var i = 0; i < cardRules.AmountOfColors; i++)
            {
                allowedCards.Add(new Card(TopCard().Number, i, cardRules));
            }
            return allowedCards;
        }
    }
}