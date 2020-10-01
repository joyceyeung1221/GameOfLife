using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class NeighbourhoodHelper
    {
        private CoordinateConverter _coordinateConverter;
        private CoordinateComparer _comparer;

        public NeighbourhoodHelper(CoordinateConverter coordinateConverter)
        {
            _coordinateConverter = coordinateConverter;
            _comparer = new CoordinateComparer();
        }

        public Coordinate[,] FormNeighbourhoodBoundaries()
        {
            var row = 3;
            var column = 3;
            var division = new Coordinate[row, column];
            return division;
        }

        public Coordinate[,] FillCoorindate(Coordinate[,] division, Coordinate centerPoint)
        {
            for (int i = 0; i < division.GetLength(0); i++)
            {
                FillRow(division, i, centerPoint);
            }
            return division;

        }

        private void FillRow(Coordinate[,] division, int i, Coordinate centerPoint)
        {
            for (int j = 0; j < division.GetLength(1); j++)
            {
                if (!IsCenterPoint(i, j))
                {
                    division[i, j] = _coordinateConverter.CreateCoordinateByIndex(i, j, centerPoint);
                }
            }
        }

        private bool IsCenterPoint(int i, int j)
        {
            return i == 1 && j == 1;
        }

        public List<Coordinate> FindLiveCellNeighbours(Coordinate[,] neighbourhood, List<Coordinate> livingCellCoordinates)
        {
            var matchedCoorindates = new List<Coordinate>();
            foreach (Coordinate coordinate in neighbourhood)
            {
                if (_comparer.Contains(coordinate, livingCellCoordinates))
                {
                    matchedCoorindates.Add(coordinate);
                }
            }
            return matchedCoorindates;
        }

        public List<Coordinate> FindDeadCellNeighbours(Coordinate[,] neighbourhood, List<Coordinate> liveNeighbours)
        {
            List<Coordinate> coordinateLists = neighbourhood.Cast<Coordinate>().ToList();
            var remainingCoordates = coordinateLists.Except(liveNeighbours).ToList();
            remainingCoordates.RemoveAll(item => item == null);
            return remainingCoordates;
        }
    }
}
