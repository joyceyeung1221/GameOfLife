using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class LiveCellNeighbourhood : Neighbourhood
    {
        public Location CenterPoint { get; private set; }
        public List<Location> LiveCellNeighbours { get; private set; }
        public List<Location> DeadCellNeighbours { get; private set; }
        private NeighbourhoodHelper _helper;

        public LiveCellNeighbourhood(Location coordinate, NeighbourhoodHelper neighbourhoodHelper)
        {
            CenterPoint = coordinate;
            LiveCellNeighbours = new List<Location>();
            DeadCellNeighbours = new List<Location>();
            _helper = neighbourhoodHelper;
        }

        public void FindNeighbours(List<Location> livingCellCoordinates)
        {
            var division = _helper.FormNeighbourhoodBoundaries();
            var mappedNeighbourHood = _helper.FindLocation(division,CenterPoint);
            LiveCellNeighbours = _helper.FindLiveCellNeighbours(mappedNeighbourHood,livingCellCoordinates);
            DeadCellNeighbours = _helper.FindDeadCellNeighbours(mappedNeighbourHood, LiveCellNeighbours);
        }


    }
}
