using System.Collections.Generic;

namespace GameOfLife
{
    public interface Neighbourhood
    {
        public Location CenterPoint { get; }
        public List<Location> LiveCellNeighbours { get; }
        public void FindNeighbours(List<Location> liveCellCoordinates);
    }
}
