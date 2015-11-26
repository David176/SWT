using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;

namespace Uno.Test.Unit
{
    [TestFixture]
    class PlayerUnitTest
    {
        private Player uut;
        private UnoGame _unoGame;
        
        [SetUp]
        public void Setup()
        {
            _unoGame = new UnoGame(Substitute.For<ITableDeck>(), Substitute.For<IDeck>(), new CardRules(9,0,4));
            uut = new Player(_unoGame, "Hans");

        }

        [Test]
        public void ReceiveCard_PlayerReceivesCard_HandCountIsOne()
        {
            uut.ReceiveCard(new Card(1,1, new CardRules(9, 0, 4)));
            Assert.That(uut.Hand.Count, Is.EqualTo(1));
        }

        [Test]
        public void PlayCard_PlayerPlaysACard_PlayerHasOneLessCard()
        {
            var allowedCards = new List<Card>();
            allowedCards.Add(new Card(1,1, new CardRules(9, 0, 4)));
            allowedCards.Add(new Card(2,2, new CardRules(9, 0, 4)));
            allowedCards.Add(new Card(1,3, new CardRules(9, 0, 4)));
            allowedCards.Add(new Card(1,2, new CardRules(9, 0, 4)));

            uut.ReceiveCard(new Card(1,0, new CardRules(9, 0, 4)));
            uut.ReceiveCard(new Card(1,2, new CardRules(9, 0, 4)));
            uut.ReceiveCard(new Card(1, 3, new CardRules(9, 0, 4)));

            int cardsPrevoiusly = uut.Hand.Count;
            uut.PlayIfAllowed(allowedCards);
            Assert.That(uut.Hand.Count, Is.EqualTo(cardsPrevoiusly-1));
        }
        
        
        
    }
}
