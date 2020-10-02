using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class NeighbourhoodHelper
    {
        private LocationConverter _locationConverter;
        private LocationComparer _comparer;

        public NeighbourhoodHelper(LocationConverter locationConverter)
        {
            _locationConverter = locationConverter;
            _comparer = new LocationComparer();
        }

        public Location[,] FormNeighbourhoodBoundaries()
        {
            var row = 3;
            var column = 3;
            var division = new Location[row, column];
            return division;
        }

        public Location[,] FindLocation(Location[,] division, Location centerPoint)
        {
            for (int i = 0; i < division.GetLength(0); i++)
            {
                FillRow(division, i, centerPoint);
            }
            return division;

        }

        private void FillRow(Location[,] division, int i, Location centerPoint)
        {
            for (int j = 0; j < division.GetLength(1); j++)
            {
                if (!IsCenterPoint(i, j))
                {
                    division[i, j] = _locationConverter.CreateLocationByIndex(i, j, centerPoint);
                }
            }
        }

        private bool IsCenterPoint(int i, int j)
        {
            return i == 1 && j == 1;
        }

        public List<Location> FindLiveCellNeighbours(Location[,] neighbourhood, List<Location> livingCellCoordinates)
        {
            var matchedCoorindates = new List<Location>();
            foreach (Location coordinate in neighbourhood)
            {
                if (_comparer.Contains(coordinate, livingCellCoordinates))
                {
                    matchedCoorindates.Add(coordinate);
                }
            }
            return matchedCoorindates;
        }

        public List<Location> FindDeadCellNeighbours(Location[,] neighbourhood, List<Location> liveNeighbours)
        {
            List<Location> coordinateLists = neighbourhood.Cast<Location>().ToList();
            var remainingCoordates = coordinateLists.Except(liveNeighbours).ToList();
            remainingCoordates.RemoveAll(item => item == null);
            return remainingCoordates;
        }
    }
}
