using System;
using System.Collections.Generic;
using System.Threading;

namespace Uno
{
    public class UnoGame
    {
        private ITableDeck _tableDeck;
        private IDeck _deck;
        private readonly CardRules _cardRules;
        private List<Player> _playersInGame;
        private int _currentPlayersTurn;
        private bool _winnerFound;

        public UnoGame(ITableDeck tableDeck, IDeck deck, CardRules cardRules)
        {
            _tableDeck = tableDeck;
            _deck = deck;
            _cardRules = cardRules;
            _playersInGame = new List<Player>();
            _currentPlayersTurn = 0;
            _winnerFound = false;
        }

        public void AddPlayer(Player player)
        {
            _playersInGame.Add(player);
            Console.WriteLine("Player added to the game. Currently "+_playersInGame.Count+" players in the game");
        }

        public void StartGame()
        {
            _deck.Shuffle();
            _deck.DealCards(_playersInGame, ref _tableDeck);
            
            Console.WriteLine("UnoGame started");
            do
            {
                NoticeNextPlayer();
                Thread.Sleep(200);
            } while (!_winnerFound);
        }

        public void WinnerFound(string nameOfPlayer)
        {
            _winnerFound = true;
            Console.WriteLine(nameOfPlayer+" has won the game");
        }

        
        public void NoticeNextPlayer()
        {
            Console.WriteLine("Player " + _currentPlayersTurn + " asked to start turn");
            _playersInGame[_currentPlayersTurn].StartTurn(); 
            _currentPlayersTurn++;
            if (_currentPlayersTurn >= _playersInGame.Count)
                _currentPlayersTurn = 0;
        }

        public void PlayCard(Card card)
        {
            _tableDeck.PutCard(card);
        }

        public List<Card> CurrentlyAllowedCards()
        {
            var topCard = _tableDeck.TopCard();
            var allowedCards = new List<Card>();

            for (var i = _cardRules.LowestNumber; i <= _cardRules.HighestNumber; i++) // add all numbers of top card color
            {
                allowedCards.Add(new Card(i, (int) topCard.Color, _cardRules));
            }
            for (var i = 0; i < _cardRules.AmountOfColors; i++)
            {
                allowedCards.Add(new Card(topCard.Number, i, _cardRules));
            }
            return allowedCards;
        }

        public Card PlayerDrawsCard()
        {
            return _deck.DrawFromDeck();
        }
    }
}