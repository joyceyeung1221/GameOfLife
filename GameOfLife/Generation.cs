using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class Generation
    {
        public List<Location> LiveCellLocations { get; private set; }
        private TickProcessor _tickProcessor;
        public Generation(List<Location> liveCellLocations, TickProcessor tickProcessor)
        {
            LiveCellLocations = liveCellLocations;
            _tickProcessor = tickProcessor;
        }

        public void Evolve()
        {
            LiveCellLocations = _tickProcessor.CreateNextGenerationLocations(LiveCellLocations);
        }
    }

}
