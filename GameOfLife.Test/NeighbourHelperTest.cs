using System;
using System.Collections.Generic;
using Xunit;
namespace GameOfLife.Test
{
    public class NeighbourHelperTest
    {
        public NeighbourHelperTest()
        {
        }
        Coordinate coordinateCP = new Coordinate(2, 2);
        Coordinate coordinate1 = new Coordinate(1, 1);
        Coordinate coordinate2 = new Coordinate(1, 2);
        Coordinate coordinate3 = new Coordinate(1, 3);
        Coordinate coordinate4 = new Coordinate(4, 4);
        NeighbourhoodHelper nh = new NeighbourhoodHelper(new CoordinateConverter(new Universe(50, 50)));

        [Fact]
        public void ShouldCreate3By3Array()
        {
            var result = nh.FormNeighbourhoodBoundaries();

            Assert.True(result.GetLength(0) == 3 && result.GetLength(1) == 3);
        }

        [Fact]
        public void ShouldBuildAnArrayFilledNeighbourByCoordinate()
        {
            var coordinateCP = new Coordinate(9, 7);
            var division = nh.FormNeighbourhoodBoundaries();
            nh.FillCoorindate(division, coordinateCP);

            Assert.IsType<Coordinate[,]>(division);
            Assert.True(division[0, 0].X == 8 && division[0, 0].Y == 6);
            Assert.True(division[1, 2].X == 10 && division[1, 2].Y == 7);
            Assert.True(division[1, 1] == null);
        }

        [Fact]
        public void ShouldReturnMatchedCoorindate()
        {
            var coordinates = new List<Coordinate> { coordinate1, coordinate2, coordinate4 };
            var division = nh.FormNeighbourhoodBoundaries();
            nh.FillCoorindate(division, coordinateCP);
            var result = nh.FindLivingCellNeighbours(division, coordinates);

            Assert.True(result.Count == 2);
        }
    }
}
