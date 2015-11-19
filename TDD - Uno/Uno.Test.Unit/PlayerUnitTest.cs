using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Uno.Test.Unit
{
    [TestFixture]
    class PlayerUnitTest
    {
        private Player uut;
        private TableDeck _tableDeck;

        [SetUp]
        public void Setup()
        {
            _tableDeck = new TableDeck();
            uut = new Player(_tableDeck);

        }

        [Test]
        public void ReceiveCard_PlayerReceivesCard_HandCountIsOne()
        {
            uut.ReceiveCard(new Card(1,1));
            Assert.That(uut.Hand.Count, Is.EqualTo(1));
        }

        [Test]
        public void PlayCard_UseGreenAndOnlyGreen_NoGreenSoNoneUsed()
        {
            _tableDeck.PutCard(new Card(5,1));

            uut.ReceiveCard(new Card(1,0));
            uut.ReceiveCard(new Card(1,2));
            uut.ReceiveCard(new Card(1, 3));
            int cardsPrevoiusly = uut.Hand.Count;
            uut.PlayCard();
            Assert.That(cardsPrevoiusly, Is.EqualTo(uut.Hand.Count));
        }
        
        [Test]
        public void PlayCard_UseGreenAndOnlyGreen_GreenExistSoUsedOne()
        {
            _tableDeck.PutCard(new Card(5, 1));

            uut.ReceiveCard(new Card(1, 0));
            uut.ReceiveCard(new Card(1, 1));
            uut.ReceiveCard(new Card(1, 2));
            uut.ReceiveCard(new Card(1, 3));
            int cardsPrevoiusly = uut.Hand.Count;
            uut.PlayCard();
            Assert.That(cardsPrevoiusly, Is.EqualTo(uut.Hand.Count-1));
        }
        
    }
}
