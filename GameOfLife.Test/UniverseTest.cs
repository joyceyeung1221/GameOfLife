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
        public void ShouldReturnTrue_WhenCooridateIsOnTheEdge(int x, int y, int row, int col, bool expected)
        {
            var universe = new Universe(row, col);

            Assert.Equal(expected, (universe.IsXOverUnveriseEdge(x) || universe.IsYOverUniverseEdge(y)));
        }
    }
}
