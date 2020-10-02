using System;
using System.Collections.Generic;
using Xunit;
namespace GameOfLife.Test
{
    public class LifeDeathValidatorTest
    {
        private NeighbourhoodHelper nh = new NeighbourhoodHelper(new LocationConverter(new Universe(5, 5)));
        private Location centerPoint = new Location(2, 2);
        private Location topLeftNeighbour = new Location(1, 1);
        private Location topNeighbour = new Location(1, 2);
        private Location topRightNeighbour = new Location(1, 3);
        private Location leftNeighbour = new Location(2, 1);
        private Location distanceNeighbour = new Location(4, 4);
        public LifeDeathValidatorTest()
        {
        }

        [Fact]
        public void ShouldReturnTrue_WhenLiveCellNeighbourhoodHaveTwoLiveNeighbours()
        {
            var lifeDeathValidator = new LifeDeathValidator();
            var coordinates = new List<Location> { topLeftNeighbour, topNeighbour, distanceNeighbour };
            var neighbourhood = new LiveCellNeighbourhood(centerPoint, nh);
            neighbourhood.FindNeighbours(coordinates);
            var result = lifeDeathValidator.IsCellAliveAfterTick(neighbourhood);

            Assert.True(result);
        }

        [Fact]
        public void ShouldReturnTrue_WhenLiveCellNeighbourhoodHaveThreeLiveNeighbours()
        {
            var lifeDeathValidator = new LifeDeathValidator();
            var coordinates = new List<Location> { topLeftNeighbour, topNeighbour, topRightNeighbour, distanceNeighbour };
            var neighbourhood = new LiveCellNeighbourhood(centerPoint, nh);
            neighbourhood.FindNeighbours(coordinates);
            var result = lifeDeathValidator.IsCellAliveAfterTick(neighbourhood);

            Assert.True(result);
        }

        [Fact]
        public void ShouldReturnFalse_WhenLiveCellNeighbourhoodHaveMoreThanThreeLiveNeighbours()
        {
            var lifeDeathValidator = new LifeDeathValidator();
            var coordinates = new List<Location> { topLeftNeighbour, topNeighbour, topRightNeighbour, leftNeighbour, distanceNeighbour };
            var neighbourhood = new LiveCellNeighbourhood(centerPoint, nh);
            neighbourhood.FindNeighbours(coordinates);
            var result = lifeDeathValidator.IsCellAliveAfterTick(neighbourhood);

            Assert.False(result);
        }

        [Fact]
        public void ShouldReturnFalse_WhenLiveCellNeighbourhoodHaveLessThanTwoLiveNeighbours()
        {
            var lifeDeathValidator = new LifeDeathValidator();
            var coordinates = new List<Location> { topLeftNeighbour, distanceNeighbour };
            var neighbourhood = new LiveCellNeighbourhood(centerPoint, nh);
            neighbourhood.FindNeighbours(coordinates);
            var result = lifeDeathValidator.IsCellAliveAfterTick(neighbourhood);

            Assert.False(result);
        }

        [Fact]
        public void ShouldReturnTrue_WhenDeadCellNeighbourhoodHaveThreeLiveNeighbours()
        {
            var lifeDeathValidator = new LifeDeathValidator();
            var coordinates = new List<Location> { topLeftNeighbour, topNeighbour, topRightNeighbour, distanceNeighbour };
            var neighbourhood = new DeadCellNeighbourhood(centerPoint, nh);
            neighbourhood.FindNeighbours(coordinates);
            var result = lifeDeathValidator.IsCellAliveAfterTick(neighbourhood);

            Assert.True(result);
        }

        [Fact]
        public void ShouldReturnFalse_WhenDeadCellNeighbourhoodHaveLessThanThreeLiveNeighbours()
        {
            var lifeDeathValidator = new LifeDeathValidator();
            var coordinates = new List<Location> { topLeftNeighbour, topNeighbour, distanceNeighbour };
            var neighbourhood = new DeadCellNeighbourhood(centerPoint, nh);
            neighbourhood.FindNeighbours(coordinates);
            var result = lifeDeathValidator.IsCellAliveAfterTick(neighbourhood);

            Assert.False(result);
        }

        [Fact]
        public void ShouldReturnF_WhenDeadCellNeighbourhoodHaveMoreThanThreeLiveNeighbours()
        {
            var lifeDeathValidator = new LifeDeathValidator();
            var coordinates = new List<Location> { topLeftNeighbour, topNeighbour, topRightNeighbour, leftNeighbour, distanceNeighbour };
            var neighbourhood = new DeadCellNeighbourhood(centerPoint, nh);
            neighbourhood.FindNeighbours(coordinates);
            var result = lifeDeathValidator.IsCellAliveAfterTick(neighbourhood);

            Assert.False(result);
        }
    }
}
