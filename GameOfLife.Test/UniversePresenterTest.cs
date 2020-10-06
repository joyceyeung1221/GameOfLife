using System;
using System.Collections.Generic;
using Xunit;
using Moq;

namespace GameOfLife.Test
{
    public class UniversePresenterTest
    {
        private Location centerPoint = new Location(2, 2);
        private Location topLeftLocation = new Location(1, 1);
        private Location topLocation = new Location(1, 2);
        private Location topRightLocation = new Location(1, 3);
        private Location leftLocation = new Location(2, 1);
        private Location distanceLocation = new Location(4, 4);
        private Mock<InputOutput> _mockio;
        private Universe _universe;
        private ConsolePresenter _universePresenter;
        public UniversePresenterTest()
        {
            _universe = new Universe(5, 5);
            _mockio = new Mock<InputOutput>();
            _universePresenter = new ConsolePresenter(_mockio.Object);
        }

        [Fact]
        public void ShouldAnnounceAllLiveExtinct()
        {
            var liveCellLocations = new List<Location>();
            _universePresenter.PrintUniverse(_universe, liveCellLocations);
            _mockio.Verify(x => x.Output("All lives are extinct in the universe."), Times.Once());
        }

        [Fact]
        public void ShouldPrintUniverseWithLiveCells()
        {
            var liveCellLocations = new List<Location> { topLocation,topLeftLocation,topRightLocation,distanceLocation};
            _universePresenter.PrintUniverse(_universe, liveCellLocations);
            _mockio.Verify(x => x.Output("ooo  \n     \n     \n   o \n     \n"), Times.Once);
        }
    }
}
