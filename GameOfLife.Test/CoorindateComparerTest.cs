using System;
using Xunit;
namespace GameOfLife.Test
{
    public class CoorindateComparerTest
    {
        public CoorindateComparerTest()
        {
        }

        CoordinateComparer comparer = new CoordinateComparer();
        [Theory]
        [InlineData(1,1,2,2,false)]
        [InlineData(2,2,2,2,true)]
        [InlineData(1,2,1,2,true)]
        public void ShouldReturnFalse_WhenTwoCoordinateHaveDifferentValue(int x1, int y1, int x2, int y2, bool expected)
        {
            var cd1 = new Coordinate(x1, y1);
            var cd2 = new Coordinate(x2, y2);
            var result = comparer.Equals(cd1, cd2);

            Assert.Equal(expected, result);
        }
    }
}
