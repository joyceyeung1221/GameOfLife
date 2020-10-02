using System;
using System.Collections.Generic;
using Xunit;
using Moq;

namespace GameOfLife.Test
{
    public class UniversePresenterTest
    {
        private UniversePresenter _universePresenter;
        private Universe _universe;
        public UniversePresenterTest()
        {
            _universePresenter = new UnverisePresenter();
            _universe = new Universe(5, 5);
        }

        [Fact]
        public void ShouldAnnounceAllLiveExtinct()
        {
            var mockio = new Mock<InputOutput>();
            var liveCellCoordinates = new List<Coordinate>();
            _universePresenter.PrintUniverse(_universe, liveCellCoordinates);
            mockio.Verify(x => x.Output("All lives are extinct in the universe."), Times.Once());
        }

        [Fact]
        public void ShouldPrintUniverseWithLiveCells()
        {

        }
    }
}
