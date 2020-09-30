using System;
using System.Collections.Generic;
using Xunit;

namespace GameOfLife.Test
{
    public class LivingCellNeightbourhoodTest
    {
        private CoordinateComparer _comparer;
        public LivingCellNeightbourhoodTest()
        {
            _comparer = new CoordinateComparer();
        }

        Coordinate coordinateCP = new Coordinate(2, 2);
        Coordinate coordinate1 = new Coordinate(1, 1);
        Coordinate coordinate2 = new Coordinate(1, 2);
        Coordinate coordinate3 = new Coordinate(1, 3);
        Coordinate coordinate4 = new Coordinate(4, 4);
        NeighbourhoodHelper nh = new NeighbourhoodHelper(new CoordinateConverter(new Universe(5, 5)));

        [Fact]
        public void ShouldRepresentLivingNeighborsWithAList()
        {
            var neighborhood = new LivingCellNeighbourhood(coordinate1, nh);
            var result = neighborhood.LivingNeighbours;

            Assert.True(result is List<Coordinate>);
        }

        [Fact]
        public void ShouldContainAdjacentLivingCoordinatesInLivingNeighbours()
        {
            var coordinates = new List<Coordinate> { coordinate1, coordinate2, coordinate4 };
            var neighborhood = new LivingCellNeighbourhood(coordinateCP, nh);
            neighborhood.FindNeighbours(coordinates);

            Assert.True(_comparer.Contains(coordinate1, neighborhood.LivingNeighbours));
            Assert.True(_comparer.Contains(coordinate2, neighborhood.LivingNeighbours));
            Assert.False(_comparer.Contains(coordinate4, neighborhood.LivingNeighbours));
        }

        [Fact]
        public void ShouldHaveUnmatchedCoordinatesInDeadNeighbours()
        {
            var coordinates = new List<Coordinate> { coordinate1, coordinate2, coordinate4 };
            var neighborhood = new LivingCellNeighbourhood(coordinateCP, nh);
            neighborhood.FindNeighbours(coordinates);

            Assert.True(neighborhood.DeadNeighbours.Count == 6);
        }
    }
}
