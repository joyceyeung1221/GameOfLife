using System;
using System.Collections.Generic;
using Xunit;

namespace GameOfLife.Test
{
    public class DeadCellNeightbourhoodTest
    {
        private NeighbourhoodHelper nh = new NeighbourhoodHelper(new LocationConverter(new Universe(5, 5)));
        private Location centerPoint = new Location(2, 2);
        private Location topLeftCoordinate = new Location(1, 1);
        private Location topCoordinate = new Location(1, 2);
        private Location topRightCoordinate = new Location(1, 3);
        private Location distanceCoordinate = new Location(4, 4);
        private LocationComparer _comparer = new LocationComparer();
        public DeadCellNeightbourhoodTest()
        {
        }

        [Fact]
        public void ShouldRepresentLiveNeighborsWithAList()
        {
            var neighborhood = new DeadCellNeighbourhood(topLeftCoordinate, nh);
            var result = neighborhood.LiveCellNeighbours;

            Assert.True(result is List<Location>);
        }

        [Fact]
        public void ShouldContainAdjacentLiveCoordinatesInLiveNeighbours()
        {
            var coordinates = new List<Location> { topLeftCoordinate, topCoordinate, distanceCoordinate };
            var neighborhood = new DeadCellNeighbourhood(centerPoint, nh);
            neighborhood.FindNeighbours(coordinates);

            Assert.True(_comparer.Contains(topLeftCoordinate, neighborhood.LiveCellNeighbours));
            Assert.True(_comparer.Contains(topCoordinate, neighborhood.LiveCellNeighbours));
            Assert.False(_comparer.Contains(distanceCoordinate, neighborhood.LiveCellNeighbours));
        }

    }
}
