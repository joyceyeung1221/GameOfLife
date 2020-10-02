using System;
using System.Collections.Generic;
using Xunit;

namespace GameOfLife.Test
{
    public class LiveCellNeightbourhoodTest
    {
        private NeighbourhoodHelper nh = new NeighbourhoodHelper(new LocationConverter(new Universe(5, 5)));
        private Location centerPoint = new Location(2, 2);
        private Location topLeftLocation = new Location(1, 1);
        private Location topLocation = new Location(1, 2);
        private Location topRightLocation = new Location(1, 3);
        private Location distanceLocation = new Location(4, 4);
        private LocationComparer _comparer = new LocationComparer();
        public LiveCellNeightbourhoodTest()
        {
        }

        [Fact]
        public void ShouldRepresentLiveNeighborsWithAList()
        {
            var neighborhood = new LiveCellNeighbourhood(topLeftLocation, nh);
            var result = neighborhood.LiveCellNeighbours;

            Assert.True(result is List<Location>);
        }

        [Fact]
        public void ShouldOnlycontainAdjacentLiveLocationsInLiveCellNeighbours()
        {
            var locations = new List<Location> { topLeftLocation, topLocation, distanceLocation };
            var neighborhood = new LiveCellNeighbourhood(centerPoint, nh);
            neighborhood.FindNeighbours(locations);

            Assert.True(_comparer.Contains(topLeftLocation, neighborhood.LiveCellNeighbours));
            Assert.True(_comparer.Contains(topLocation, neighborhood.LiveCellNeighbours));
            Assert.False(_comparer.Contains(distanceLocation, neighborhood.LiveCellNeighbours));
        }

        [Fact]
        public void ShouldHaveUnmatchedlocationsInDeadNeighbours()
        {
            var locations = new List<Location> { topLeftLocation, topLocation, distanceLocation };
            var neighborhood = new LiveCellNeighbourhood(centerPoint, nh);
            neighborhood.FindNeighbours(locations);

            Assert.True(neighborhood.DeadCellNeighbours.Count == 6);
        }
    }
}
