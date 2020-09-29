using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class Neighbourhood
    {
        private Coordinate _centerPoint;
        public List<Cell> LivingNeighbours;
        public List<Coordinate> DeadNeighboursLocation;

        public Neighbourhood(Coordinate coordinate)
        {
            _centerPoint = coordinate;
            LivingNeighbours = new List<Cell>();
            DeadNeighboursLocation = new List<Coordinate>();
        }

        public void FillWithNeighbours(List<Cell> cells)
        {
            var division = FormDivision();
            
        }

        private int[,] FormDivision()
        {
            var row = 3;
            var column = 3;
            var division = new int[row, column];
            return division;
        }

    }
}
