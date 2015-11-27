using System;
using System.Collections.Generic;
using System.Threading;

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
            PlayIfAllowed(cardsAllowedToPlay);
        }

        public Card[] EmptyHand()
        {
            var cardsInHand = new Card[Hand.Count];
            Hand.CopyTo(cardsInHand);
            Hand.Clear();
            return cardsInHand;
        }

        public void PlayIfAllowed(List<Card> cardsAllowedToPlay)
        {
            foreach (var playerCard in Hand)
            {
                foreach (var allowedCard in cardsAllowedToPlay)
                {
                    if (playerCard.Color == allowedCard.Color && playerCard.Number == allowedCard.Number)
                    {
                        PlayCard(playerCard);
                        return;
                    }
                }
            }
            DrawCard(cardsAllowedToPlay);
        }

        private void PlayCard(Card playerCard)
        {
            _unoGame.PlayerPlaysCard(playerCard);
            Console.WriteLine(Name + " plays " + playerCard.Color + " " + playerCard.Number+" and now has "+(Hand.Count-1)+" card(s) left");
            Hand.Remove(playerCard);
            if (Hand.Count == 0)
                _unoGame.WinnerFound(Name);
            Thread.Sleep(700);
        }

        private void DrawCard(List<Card> cardsAllowedToPlay)
        {
            Console.WriteLine(Name+" draws a card");
            Thread.Sleep(400);
            Card playerCard = _unoGame.PlayerDrawsCard();
            Hand.Add(playerCard);

            foreach (var allowedCard in cardsAllowedToPlay)
            {
                if (playerCard.Color == allowedCard.Color && playerCard.Number == allowedCard.Number)
                {
                    PlayCard(playerCard);
                    return;
                }
            }
        }
    }
}
