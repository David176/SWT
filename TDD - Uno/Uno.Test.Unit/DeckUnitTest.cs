using System.Collections.Generic;
using NUnit.Framework;
using NSubstitute;

namespace Uno.Test.Unit
{
    [TestFixture]
    public class DeckUnitTest
    {
        private Deck uut;
        private IConsoleWriter _consoleWriter;
        [SetUp]
        public void Setup()
        {
            _consoleWriter = Substitute.For<IConsoleWriter>();
            uut = new Deck(_consoleWriter);

        }
        [Test]
        public void Constructor_GeneratesListOfCards_CountEqualNumberTimesColor()
        {
            Assert.That(uut.CurrentDeck.Count, Is.EqualTo(40));
        }

        [Test]
        public void Constructor_GeneratesExactlyTenOfEachColor()
        {
            int red = 0;
            int green = 0;
            int blue = 0;
            int yellow = 0;
            bool TenOfEach = false;
            for (int i = 0; i < uut.CurrentDeck.Count; i++)
            {
                switch (uut.CurrentDeck[i].Color)
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
            if (red == 10 && green == 10 && blue == 10 && yellow == 10)
                TenOfEach = true;
            Assert.That(TenOfEach, Is.True);
        }

        [Test]
        public void DealCards_PlayerOneGetSevenCards()
        {
            
            var playerOne = new Player();
            var listOfPlayers = new List<Player>();
            listOfPlayers.Add(playerOne);

            uut.DealCards(listOfPlayers);
            Assert.That(playerOne.Hand.Count, Is.EqualTo(7));
        }

        [Test]
        public void DealCards_PlayersGetSevenCards()
        {
            var playerOne = new Player();
            var playerTwo = new Player();
            var playerThree = new Player();

            var listOfPlayers = new List<Player>();
            listOfPlayers.Add(playerOne);
            listOfPlayers.Add(playerTwo);
            listOfPlayers.Add((playerThree));

            uut.DealCards(listOfPlayers);
            for (int i = 0; i < listOfPlayers.Count; i++)
            {
                Assert.That(listOfPlayers[i].Hand.Count, Is.EqualTo(7));
            }
        }

        [Test]
        public void DealCard_DealsACard_CheckForEmptyStack()
        {
            var player = new Player();

            
                while(uut.DealCard(player));
            

            _consoleWriter.Received(1).WriteToScreen("Deck is empty");
        }
    }
}