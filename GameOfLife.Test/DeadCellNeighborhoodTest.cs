using System;
using System.Collections.Generic;
using Xunit;

namespace GameOfLife.Test
{
    public class DeadCellNeightbourhoodTest
    {
        private NeighbourhoodHelper nh = new NeighbourhoodHelper(new CoordinateConverter(new Universe(5, 5)));
        private Coordinate centerPoint = new Coordinate(2, 2);
        private Coordinate topLeftNeighbour = new Coordinate(1, 1);
        private Coordinate topNeighbour = new Coordinate(1, 2);
        private Coordinate topRightNeighbour = new Coordinate(1, 3);
        private Coordinate distanceNeighbour = new Coordinate(4, 4);
        private CoordinateComparer _comparer = new CoordinateComparer();
        public DeadCellNeightbourhoodTest()
        {
        }

        [Fact]
        public void ShouldRepresentLiveNeighborsWithAList()
        {
            var neighborhood = new DeadCellNeighbourhood(topLeftNeighbour, nh);
            var result = neighborhood.LiveCellNeighbours;

            Assert.True(result is List<Coordinate>);
        }

        [Fact]
        public void ShouldContainAdjacentLiveCoordinatesInLiveNeighbours()
        {
            var coordinates = new List<Coordinate> { topLeftNeighbour, topNeighbour, distanceNeighbour };
            var neighborhood = new DeadCellNeighbourhood(centerPoint, nh);
            neighborhood.FindNeighbours(coordinates);

            Assert.True(_comparer.Contains(topLeftNeighbour, neighborhood.LiveCellNeighbours));
            Assert.True(_comparer.Contains(topNeighbour, neighborhood.LiveCellNeighbours));
            Assert.False(_comparer.Contains(distanceNeighbour, neighborhood.LiveCellNeighbours));
        }

    }
}
