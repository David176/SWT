using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;
using TDD;


namespace TDDUnitTest
{
    [TestFixture]
    public class VectorCalculatorUnitTest
    {
        [Test]
        public void VectorCalculator_AddTwoVectors_TwoVectorAdded()
        {
            var VectorCalc = new VectorCalculator();
            var VectorA = new Cartesian2DVector(1,1);
            var VectorB = new Cartesian2DVector(2,2);
            var Vector = new Cartesian2DVector(0,0);
            
          // var vectorC= VectorCalc.AddTwoVectors(VectorA, VectorB);
            Assert.That(VectorA.coordinateX.Equals(VectorB.coordinateX));
           //Assert.That(VectorB.coordinateX == VectorA.coordinateX);
           
        }

        
      
        
    }
}
