using System;
using Xunit;
namespace GameOfLife.Test
{
    public class UniverseTest
    {
        public UniverseTest()
        {
        }

        [Theory]
        [InlineData(1,2,5,5,false)]
        [InlineData(0,2,5,5,true)]
        [InlineData(1,6,5,5,true)]
        public void ShouldReturnTrue_WhenLocationIsOnTheEdge(int colValue, int rowValue, int rowNum, int colNum, bool expected)
        {
            var universe = new Universe(rowNum, colNum);

            Assert.Equal(expected, (universe.IsColumnOverUnveriseEdge(colValue) || universe.IsRowOverUniverseEdge(rowValue)));
        }
    }
}
