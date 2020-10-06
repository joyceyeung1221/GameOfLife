using System;
using Xunit;
namespace GameOfLife.Test
{
    public class LocationConverterTest
    {
        private Universe _universe;
        public LocationConverterTest()
        {
            _universe = new Universe(10, 10);
        }
        

        [Theory]
        [InlineData(0,0,6,7,5,6)]
        [InlineData(0,1,1,5,10,5)]
        [InlineData(2,2,10,10,1,1)]
        [InlineData(0,2,10,1,9,2)]
        public void ShouldReturnLocation(int rowN, int colN, int centerPointRow, int CenterPointCol, int ExpectedRow, int ExpectedCol)
        {
            var location = new Location(centerPointRow, CenterPointCol);
            var locationConverter = new LocationConverter(_universe);
            var result = locationConverter.CreateLocationByIndex(rowN, colN, location);
            var expected = new Location(ExpectedRow, ExpectedCol);
            Assert.True(expected.IsEqual(result));
        }
    }
}
