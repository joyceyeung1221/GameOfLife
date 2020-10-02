using System;
using System.Collections.Generic;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var centerPoint = new Location(2, 2);
            var topLeftCoordinate = new Location(1, 1);
            var topCoordinate = new Location(1, 2);
            var topRightCoordinate = new Location(1, 3);
            var leftCoordinate = new Location(2, 1);
            var distanceCoordinate = new Location(4, 4);
            var universe = new Universe(3, 3);
            var io = new ConsoleProcessor();
            var universePresenter = new UniversePresenter(io, universe);

            var liveCellCoordinates = new List<Location> { topCoordinate, topLeftCoordinate, topRightCoordinate };
            universePresenter.PrintUniverse(universe, liveCellCoordinates);

        }
    }
}
