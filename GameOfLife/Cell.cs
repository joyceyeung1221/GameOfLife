using System;
namespace GameOfLife
{
    public class Cell
    {
        public Coordinate location { get; private set; }
        public Cell(int x, int y)
        {
            location = new Coordinate(x, y);
        }
    }
}
