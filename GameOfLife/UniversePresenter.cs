using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class UniversePresenter
    {
        private InputOutput _io;
        private char _cell;
        public UniversePresenter(InputOutput io, Universe universe)
        {
            _io = io;
            _cell = 'o';
        }

        public void PrintUniverse(Universe universe, List<Location> liveCellLocations)
        {
            CanAnnounceNoLiveCell(liveCellLocations);
            CanPrsenceUniverse(universe, liveCellLocations);
        }

        private void CanPrsenceUniverse(Universe universe, List<Location> liveCellLocations)
        {
            if (liveCellLocations.Count > 0)
            {
                var universeIn2d = new char[universe.Row, universe.Col];
                var universeWithLiveCells = AssignLiveCell(universeIn2d, liveCellLocations);
                var stringToPrint = ConvertUniverseToString(universeWithLiveCells);
                _io.Output(stringToPrint);
            }
        }

        private string ConvertUniverseToString(char[,] universeWithLiveCells)
        {
            var stringToPrint = "";
            for(var i = 0; i < universeWithLiveCells.GetLength(0); i++)
            {
                stringToPrint = GetSymbolInRow(universeWithLiveCells, stringToPrint, i);
                stringToPrint += "\n";
            }
            return stringToPrint;

        }

        private string GetSymbolInRow(char[,] universeWithLiveCells, string stringToPrint, int i)
        {
            for (var j = 0; j < universeWithLiveCells.GetLength(1); j++)
            {
                stringToPrint += GetSymbol(universeWithLiveCells[i, j]);
            }

            return stringToPrint;
        }

        private char GetSymbol(char locationContent)
        {
            return locationContent == 0 ? ' ' : _cell;

        }
        private char[,] AssignLiveCell(char[,] universeIn2d, List<Location> liveCellLocations)
        {
            foreach(Location location in liveCellLocations)
            {
                var rowIndex = location.Row - 1;
                var columnIndex = location.Column - 1;
                universeIn2d[rowIndex, columnIndex] = _cell;
            }
            return universeIn2d;
        }

        private void CanAnnounceNoLiveCell(List<Location> liveCellLocations)
        {
            if (liveCellLocations.Count == 0)
            {
                _io.Output("All lives are extinct in the universe.");
            }
        }
    }
}
