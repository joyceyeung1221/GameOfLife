using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class CoordinateComparer : IEqualityComparer<Coordinate>
    {
        public bool Equals(Coordinate a, Coordinate b)
        {
            if (a == null || b == null)
                return false;

            return (a.X == b.X && a.Y == b.Y);
        }

        public int GetHashCode(Coordinate obj)
        {
            return obj.GetHashCode();
        }

        public bool Contains(Coordinate obj, List<Coordinate> list)
        {
            if(list.Count == 0)
            {
                return false;
            }
            foreach(Coordinate coordinate in list)
            {
                if (Equals(obj, coordinate))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
