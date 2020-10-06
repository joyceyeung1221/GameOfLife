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

        public bool IsEqual(Location location)
        {
            if (location == null)
                return false;

            return (this.Column == location.Column && this.Row == location.Row);
        }
    }
}
