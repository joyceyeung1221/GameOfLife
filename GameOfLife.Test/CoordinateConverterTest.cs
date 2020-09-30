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
            _universe = new Universe(50, 50);
        }
        

        [Theory]
        [InlineData(0,0,22,23,21,22)]
        [InlineData(2,1,22,23,22,24)]
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
