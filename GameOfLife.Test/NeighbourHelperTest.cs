using System;
using System.Collections.Generic;
using Xunit;
namespace GameOfLife.Test
{
    public class NeighbourHelperTest
    {
        private NeighbourhoodHelper nh = new NeighbourhoodHelper(new LocationConverter(new Universe(50, 50)));
        private Location locationCP = new Location(2, 2);
        private Location location1 = new Location(1, 1);
        private Location location2 = new Location(1, 2);
        private Location location3 = new Location(1, 3);
        private Location location4 = new Location(4, 4);
        public NeighbourHelperTest()
        {
        }

        [Fact]
        public void ShouldCreate3By3Array()
        {
            var result = nh.FormNeighbourhoodBoundaries();

            Assert.True(result.GetLength(0) == 3 && result.GetLength(1) == 3);
        }

        [Fact]
        public void ShouldBuildAnArrayFilledNeighbourByLocation()
        {
            var CP = new Location(7, 9);
            var division = nh.FormNeighbourhoodBoundaries();
            nh.FindLocation(division, CP);

            Assert.IsType<Location[,]>(division);
            Assert.True(division[0, 0].Column == 8 && division[0, 0].Row == 6);
            Assert.True(division[1, 2].Column == 10 && division[1, 2].Row == 7);
            Assert.True(division[1, 1] == null);
        }

        [Fact]
        public void ShouldReturnMatchedCoorindate()
        {
            var locations = new List<Location> { location1, location2, location4 };
            var division = nh.FormNeighbourhoodBoundaries();
            nh.FindLocation(division, locationCP);
            var result = nh.FindLiveCellNeighbours(division, locations);

            Assert.True(result.Count == 2);
        }
    }
}
