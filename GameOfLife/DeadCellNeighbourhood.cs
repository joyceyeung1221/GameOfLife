using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class DeadCellNeighbourhood : Neighbourhood
    {
        public Coordinate _centerPoint { get; private set; }
        public List<Coordinate> LiveNeighbours { get; private set; }
        private NeighbourhoodHelper _helper;

        public DeadCellNeighbourhood(Coordinate coordinate, NeighbourhoodHelper neighbourhoodHelper)
        {
            _centerPoint = coordinate;
            LiveNeighbours = new List<Coordinate>();
            _helper = neighbourhoodHelper;
        }

        public void FindNeighbours(List<Coordinate> liveCellCoordinates)
        {
            var division = _helper.FormNeighbourhoodBoundaries();
            var mappedNeighbourHood = _helper.FillCoorindate(division, _centerPoint);
            LiveNeighbours = _helper.FindLiveCellNeighbours(mappedNeighbourHood, liveCellCoordinates);
        }
    }
}
