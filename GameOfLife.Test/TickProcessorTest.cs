using System;
using System.Collections.Generic;
using Xunit;
namespace GameOfLife.Test
{
    public class TickProcessorTest
    {
        private Coordinate coordinateCP = new Coordinate(2, 2);
        private Coordinate coordinate1 = new Coordinate(1, 1);
        private Coordinate coordinate2 = new Coordinate(1, 2);
        private Coordinate coordinate3 = new Coordinate(1, 3);
        private Coordinate coordinate4 = new Coordinate(4, 4);
        private CoordinateComparer _comparer = new CoordinateComparer();
        public TickProcessorTest()
        {
        }

        [Fact]
        public void ShouldReturnANewListOfCoordinates()
        {
            var coordinateConverter = new CoordinateConverter(new Universe(5, 5));
            var tickProcessor = new TickProcessor(coordinateConverter);
            var coordinates = new List<Coordinate> { coordinate1, coordinate2, coordinate3 };
            var result = tickProcessor.CreateNextGenerationCoordinates(coordinates);

            Assert.IsType<List<Coordinate>>(result);
            Assert.Single(result);
        }
    }
}
