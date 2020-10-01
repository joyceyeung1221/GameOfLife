using System.Collections.Generic;

namespace GameOfLife
{
    public interface Neighbourhood
    {
        public List<Coordinate> LiveNeighbours { get; }
        public void FindNeighbours(List<Coordinate> liveCellCoordinates);
    }
}
