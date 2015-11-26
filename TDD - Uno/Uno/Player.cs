using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Uno
{
    public class Player
    {
        public string Name { get; }
        public List<Card> Hand;
        private readonly UnoGame _unoGame;
        

        public Player(UnoGame unoGame, string name)
        {
            _unoGame = unoGame;
            Hand = new List<Card>();
            Name = name;
        }

        public void ReceiveCard(Card card)
        {
            Hand.Add(card);
        }

        public void StartTurn()
        {
            var cardsAllowedToPlay = _unoGame.CurrentlyAllowedCards();
            PlayCard(cardsAllowedToPlay);
        }

        public void PlayCard(List<Card> cardsAllowedToPlay)
        {
            foreach (var playerCard in Hand)
            {
                foreach (var allowedCard in cardsAllowedToPlay)
                {
                    if (playerCard.Color == allowedCard.Color && playerCard.Number == allowedCard.Number)
                    {
                        _unoGame.PlayCard(playerCard);
                        Console.WriteLine(Name+" plays "+playerCard.Color+" "+playerCard.Number);
                        Hand.Remove(playerCard);
                        return;
                    }
                }
            }
            Console.WriteLine(Name+" passes his turn");
            Thread.Sleep(2000);
        }
    }
}
