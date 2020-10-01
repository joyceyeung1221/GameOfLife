using System;
using System.Collections.Generic;
using Xunit;
namespace GameOfLife.Test
{
    public class LifeDeathValidatorTest
    {
        private NeighbourhoodHelper nh = new NeighbourhoodHelper(new CoordinateConverter(new Universe(5, 5)));
        private Coordinate centerPoint = new Coordinate(2, 2);
        private Coordinate topLeftNeighbour = new Coordinate(1, 1);
        private Coordinate topNeighbour = new Coordinate(1, 2);
        private Coordinate topRightNeighbour = new Coordinate(1, 3);
        private Coordinate leftNeighbour = new Coordinate(2, 1);
        private Coordinate distanceNeighbour = new Coordinate(4, 4);
        public LifeDeathValidatorTest()
        {
        }

        [Fact]
        public void ShouldReturnTrue_WhenLiveCellNeighbourhoodHaveTwoLiveNeighbours()
        {
            var lifeDeathValidator = new LifeDeathValidator();
            var coordinates = new List<Coordinate> { topLeftNeighbour, topNeighbour, distanceNeighbour };
            var neighbourhood = new DeadCellNeighbourhood(centerPoint, nh);
            neighbourhood.FindNeighbours(coordinates);
            var result = lifeDeathValidator.IsCellAliveAfterTick(neighbourhood);

            Assert.True(result);
        }

        [Fact]
        public void ShouldReturnTrue_WhenLiveCellNeighbourhoodHaveThreeLiveNeighbours()
        {
            var lifeDeathValidator = new LifeDeathValidator();
            var coordinates = new List<Coordinate> { topLeftNeighbour, topNeighbour, topRightNeighbour, distanceNeighbour };
            var neighbourhood = new DeadCellNeighbourhood(centerPoint, nh);
            neighbourhood.FindNeighbours(coordinates);
            var result = lifeDeathValidator.IsCellAliveAfterTick(neighbourhood);

            Assert.True(result);
        }

        [Fact]
        public void ShouldReturnFalse_WhenLiveCellNeighbourhoodHaveMoreThanThreeLiveNeighbours()
        {
            var lifeDeathValidator = new LifeDeathValidator();
            var coordinates = new List<Coordinate> { topLeftNeighbour, topNeighbour, topRightNeighbour, leftNeighbour, distanceNeighbour };
            var neighbourhood = new DeadCellNeighbourhood(centerPoint, nh);
            neighbourhood.FindNeighbours(coordinates);
            var result = lifeDeathValidator.IsCellAliveAfterTick(neighbourhood);

            Assert.False(result);
        }

        [Fact]
        public void ShouldReturnFalse_WhenLiveCellNeighbourhoodHaveLessThanTwoLiveNeighbours()
        {
            var lifeDeathValidator = new LifeDeathValidator();
            var coordinates = new List<Coordinate> { topLeftNeighbour, distanceNeighbour };
            var neighbourhood = new DeadCellNeighbourhood(centerPoint, nh);
            neighbourhood.FindNeighbours(coordinates);
            var result = lifeDeathValidator.IsCellAliveAfterTick(neighbourhood);

            Assert.False(result);
        }
    }
}
