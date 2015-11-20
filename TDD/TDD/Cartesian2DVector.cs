using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD
{
    public class Cartesian2DVector : ICartesian2DVector
    {
        public Cartesian2DVector()
        {
            
        }
        public Cartesian2DVector(double _coordinateY, double _coordinateX)
        {
            coordinateX = _coordinateX;
            coordinateY = _coordinateY;
        }
        public double coordinateY { get; set; }
        public double coordinateX { get; set;  }

    }
}
