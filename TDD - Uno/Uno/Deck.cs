using System;
using System.Collections.Generic;
using System.Threading;

namespace Uno
{
    public interface IDeck
    {
        void DealCards(List<Player> players, ITableDeck tableDeck);
        void Shuffle(ITableDeck tableDeck);
        Card DrawFromDeck();
        CardRules GetCardRules();
    }

    public class Deck : IDeck
    {
        public List<Card> CurrentDeck;
        private CardRules _cardRules;
        private static readonly Random rng = new Random();

        public Deck(CardRules cardRules)
        {
            CurrentDeck = new List<Card>();
            _cardRules = cardRules;

            for (int k = 0; k < 2; k++) //amount of duplicates
            {
                for (int i = 0; i < _cardRules.AmountOfColors; i++) //each color
                {
                    for (int j = _cardRules.LowestNumber; j <= _cardRules.HighestNumber; j++) //each number
                    {
                        CurrentDeck.Add(new Card(j, i, _cardRules));
                    }
                }
            }
        }

        public CardRules GetCardRules()
        {
            return _cardRules;
        }

        public bool DealCard(Player player)
        {
            if (CurrentDeck.Count == 0)
            {
                DeckIsEmpty();
                return false;
            }
            player.ReceiveCard(CurrentDeck[0]);
            Console.Write("\rPlayer "+player.Name+" received a card");
            Thread.Sleep(400);
            CurrentDeck.RemoveAt(0);
            return true;
        }

        public void DeckIsEmpty()
        {
            Console.WriteLine("Deck is empty");
        }

        public void DealCards(List<Player> players, ITableDeck tableDeck)
        {
            for (var i = 0; i < 7; i++)
            {
                foreach (var player in players)
                {
                    if(!DealCard(player))
                        return;
                }
            }
            tableDeck.PutCard(CurrentDeck[0]);
            CurrentDeck.RemoveAt(0);
        }

        private void Restock(ITableDeck tableDeck)
        {
            while (tableDeck.CardsOnTable.Count > 0)
            {
                CurrentDeck.Add(tableDeck.CardsOnTable[0]);
                tableDeck.CardsOnTable.RemoveAt(0);
            }
        }

        public void Shuffle(ITableDeck tableDeck)
        {
            Restock(tableDeck);
            int dots;
            int n = CurrentDeck.Count;
            Console.Write("\rShuffling deck");
            while (n > 1)
            {
                dots = Math.Abs(n - CurrentDeck.Count);
                Console.Write("\rShuffling deck");
                do
                {
                    Console.Write(".");
                    dots-= 2;
                } while (dots > 0);
                Thread.Sleep(30);


                n--;
                int k = rng.Next(n + 1);
                var value = CurrentDeck[k];
                CurrentDeck[k] = CurrentDeck[n];
                CurrentDeck[n] = value;

            }
            Console.Write("\n");
        }

        public Card DrawFromDeck()
        {
            Card returnCard = CurrentDeck[0];
            CurrentDeck.RemoveAt(0);
            return returnCard;
        }
    }
}
