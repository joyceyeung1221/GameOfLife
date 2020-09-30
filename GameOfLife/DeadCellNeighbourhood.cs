using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class DeadCellNeighbourhood : Neighbourhood
    {
        public Coordinate _centerPoint { get; private set; }
        public List<Coordinate> LivingNeighbours { get; private set; }
        private NeighbourhoodHelper _neighbourhoodHelper;

        public DeadCellNeighbourhood(Coordinate coordinate, NeighbourhoodHelper neighbourhoodHelper)
        {
            _centerPoint = coordinate;
            LivingNeighbours = new List<Coordinate>();
            _neighbourhoodHelper = neighbourhoodHelper;
        }

        public void FindNeighbours(List<Coordinate> livingCellCoordinates)
        {
            var division = _neighbourhoodHelper.FormNeighbourhoodBoundaries();
            var mappedNeighbourHood = _neighbourhoodHelper.FillCoorindate(division, _centerPoint);
            LivingNeighbours = _neighbourhoodHelper.FindLivingCellNeighbours(mappedNeighbourHood, livingCellCoordinates);
        }
    }
}
