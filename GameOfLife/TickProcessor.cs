using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class TickProcessor
    {
        private LifeDeathValidator _lifeDeathValidator;
        private NeighbourhoodHelper _neighbourhoodHelper;

        public TickProcessor(LocationConverter coordinateConverter)
        {
            _lifeDeathValidator = new LifeDeathValidator();
            _neighbourhoodHelper = new NeighbourhoodHelper(coordinateConverter);
        }

        public List<Location> CreateNextGenerationLocations(List<Location> currentGeneration)
        {
            var neighbourhoods = FormNeighbourhoods(currentGeneration);
            var nextGeneration = new List<Location>();
            foreach (Neighbourhood neighbourhood in neighbourhoods)
            {
                nextGeneration = CanAddCell(neighbourhood, nextGeneration);
            }
            return nextGeneration;
        }

        private List<Location> CanAddCell(Neighbourhood neighbourhood, List<Location> nextGeneration)
        {
            if (_lifeDeathValidator.IsCellAliveAfterTick(neighbourhood))
            {
                nextGeneration.Add(neighbourhood.CenterPoint);
            }
            return nextGeneration;
        }

        private List<Neighbourhood> FormNeighbourhoods(List<Location> currentGeneration)
        {
            var neighbourhoods = new List<Neighbourhood>();
            var deadCellLocations = new List<Location>();
            foreach (Location liveCell in currentGeneration)
            {
                var liveCellNeighbourhood = new LiveCellNeighbourhood(liveCell, _neighbourhoodHelper);
                liveCellNeighbourhood.FindNeighbours(currentGeneration);
                neighbourhoods.Add(liveCellNeighbourhood);
                deadCellLocations.AddRange(liveCellNeighbourhood.DeadCellNeighbours);
            }
            deadCellLocations = RemoveDuplicateCoordinate(deadCellLocations);
            var deadCellNeighbourhoods = FormDeadCellNeighbourhoods(deadCellLocations, currentGeneration);
            neighbourhoods.AddRange(deadCellNeighbourhoods);
            return neighbourhoods;
        }

        private List<Location> RemoveDuplicateCoordinate(List<Location> locations)
        {
            var filterList = locations.GroupBy(n => new { n.Column, n.Row }).Select(g => g.First()).ToList();
            return filterList;
        }

        private List<Neighbourhood> FormDeadCellNeighbourhoods(List<Location> deadCellNeighbours, List<Location> currentGeneration)
        {
            var deadCellNeighbourhoods = new List<Neighbourhood>();
            foreach(Location deadCell in deadCellNeighbours)
            {
                var deadCellNeighbourhood = new DeadCellNeighbourhood(deadCell, _neighbourhoodHelper);
                deadCellNeighbourhood.FindNeighbours(currentGeneration);
                deadCellNeighbourhoods.Add(deadCellNeighbourhood);
            }
            return deadCellNeighbourhoods;
        }
    }
}
