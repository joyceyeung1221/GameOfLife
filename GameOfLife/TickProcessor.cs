using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class TickProcessor
    {
        private LifeDeathValidator _lifeDeathValidator;
        private NeighbourhoodHelper _neighbourhoodHelper;

        public TickProcessor(CoordinateConverter coordinateConverter)
        {
            _lifeDeathValidator = new LifeDeathValidator();
            _neighbourhoodHelper = new NeighbourhoodHelper(coordinateConverter);
        }

        public List<Coordinate> CreateNextGenerationCoordinates(List<Coordinate> currentGeneration)
        {
            var neighbourhoods = FormNeighbourhoods(currentGeneration);
            var nextGeneration = new List<Coordinate>();
            foreach (Neighbourhood neighbourhood in neighbourhoods)
            {
                nextGeneration = CanAddCell(neighbourhood, nextGeneration);
            }
            return nextGeneration;
        }

        private List<Coordinate> CanAddCell(Neighbourhood neighbourhood, List<Coordinate> nextGeneration)
        {
            if (_lifeDeathValidator.IsCellAliveAfterTick(neighbourhood))
            {
                nextGeneration.Add(neighbourhood.CenterPoint);
            }
            return nextGeneration;
        }

        private List<Neighbourhood> FormNeighbourhoods(List<Coordinate> currentGeneration)
        {
            var neighbourhoods = new List<Neighbourhood>();
            var deadCellCoordinates = new List<Coordinate>();
            foreach (Coordinate liveCell in currentGeneration)
            {
                var liveCellNeighbourhood = new LiveCellNeighbourhood(liveCell, _neighbourhoodHelper);
                liveCellNeighbourhood.FindNeighbours(currentGeneration);
                neighbourhoods.Add(liveCellNeighbourhood);
                deadCellCoordinates.AddRange(liveCellNeighbourhood.DeadCellNeighbours);
                deadCellCoordinates = RemoveDuplicateCoordinate(deadCellCoordinates);
            }
            var deadCellNeighbourhoods = FormDeadCellNeighbourhoods(deadCellCoordinates, currentGeneration);
            neighbourhoods.AddRange(deadCellNeighbourhoods);
            return neighbourhoods;
        }

        private List<Coordinate> RemoveDuplicateCoordinate(List<Coordinate> coordinates)
        {
            var filterList = coordinates.GroupBy(n => new { n.X, n.Y }).Select(g => g.First()).ToList();
            return filterList;
        }

        private List<Neighbourhood> FormDeadCellNeighbourhoods(List<Coordinate> deadCellNeighbours, List<Coordinate> currentGeneration)
        {
            var deadCellNeighbourhoods = new List<Neighbourhood>();
            foreach(Coordinate deadCell in deadCellNeighbours)
            {
                var deadCellNeighbourhood = new DeadCellNeighbourhood(deadCell, _neighbourhoodHelper);
                deadCellNeighbourhood.FindNeighbours(currentGeneration);
                deadCellNeighbourhoods.Add(deadCellNeighbourhood);
            }
            return deadCellNeighbourhoods;
        }
    }
}
