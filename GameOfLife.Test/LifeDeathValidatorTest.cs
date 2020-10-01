using System;
using System.Collections.Generic;
using Xunit;
namespace GameOfLife.Test
{
    public class LifeDeathValidatorTest
    {
        private NeighbourhoodHelper nh = new NeighbourhoodHelper(new CoordinateConverter(new Universe(5, 5)));
        private Coordinate coordinateCP = new Coordinate(2, 2);
        private Coordinate coordinate1 = new Coordinate(1, 1);
        private Coordinate coordinate2 = new Coordinate(1, 2);
        private Coordinate coordinate3 = new Coordinate(1, 3);
        private Coordinate coordinate4 = new Coordinate(4, 4);
        public LifeDeathValidatorTest()
        {
        }

        [Fact]
        public void ShouldReturnTrue_WhenCellMeetsLivingCriteria()
        {
            var lifeDeathValidator = new LifeDeathValidator();
            var coordinates = new List<Coordinate> { coordinate1, coordinate2, coordinate4 };
            var neighbourhood = new DeadCellNeighbourhood(coordinateCP, nh);
            neighbourhood.FindNeighbours(coordinates);
            var result = lifeDeathValidator.IsCellAliveAfterTick(neighbourhood);

            Assert.True(result);
        }
    }
}
