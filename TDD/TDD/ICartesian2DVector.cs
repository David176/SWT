namespace TDD
{
    public class ICartesian2DVector
    {
        private ICartesian2DVector()
        { }

        private ICartesian2DVector(int coordinateX, int coordinateY)
        {
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
        }
       
       public int CoordinateX { get; set; }
       public int CoordinateY { get; set; }

    }
}