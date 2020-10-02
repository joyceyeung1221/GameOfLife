using System;
using System.Collections.Generic;
using Xunit;
namespace GameOfLife.Test
{
    public class TickProcessorTest
    {
        private Location centerPoint = new Location(2, 2);
        private Location topLeftLocation = new Location(1, 1);
        private Location topLocation = new Location(1, 2);
        private Location topRightLocation = new Location(1, 3);
        private Location distanceLocation = new Location(4, 4);
        private LocationComparer _comparer = new LocationComparer();
        public TickProcessorTest()
        {
        }

        [Fact]
        public void ShouldReturnANewListOfLocations()
        {
            var locationConverter = new LocationConverter(new Universe(5, 5));
            var tickProcessor = new TickProcessor(locationConverter);
            var locations = new List<Location> { topLeftLocation, topLocation, topRightLocation };
            var result = tickProcessor.CreateNextGenerationLocations(locations);

            Assert.IsType<List<Location>>(result);
            Assert.Equal(3,result.Count);
        }
    }
}
