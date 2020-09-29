using System;
using System.Collections.Generic;
using Xunit;

namespace GameOfLife.Test
{
    public class NeightbourhoodTest
    {
        [Theory]
        [InlineData(1,1)]
        public void ShouldRepresentLivingNeighborsWithAList(int col, int row)
        {
            var coordinate = new Coordinate(col, row);
            var neighborhood = new Neighbourhood(coordinate);
            var result = neighborhood.LivingNeighbours;

            Assert.True(result is List<Cell>);

        }
    }
}
