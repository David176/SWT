using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD
{
    public class Cartesian2DVector : ICartesian2DVector
    {
       public int coordinateX { get; set; }
       public int coordinateY { get; set; }

        public Cartesian2DVector(int coordinateX, int coordinateY) : base(coordinateX, coordinateY)
        {
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
        }
    }
}
