using System;
using System.Collections.Generic;
using Xunit;

namespace GameOfLife.Test
{
    public class LiveCellNeightbourhoodTest
    {
        private NeighbourhoodHelper nh = new NeighbourhoodHelper(new CoordinateConverter(new Universe(5, 5)));
        private Coordinate coordinateCP = new Coordinate(2, 2);
        private Coordinate coordinate1 = new Coordinate(1, 1);
        private Coordinate coordinate2 = new Coordinate(1, 2);
        private Coordinate coordinate3 = new Coordinate(1, 3);
        private Coordinate coordinate4 = new Coordinate(4, 4);
        private CoordinateComparer _comparer = new CoordinateComparer();
        public LiveCellNeightbourhoodTest()
        {
        }

        [Fact]
        public void ShouldRepresentLiveNeighborsWithAList()
        {
            var neighborhood = new LiveCellNeighbourhood(coordinate1, nh);
            var result = neighborhood.LiveNeighbours;

            Assert.True(result is List<Coordinate>);
        }

        [Fact]
        public void ShouldOnlycontainAdjacentLivecoordinatesInLiveCellNeighbours()
        {
            var coordinates = new List<Coordinate> { coordinate1, coordinate2, coordinate4 };
            var neighborhood = new LiveCellNeighbourhood(coordinateCP, nh);
            neighborhood.FindNeighbours(coordinates);

            Assert.True(_comparer.Contains(coordinate1, neighborhood.LiveNeighbours));
            Assert.True(_comparer.Contains(coordinate2, neighborhood.LiveNeighbours));
            Assert.False(_comparer.Contains(coordinate4, neighborhood.LiveNeighbours));
        }

        [Fact]
        public void ShouldHaveUnmatchedcoordinatesInDeadNeighbours()
        {
            var coordinates = DummyData.listWith2LiveNeighbours;
            var neighborhood = new LiveCellNeighbourhood(coordinateCP, nh);
            neighborhood.FindNeighbours(coordinates);

            Assert.True(neighborhood.DeadNeighbours.Count == 6);
        }
    }
}
