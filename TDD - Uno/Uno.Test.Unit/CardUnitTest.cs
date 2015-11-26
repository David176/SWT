using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Uno.Test.Unit
{
    [TestFixture]
    public class CardUnitTest
    {
        [Test]
        public void CardConstructor_NumberHigherThanNine_NumberSetToNegativeOne()
        {
            Card uut = new Card(10, 4, new CardRules(9, 0, 4));
            Assert.That(uut.Number == -1);
        }

        [Test]
        public void CardConstructor_NumberLowerThanZero_NumberSetToNegativeOne()
        {
            Card uut = new Card(-34, 4, new CardRules(9, 0, 4));
            Assert.That(uut.Number == -1);
        }

        [Test]
        public void CardConstructor_ColorHigherThree_ColorSetToNegativeOne()
        {
            Card uut = new Card(2, 4, new CardRules(9, 0, 4));
            Assert.That((int)uut.Color == -1);
        }

        [Test]
        public void CardConstructor_ColorLowerThanZero_ColorSetToNegativeOne()
        {
            Card uut = new Card(2, -3, new CardRules(9, 0, 4));
            Assert.That((int)uut.Color == -1);
        }

        [Test]
        public void CardConstructor_ColorAssignedToThree_ColorIsThree()
        {
            Card uut = new Card(2, 3, new CardRules(9, 0, 4));
            Assert.That((int)uut.Color == 3);
        }


    }
}
