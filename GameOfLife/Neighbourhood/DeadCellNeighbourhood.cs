using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class DeadCellNeighbourhood : Neighbourhood
    {
        public Location CenterPoint { get; private set; }
        public List<Location> LiveCellNeighbours { get; private set; }
        private NeighbourhoodHelper _helper;

        public DeadCellNeighbourhood(Location location, NeighbourhoodHelper neighbourhoodHelper)
        {
            CenterPoint = location;
            LiveCellNeighbours = new List<Location>();
            _helper = neighbourhoodHelper;
        }

        public void FindNeighbours(List<Location> liveCellCoordinates)
        {
            var division = _helper.FormNeighbourhoodBoundaries();
            var mappedNeighbourHood = _helper.FindLocation(division, CenterPoint);
            LiveCellNeighbours = _helper.FindLiveCellNeighbours(mappedNeighbourHood, liveCellCoordinates);
        }
    }
}