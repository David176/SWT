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

        [SetUp]
        public void Setup()
        {
            uut = new Player();

        }

        [Test]
        public void ReceiveCard_PlayerReceivesCard_HandCountIsOne()
        {
            uut.ReceiveCard(new Card(1,1));
            Assert.That(uut.Hand.Count, Is.EqualTo(1));
        }

        [Test]
        public void UseCard_PlayerUsesCard_HandCountIsOneLess()
        {
            uut.Hand.Add(new Card(1,1));
            uut.Hand.Add(new Card(2,2));
            int cardsPrevoiusly = uut.Hand.Count;
            uut.UseCard();
            Assert.That(uut.Hand.Count, Is.EqualTo(cardsPrevoiusly-1));
        }
        /*
        [Test]
        public void UseCard_UseGreenAndOnlyGreen_NoGreenSoNoneUsed()
        {
            uut.ReceiveCard(new Card(1,0));
            uut.ReceiveCard(new Card(1,1));
            uut.ReceiveCard(new Card(1, 2));
            int cardsPrevoiusly = uut.Hand.Count;
            uut.UseCard();
            Assert.That(cardsPrevoiusly, Is.EqualTo(uut.Hand.Count));
        }

        [Test]
        public void UseCard_UseGreenAndOnlyGreen_GreenExistSoUsedOne()
        {
            uut.ReceiveCard(new Card(1, 0));
            uut.ReceiveCard(new Card(1, 1));
            uut.ReceiveCard(new Card(1, 2));
            uut.ReceiveCard(new Card(1, 3));
            int cardsPrevoiusly = uut.Hand.Count;
            uut.UseCard();
            Assert.That(cardsPrevoiusly, Is.EqualTo(uut.Hand.Count-1));
        }
        */
    }
}
