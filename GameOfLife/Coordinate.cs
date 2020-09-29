using System;
namespace GameOfLife
{
    public class Coordinate
    {
        public int Row { get; private set; }
        public int Column { get; private set; }

        public Coordinate(int x, int y)
        {
            Column = x;
            Row = y;
        }
    }
}
