using System.Collections.Generic;
using NUnit.Framework;
using NSubstitute;

namespace Uno.Test.Unit
{
    [TestFixture]
    public class DeckUnitTest
    {
        private Deck uut;
        private UnoGame _unoGame;
        private ITableDeck _tableDeck;

        [SetUp]
        public void Setup()
        {
            _tableDeck = Substitute.For<ITableDeck>();
            _unoGame = new UnoGame(Substitute.For<IDeck>());
            uut = new Deck(new CardRules(9,0,4));

        }
        [Test]
        public void Constructor_GeneratesListOfCards_CountEqualNumberTimesColor()
        {
            Assert.That(uut.CurrentDeck.Count, Is.EqualTo(80));
        }

        [Test]
        public void Constructor_GeneratesExactlyTwentyOfEachColor()
        {
            int red = 0;
            int green = 0;
            int blue = 0;
            int yellow = 0;
            bool TwentyOfEach = false;
            for (int i = 0; i < uut.CurrentDeck.Count; i++)
            {
                switch ((int)uut.CurrentDeck[i].Color)
                {
                    case 0:
                        red++;
                        break;
                    case 1:
                        green++;
                        break;
                    case 2:
                        blue++;
                        break;
                    case 3:
                        yellow++;
                        break;
                    default:
                        break;
                }
            }
            if (red == 20 && green == 20 && blue == 20 && yellow == 20)
                TwentyOfEach = true;
            Assert.That(TwentyOfEach, Is.True);
        }

        [Test]
        public void DealCards_PlayerOneGetSevenCards()
        {
            
            var playerOne = new Player(_unoGame, "Hans");
            var listOfPlayers = new List<Player>();
            listOfPlayers.Add(playerOne);

            uut.DealCards(listOfPlayers, ref _tableDeck);
            Assert.That(playerOne.Hand.Count, Is.EqualTo(7));
        }

        [Test]
        public void DealCards_PlayersGetSevenCards()
        {
            var playerOne = new Player(_unoGame, "Hans");
            var playerTwo = new Player(_unoGame, "Hans");
            var playerThree = new Player(_unoGame, "Hans");

            var listOfPlayers = new List<Player>();
            listOfPlayers.Add(playerOne);
            listOfPlayers.Add(playerTwo);
            listOfPlayers.Add((playerThree));

            uut.DealCards(listOfPlayers, ref _tableDeck);
            for (int i = 0; i < listOfPlayers.Count; i++)
            {
                Assert.That(listOfPlayers[i].Hand.Count, Is.EqualTo(7));
            }
        }

        
    }
}