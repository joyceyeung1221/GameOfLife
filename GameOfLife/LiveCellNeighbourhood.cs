using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class LiveCellNeighbourhood : Neighbourhood
    {
        public Coordinate _centerPoint { get; private set; }
        public List<Coordinate> LiveNeighbours { get; private set; }
        public List<Coordinate> DeadNeighbours { get; private set; }
        private NeighbourhoodHelper _helper;

        public LiveCellNeighbourhood(Coordinate coordinate, NeighbourhoodHelper neighbourhoodHelper)
        {
            _centerPoint = coordinate;
            LiveNeighbours = new List<Coordinate>();
            DeadNeighbours = new List<Coordinate>();
            _helper = neighbourhoodHelper;
        }

        public void FindNeighbours(List<Coordinate> livingCellCoordinates)
        {
            var division = _helper.FormNeighbourhoodBoundaries();
            var mappedNeighbourHood = _helper.FillCoorindate(division,_centerPoint);
            LiveNeighbours = _helper.FindLiveCellNeighbours(mappedNeighbourHood,livingCellCoordinates);
            DeadNeighbours = _helper.FindDeadCellNeighbours(mappedNeighbourHood, LiveNeighbours);
        }


    }
}
