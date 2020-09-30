using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class LivingCellNeighbourhood : Neighbourhood
    {
        public Coordinate _centerPoint { get; private set; }
        public List<Coordinate> LivingNeighbours { get; private set; }
        public List<Coordinate> DeadNeighbours { get; private set; }
        private NeighbourhoodHelper _neighbourhoodHelper;

        public LivingCellNeighbourhood(Coordinate coordinate, NeighbourhoodHelper neighbourhoodHelper)
        {
            _centerPoint = coordinate;
            LivingNeighbours = new List<Coordinate>();
            DeadNeighbours = new List<Coordinate>();
            _neighbourhoodHelper = neighbourhoodHelper;
        }

        public void FindNeighbours(List<Coordinate> livingCellCoordinates)
        {
            var division = _neighbourhoodHelper.FormNeighbourhoodBoundaries();
            var mappedNeighbourHood = _neighbourhoodHelper.FillCoorindate(division,_centerPoint);
            LivingNeighbours = _neighbourhoodHelper.FindLivingCellNeighbours(mappedNeighbourHood,livingCellCoordinates);
            DeadNeighbours = FindDeadCellNeighbours(mappedNeighbourHood);
        }

        private List<Coordinate> FindDeadCellNeighbours(Coordinate[,] neighbourhood)
        {
            List<Coordinate> coordinateLists = neighbourhood.Cast<Coordinate>().ToList();
            var remainingCoordates = coordinateLists.Except(LivingNeighbours).ToList();
            remainingCoordates.RemoveAll(item => item == null);
            return remainingCoordates;
        }

    }
}
