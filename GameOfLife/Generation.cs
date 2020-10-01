using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class Generation
    {
        public List<Coordinate> LiveCellCoordinates { get; private set; }
        private TickProcessor _tickProcessor;
        public Generation(List<Coordinate> liveCellCoordinate, TickProcessor tickProcessor)
        {
            LiveCellCoordinates = liveCellCoordinate;
            _tickProcessor = tickProcessor;
        }

        public void Evolve()
        {
            LiveCellCoordinates = _tickProcessor.CreateNextGenerationCoordinates(LiveCellCoordinates);
        }
    }

}
