using System;
namespace GameOfLife
{
    public class Location
    {
        public int Row { get; private set; }
        public int Column { get; private set; }

        public Location(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
