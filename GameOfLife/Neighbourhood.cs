using System.Collections.Generic;

namespace GameOfLife
{
    public interface Neighbourhood
    {
        public Coordinate CenterPoint { get; }
        public List<Coordinate> LiveCellNeighbours { get; }
        public void FindNeighbours(List<Coordinate> liveCellCoordinates);
    }
}
