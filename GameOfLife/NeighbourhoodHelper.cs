using System;
using System.Collections.Generic;

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

        public List<Coordinate> FindLivingCellNeighbours(Coordinate[,] neighbourhood, List<Coordinate> livingCellCoordinates)
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
    }
}
