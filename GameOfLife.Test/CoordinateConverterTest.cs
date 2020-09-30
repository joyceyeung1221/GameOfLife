using System;
using Xunit;
namespace GameOfLife.Test
{
    public class CoordinateConverterTest
    {
        private CoordinateComparer _comparer;
        private Universe _universe;
        public CoordinateConverterTest()
        {
            _comparer = new CoordinateComparer();
            _universe = new Universe(10, 10);
        }
        

        [Theory]
        [InlineData(0,0,6,7,5,6)]
        [InlineData(0,1,6,1,6,10)]
        [InlineData(2,2,10,10,1,1)]
        [InlineData(0,2,10,1,1,10)]
        public void ShouldReturnCoordinate(int row, int col, int CPX, int CPY, int X, int Y)
        {
            var coordinate = new Coordinate(CPX, CPY);
            var coordinateConverter = new CoordinateConverter(_universe);
            var result = coordinateConverter.CreateCoordinateByIndex(row, col, coordinate);
            var expected = new Coordinate(X, Y);
            Assert.True(_comparer.Equals(result, expected));
        }
    }
}
