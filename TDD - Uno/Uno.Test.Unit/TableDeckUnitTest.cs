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
            uut.PutCard(new Card(1,1, new CardRules(9, 0, 4)));
            Assert.That(uut.CardsOnTable.Count, Is.EqualTo(1));
        }

        [Test]
        public void TopCard_TableDeckWithOneCard_TopCardIsReturnedColor()
        {
            uut.PutCard(new Card(3,2, new CardRules(9, 0, 4)));
            Assert.That(uut.TopCard().Color, Is.EqualTo(new Card(3,2, new CardRules(9, 0, 4)).Color));
        }

        [Test]
        public void TopCard_TableDeckWithOneCard_TopCardIsReturnedNumber()
        {
            uut.PutCard(new Card(3, 2, new CardRules(9, 0, 4)));
            Assert.That(uut.TopCard().Number, Is.EqualTo(new Card(3, 2, new CardRules(9, 0, 4)).Number));
        }

        [Test]
        public void TopCard_TableDeckWithCards_TopCardIsReturnedColor()
        {
            uut.PutCard(new Card(1,1, new CardRules(9, 0, 4)));
            uut.PutCard(new Card(5,0, new CardRules(9, 0, 4)));
            uut.PutCard(new Card(3, 2, new CardRules(9, 0, 4)));
            Assert.That(uut.TopCard().Color, Is.EqualTo(new Card(3, 2, new CardRules(9, 0, 4)).Color));
        }
    }
}