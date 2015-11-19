using NUnit.Framework;

namespace Uno.Test.Unit
{
    [TestFixture]
    public class TableDeckUnitTest
    {
        private TableDeck uut;

        [SetUp]
        public void Setup()
        {
            uut = new TableDeck();
        }

        [Test]
        public void PutCard_TableDeckReceivesOneCard_DeckSizeIsOne()
        {
            uut.PutCard(new Card(1,1));
            Assert.That(uut.CardsOnTable.Count, Is.EqualTo(1));
        }

        [Test]
        public void TopCard_TableDeckWithOneCard_TopCardIsReturnedColor()
        {
            uut.PutCard(new Card(3,2));
            Assert.That(uut.TopCard().Color, Is.EqualTo(new Card(3,2).Color));
        }

        [Test]
        public void TopCard_TableDeckWithOneCard_TopCardIsReturnedNumber()
        {
            uut.PutCard(new Card(3, 2));
            Assert.That(uut.TopCard().Number, Is.EqualTo(new Card(3, 2).Number));
        }

        [Test]
        public void TopCard_TableDeckWithCards_TopCardIsReturnedColor()
        {
            uut.PutCard(new Card(1,1));
            uut.PutCard(new Card(5,0));
            uut.PutCard(new Card(3, 2));
            Assert.That(uut.TopCard().Color, Is.EqualTo(new Card(3, 2).Color));
        }
    }
}