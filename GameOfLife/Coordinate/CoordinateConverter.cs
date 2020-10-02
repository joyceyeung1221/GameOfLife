using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class CoordinateConverter
    {
        private Universe _universe;
        private Dictionary<int, int> indexToCenterPoint = new Dictionary<int, int>()
            {
                {0, -1 },
                {1, 0 },
                {2, 1 }

            };

        public CoordinateConverter(Universe universe)
        {
            _universe = universe;
        }

        public Coordinate CreateCoordinateByIndex(int row, int column, Coordinate centerPoint)
        {
            var XAxis = CalculateXValueByCenterPoint(column, centerPoint.X);
            var YAxis = CalculateYValueByCenterPoint(row, centerPoint.Y);
            return new Coordinate(XAxis, YAxis);

        }

        private int CalculateXValueByCenterPoint(int column, int X)
        {
            var xValue = X + indexToCenterPoint[column];
            if (_universe.IsXOverUnveriseEdge(xValue))
            {
                xValue = _universe.GetXValueOfOtherEdge(xValue);
            }
            return xValue;
        }

        private int CalculateYValueByCenterPoint(int row, int Y)
        {
            var yValue = Y + indexToCenterPoint[row];
            if (_universe.IsYOverUniverseEdge(yValue))
            {
                yValue = _universe.GetYValueOfOtherEdge(yValue);
            }
            return yValue;
        }
    }
}
