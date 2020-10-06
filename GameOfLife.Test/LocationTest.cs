using System;
using Xunit;
namespace GameOfLife.Test
{
    public class LocationTest
    {
        public LocationTest()
        {
        }

        [Theory]
        [InlineData(1, 1, 2, 2, false)]
        [InlineData(2, 2, 2, 2, true)]
        [InlineData(1, 2, 1, 2, true)]
        public void ShouldReturnFalse_WhenTwoLocationHaveDifferentValue(int x1, int y1, int x2, int y2, bool expected)
        {
            var cd1 = new Location(x1, y1);
            var cd2 = new Location(x2, y2);
            var result = cd1.IsEqual(cd2);

            Assert.Equal(expected, result);
        }
    }
}
