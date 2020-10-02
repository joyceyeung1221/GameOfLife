using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class LocationConverter
    {
        private Universe _universe;
        private Dictionary<int, int> indexToCenterPoint = new Dictionary<int, int>()
            {
                {0, -1 },
                {1, 0 },
                {2, 1 }
            };

        public LocationConverter(Universe universe)
        {
            _universe = universe;
        }

        public Location CreateLocationByIndex(int rowIndex, int columnIndex, Location centerPoint)
        {
            var column = CalculateColumnNumberByCenterPoint(columnIndex, centerPoint.Column);
            var row = CalculateRowNumberByCenterPoint(rowIndex, centerPoint.Row);
            return new Location(row, column);

        }

        private int CalculateColumnNumberByCenterPoint(int columnIndexN, int centerPointColumnU)
        {
            var columnU = centerPointColumnU + indexToCenterPoint[columnIndexN];
            if (_universe.IsColumnOverUnveriseEdge(columnU))
            {
                columnU = _universe.GetColumnValueOfOtherEdge(columnU);
            }
            return columnU;
        }

        private int CalculateRowNumberByCenterPoint(int rowIndexN, int centerPointColumnU)
        {
            var rowU = centerPointColumnU + indexToCenterPoint[rowIndexN];
            if (_universe.IsRowOverUniverseEdge(rowU))
            {
                rowU = _universe.GetRowValueOfOtherEdge(rowU);
            }
            return rowU;
        }
    }
}
