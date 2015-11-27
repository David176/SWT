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

        public UnoGame(IDeck deck)
        {
            _tableDeck = new TableDeck();
            _deck = deck;
            _cardRules = _deck.GetCardRules();
            _playersInGame = new List<Player>();
            _currentPlayersTurn = 0;
        }

        public void AddPlayer(Player player)
        {
            _playersInGame.Add(player);
            Console.WriteLine(_playersInGame[_playersInGame.Count-1].Name+" added to the game. Currently "+_playersInGame.Count+" players in the game");
        }

        private void EmptyPlayerHands()
        {
            foreach (var player in _playersInGame)
            {
                var cardsFromPlayer = player.EmptyHand();
                for (int i = 0; i < cardsFromPlayer.Length; i++)
                {
                    _tableDeck.PutCard(cardsFromPlayer[i]);
                }
            }
        }

        public void StartGame()
        {
            _winnerFound = false;
            EmptyPlayerHands();
            _deck.Shuffle(_tableDeck);
            _deck.DealCards(_playersInGame, _tableDeck);
            
            Console.WriteLine("\nUnoGame started");
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
            _playersInGame[_currentPlayersTurn].StartTurn(); 
            _currentPlayersTurn++;
            if (_currentPlayersTurn >= _playersInGame.Count)
                _currentPlayersTurn = 0;
        }

        public void PlayerPlaysCard(Card card)
        {
            _tableDeck.PutCard(card);
        }

        public List<Card> CurrentlyAllowedCards()
        {
            return _tableDeck.CurrentlyAllowedCards(_cardRules);
        }

        public Card PlayerDrawsCard()
        {
            return _deck.DrawFromDeck();
        }
    }
}