using System.Collections.Generic;

namespace GameOfLife
{
    public interface Neighbourhood
    {
        public List<Coordinate> LivingNeighbours { get; }
        public void FindNeighbours(List<Coordinate> livingCellCoordinates);
    }
}
