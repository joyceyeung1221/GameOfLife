using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class LiveCellNeighbourhood : Neighbourhood
    {
        public Coordinate CenterPoint { get; private set; }
        public List<Coordinate> LiveCellNeighbours { get; private set; }
        public List<Coordinate> DeadCellNeighbours { get; private set; }
        private NeighbourhoodHelper _helper;

        public LiveCellNeighbourhood(Coordinate coordinate, NeighbourhoodHelper neighbourhoodHelper)
        {
            CenterPoint = coordinate;
            LiveCellNeighbours = new List<Coordinate>();
            DeadCellNeighbours = new List<Coordinate>();
            _helper = neighbourhoodHelper;
        }

        public void FindNeighbours(List<Coordinate> livingCellCoordinates)
        {
            var division = _helper.FormNeighbourhoodBoundaries();
            var mappedNeighbourHood = _helper.FillCoorindate(division,CenterPoint);
            LiveCellNeighbours = _helper.FindLiveCellNeighbours(mappedNeighbourHood,livingCellCoordinates);
            DeadCellNeighbours = _helper.FindDeadCellNeighbours(mappedNeighbourHood, LiveCellNeighbours);
        }


    }
}
