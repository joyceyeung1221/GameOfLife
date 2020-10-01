using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class DeadCellNeighbourhood : Neighbourhood
    {
        public Coordinate CenterPoint { get; private set; }
        public List<Coordinate> LiveCellNeighbours { get; private set; }
        private NeighbourhoodHelper _helper;

        public DeadCellNeighbourhood(Coordinate coordinate, NeighbourhoodHelper neighbourhoodHelper)
        {
            CenterPoint = coordinate;
            LiveCellNeighbours = new List<Coordinate>();
            _helper = neighbourhoodHelper;
        }

        public void FindNeighbours(List<Coordinate> liveCellCoordinates)
        {
            var division = _helper.FormNeighbourhoodBoundaries();
            var mappedNeighbourHood = _helper.FillCoorindate(division, CenterPoint);
            LiveCellNeighbours = _helper.FindLiveCellNeighbours(mappedNeighbourHood, liveCellCoordinates);
        }
    }
}
