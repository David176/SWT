using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno
{
    public class Deck
    {
        public List<Card> CurrentDeck;
        private readonly IConsoleWriter _consoleWriter;

        public Deck(IConsoleWriter consoleWriter)
        {
            CurrentDeck = new List<Card>();
            _consoleWriter = consoleWriter;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    CurrentDeck.Add(new Card(j, i));
                }
            }
        }

        public bool DealCard(Player player)
        {
            if (CurrentDeck.Count == 0)
            {
                DeckIsEmpty();
                return false;
            }
            player.ReceiveCard(CurrentDeck[0]);
            CurrentDeck.RemoveAt(0);
            return true;
        }

        public void DeckIsEmpty()
        {
            _consoleWriter.WriteToScreen("Deck is empty");
        }

        public void DealCards(List<Player> players)
        {
            foreach (var player in players)
            {
                for (var i = 0; i < 7; i++)
                {
                    DealCard(player);
                        return;
                }
            }
        }
    }
}
